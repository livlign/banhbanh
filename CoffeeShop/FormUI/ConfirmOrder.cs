using CoffeeShop.Core.Extension;
using Subsonic2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.FormUI
{
    public partial class ConfirmOrder : Form
    {
        public class test
        {
            public string ProductName { get; set; }
            public int Price { get; set; }
            public int Qty { get; set; }
            public int Total { get; set; }
        }

        decimal addondiscount = 0;
        decimal discount = 0;
        decimal totalprice = 0;
        decimal total = 0;
        decimal custcash = 0;
        decimal returnCash = 0;
        string ordernumber = "";
        List<TempOrderItem> listItem;

        public ConfirmOrder()
        {
            InitializeComponent();

            var list = new List<test>();
            for (int i = 0; i < 5; i++)
            {
                test t = new test();
                t.ProductName = "Sản phẩm " + (i + 1);
                t.Price = 10000 * (i + 1);
                t.Qty = 1 * (i + 1);
                t.Total = t.Price * t.Qty;
                list.Add(t);
            }
            dgvOrderItem.DataSource = list;         
        }

        public ConfirmOrder(string OrderNumber, string note, List<TempOrderItem> ListItem)
        {
            InitializeComponent();
            ordernumber = OrderNumber;
            listItem = ListItem;

            dgvOrderItem.AutoGenerateColumns = false;
            dgvOrderItem.DataSource = ListItem;
            lblOrderNumber.Text = OrderNumber;
            txtNote.Text = note;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblUser.Text = Utilities.CurrentUser == null ? "" : Utilities.CurrentUser.FullName;

            totalprice = total = ListItem.Sum(c => c.TotalPrice);
            lblTotalPrice.Text = totalprice.ToString("N0");
            lblTotal.Text = total.ToString("N0");

            var count = new OrderCollection().Where(Order.Columns.DateCreated, SubSonic.Comparison.GreaterOrEquals, DateTime.Now.Date).Load().Count();
            lblOrderRef.Text = DateTime.Now.ToString("yyMMdd") + string.Format("{0:0000}", count + 1);

            txtCustCash.Focus();
            //txtAddonDiscount.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.HandlerIntTextbox(e);
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Utilities.FormatMoney(sender);
            
            if (txtDiscount.Text != "")            
            {
                discount = decimal.Parse(txtDiscount.Text);
                //txtAddonDiscount.Enabled = true;
            }
            else
            {
                discount = 0;
                //txtAddonDiscount.Enabled = false;
                //txtAddonDiscount.Text = "";
            }

            CalculateDiscount();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (total < 0)
            {
                MessageBox.Show("Giá không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiscount.Focus();
                return;
            }

            if (custcash < total)
            {
                MessageBox.Show("Số tiền khách đưa không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustCash.Focus();
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn tạo hóa đơn này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Create order
                Order o = new Order();
                o.OrderNumber = ordernumber;
                o.ValueX = totalprice;
                o.Discount = discount;
                //Discount type: 1 Cash - 2 Percent
                o.DiscountType = rdoDiscountCash.Checked ? 1 : 2;
                o.TotalCost = listItem.Sum(c => c.Qty * c.Cost);
                o.TotalValue = total;
                o.DateCreated = DateTime.Now;
                o.UserId = Utilities.CurrentUser == null ? 1 : Utilities.CurrentUser.Id;
                o.StatusId = 1;
                o.Note = txtNote.Text;
                o.OrderRef = lblOrderRef.Text;
                o.VoucherCode = txtVoucherCode.Text;
                o.AddonDiscount = addondiscount;
                o.Save();

                //OrderItem
                foreach (var item in listItem)
                {
                    OrderItem oi = new OrderItem();
                    oi.OrderId = o.Id;
                    oi.ProductId = item.ProductId;
                    oi.Qty = item.Qty;
                    oi.Price = item.Price;
                    oi.Cost = item.Cost;
                    oi.Save();
                }

                //Payment
                PaymentHistory ph = new PaymentHistory();
                ph.OrderId = o.Id;
                ph.ValueX = total;
                ph.TypeId = rdoCash.Checked ? 1 : 2;
                ph.UserId = Utilities.CurrentUser == null ? 1 : Utilities.CurrentUser.Id;
                ph.DateCreated = DateTime.Now;
                ph.Save();

                //Print recipt
                StringBuilder sbOrder = new StringBuilder(Templates.orderTemp.TemplateText);
                StringBuilder sbItem = new StringBuilder();
                sbOrder = sbOrder.Replace("<username>", Utilities.CurrentUser.FullName)
                                     .Replace("<ordernumber>", ordernumber)
                                     .Replace("<date>", o.DateCreated.Value.ToString("dd/MM/yyyy HH:mm:ss"))
                                     .Replace("<orderref>", o.OrderRef)
                                     .Replace("<total>", o.ValueX.Value.ToString("N0"))
                                     .Replace("<totalprice>", o.TotalValue.Value.ToString("N0"))
                                     .Replace("<discount>", (o.ValueX - o.TotalValue).Value.ToString("N0"))
                                     .Replace("<cuscash>", custcash.ToString("N0"))
                                     .Replace("<backcash>", returnCash.ToString("N0"))
                                     .Replace("<paymenttype>", ph.TypeId == 1 ? "Tiền mặt" : "Thẻ ATM");
                int stt = 1;
                foreach (var item in listItem)
                {
                    StringBuilder sb = new StringBuilder(Templates.orderItemTemp.TemplateText);
                    sb = sb.Replace("<stt>",stt.ToString())
                         .Replace("<product>", item.ProductName.ToUpper())
                         .Replace("<qty>", item.Qty.ToString())
                         .Replace("<price>", item.Price.ToString("N0"))
                         .Replace("<totalprice>", item.TotalPrice.ToString("N0"));
                    sbItem.AppendLine(sb.ToString());
                    stt++;
                }
                sbOrder = sbOrder.Replace("<orderitem>", sbItem.ToString());

                var ReciptFolder = @"C:/CoffeeShop/Recipt/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                if (!Directory.Exists(ReciptFolder))
                {
                    Directory.CreateDirectory(ReciptFolder);
                }
                var filename = ReciptFolder + "HoaDon_" + o.OrderRef + ".html";
                File.WriteAllText(filename, sbOrder.ToString());


                //frmPrintOrder print = new frmPrintOrder(filename);
                //print.ShowDialog();
               
                //In hoa don
                Utilities.InHtml(filename);

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
        }

        private void txtCustCash_TextChanged(object sender, EventArgs e)
        {
            Utilities.FormatMoney(sender);
            custcash = 0;
            if (txtCustCash.Text != "")
            {
                custcash = decimal.Parse(txtCustCash.Text);
            }
            returnCash = custcash - total;
            lblReturn.Text = "0";
            if (returnCash > 0)
                lblReturn.Text = returnCash.ToString("N0");
        }

        private void ConfirmOrder_Load(object sender, EventArgs e)
        {
            txtCustCash.Focus();
        }

        private void txtCustCash_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            if (btnVoucher.Text == "Áp dụng")
            {
                if (txtVoucherCode.Text != "")
                {
                    var voucher = new Voucher(Voucher.Columns.VoucherCode, txtVoucherCode.Text);
                    if (voucher != null && voucher.Id > 0)
                    {
                        if (!voucher.Active.Value)
                        {
                            lblVoucherText.Text = "Mã giảm giá không được kích hoạt.";
                            lblVoucherText.ForeColor = Color.Red;
                            return;
                        }
                        if (voucher.DateActive != null && voucher.DateActive.Value.Date > DateTime.Now.Date)
                        {
                            lblVoucherText.Text = "Mã giảm giá này chưa tới ngày kích hoạt. Ngày kích hoạt: " + voucher.DateActive.Value.ToString("dd/MM/yyyy");
                            lblVoucherText.ForeColor = Color.Red;
                            return;
                        }
                        if (voucher.DateExpire != null && voucher.DateExpire > new DateTime(2017, 1, 1) && voucher.DateExpire.Value.Date < DateTime.Now.Date)
                        {
                            lblVoucherText.Text = "Mã giảm giá này đã hết hạn";
                            lblVoucherText.ForeColor = Color.Red;
                            return;
                        }
                        if (voucher.Type == 1 && voucher.ValueX > totalprice)
                        {
                            voucher.ValueX = totalprice;
                        }
                        ApplyVoucher(voucher);
                    }
                    else
                    {
                        lblVoucherText.Text = "Mã giảm giá này không tồn tại.";
                        lblVoucherText.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                txtDiscount.Text = "";
                txtVoucherCode.Text = "";
                txtDiscount.Enabled = true;
                txtVoucherCode.Enabled = true;
                btnVoucher.Text = "Áp dụng";
                lblVoucherText.Text = "";
            }
            
        }

        private void ApplyVoucher(Voucher voucher)
        {
            if (voucher.Type == 0)
                rdoDiscountPercent.Checked = true;
            else
                rdoDiscountCash.Checked = true;

            txtDiscount.Text = voucher.ValueX.ToString();

            lblVoucherText.Text = "Mã giảm giá được áp dụng";
            lblVoucherText.ForeColor = Color.ForestGreen;

            txtDiscount.Enabled = false;
            txtVoucherCode.Enabled = false;

            btnVoucher.Text = "Hủy mã";

            txtCustCash.Focus();
        }

        private void txtVoucherCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnVoucher.PerformClick();
            }
        }

        private void txtAddonDiscount_TextChanged(object sender, EventArgs e)
        {
            Utilities.FormatMoney(sender);

            if (txtAddonDiscount.Text != "")
            {
                addondiscount = decimal.Parse(txtAddonDiscount.Text);
            }
            else
            {
                addondiscount = 0;
            }

            CalculateDiscount();
        }

        private void txtAddonDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.HandlerIntTextbox(e);
        }

        private void CalculateDiscount()
        {
            if (rdoDiscountCash.Checked)
            {
                total = totalprice - discount;
            }
            else
            {
                total = totalprice - ((totalprice * discount) / 100);
            }

            total = total - addondiscount;

            lblTotal.Text = total.ToString("N0");
        }
    }
}
