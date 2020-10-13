using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subsonic2;
using CoffeeShop.FormUI;

namespace CoffeeShop.Control
{
    public partial class ReportControl : UserControl
    {
        public class ReportProductArgument{
            public DateTime fromDate { get; set; }
            public DateTime toDate { get; set; }
            public int categoryId { get; set; }
        }

        public class ReportSaleArgument
        {
            public DateTime fromDate { get; set; }
            public DateTime toDate { get; set; }
        }

        public ReportControl()
        {
            InitializeComponent();

            //Report sale by date
            dgvSaleReport_Order.AutoGenerateColumns = false;
            dgvSaleReport_Item.AutoGenerateColumns = false;
            dgvSaleReport_Date.AutoGenerateColumns = false;
            dtpSaleReport_FromDate.Value = DateTime.Now.AddYears(-1);
            dtpSaleReport_ToDate.Value = DateTime.Now;

            dgvSaleReport_Order.ContextMenuStrip = cmsOrder;            

            //Report sale by product
            var listcategory = new CategoryCollection().Where(Category.Columns.Active, true).Load().ToList();
            var c = new Category();
            c.Id = 0;
            c.Name = "Tất cả";
            listcategory.Insert(0, c);
            cmbProductReportCategory.DataSource = listcategory;
            cmbProductReportCategory.DisplayMember = "Name";
            cmbProductReportCategory.ValueMember = "Id";
            cmbProductReportCategory.SelectedIndex = 0;

            dgvReportProduct.AutoGenerateColumns = false;
            dgvReportProductDate.AutoGenerateColumns = false;
            dtpProductReportFrom.Value = DateTime.Now.AddYears(-1);
            dtpProductReportTo.Value = DateTime.Now;

            //Report sale by customer
            dgvCustomerReport_Main.AutoGenerateColumns = false;
            dgvCustomerReport_Order.AutoGenerateColumns = false;
            dgvCustomerReport_OrderDetail.AutoGenerateColumns = false;
            dtpCustomerReportFrom.Value = DateTime.Now.AddYears(-1);
            dtpCustomerReportTo.Value = DateTime.Now;
        }

        private void btnSaleReport_Search_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(2016, 1, 1);
            var toDate = DateTime.Now;
            if (dtpSaleReport_FromDate.Checked)
                fromDate = dtpSaleReport_FromDate.Value;
            if (dtpSaleReport_ToDate.Checked)
                toDate = dtpSaleReport_ToDate.Value;

            ReportSaleArgument arg = new ReportSaleArgument();
            arg.fromDate = fromDate;
            arg.toDate = toDate;
            if (!bwSaleReport.IsBusy)
            {
                bwSaleReport.RunWorkerAsync(arg);
                btnSaleReport_Search.Visible = false;
                pbSaleReport.Visible = true;
            }
        }

        private void txtSaleReport_User_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaleReport_Search.PerformClick();
            }
        }

        private void ReportControl_Load(object sender, EventArgs e)
        {
            btnSaleReport_Search.PerformClick();
        }

        private void bwLoadItems_DoWork(object sender, DoWorkEventArgs e)
        {
            var orderid = (int)e.Argument;
            var dt = SPs.SpGetOrderItems(orderid).GetDataSet().Tables[0];
            e.Result = dt;
        }

        private void dgvSaleReport_Order_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSaleReport_Order.SelectedRows.Count > 0)
            {
                var orderid = Int32.Parse(dgvSaleReport_Order.SelectedRows[0].Cells[0].Value.ToString());                
                if (!bwLoadItems.IsBusy)
                {
                    bwLoadItems.RunWorkerAsync(orderid);
                }
            }
        }

        private void bwLoadItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvSaleReport_Item.DataSource = e.Result as DataTable;
        }

        private void dgvSaleReport_Date_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSaleReport_Date.SelectedRows.Count > 0)
            {
                var date = DateTime.Parse(dgvSaleReport_Date.SelectedRows[0].Cells[0].Value.ToString());
                if (!bwLoadOrder.IsBusy)
                {
                    bwLoadOrder.RunWorkerAsync(date);
                }
            }
        }

        private void bwLoadOrder_DoWork(object sender, DoWorkEventArgs e)
        {
            var date = e.Argument as DateTime?;
            var dt = SPs.SpSaleReport(date, date, "").GetDataSet().Tables[0];
            e.Result = dt;
        }

        private void bwLoadOrder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvSaleReport_Order.DataSource = e.Result as DataTable;
        }

        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSaleReport_Order.SelectedRows.Count > 0)
            {
                var orderid = Int32.Parse(dgvSaleReport_Order.SelectedRows[0].Cells[0].Value.ToString());
                frmPrintOrder frm = new frmPrintOrder(new Order(orderid));
                frm.ShowDialog();
            }
        }

        private void hủyHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSaleReport_Order.SelectedRows.Count > 0)
            {
                var orderid = Int32.Parse(dgvSaleReport_Order.SelectedRows[0].Cells[0].Value.ToString());
                if (MessageBox.Show("Bạn có chắc hủy hóa đơn này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var order = new Order(orderid);
                    order.StatusId = 2;
                    order.Save();
                    btnSaleReport_Search.PerformClick();
                };
            }
        }

        private void btnReportProductSearch_Click(object sender, EventArgs e)
        {
            ReportProductArgument arg = new ReportProductArgument();
            arg.fromDate = dtpProductReportFrom.Value;
            arg.toDate = dtpProductReportTo.Value;
            arg.categoryId = (int) cmbProductReportCategory.SelectedValue;
            if (!bwReportProduct.IsBusy)
            {
                bwReportProduct.RunWorkerAsync(arg);
            }
        }

        private void bwReportProduct_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = e.Argument as ReportProductArgument;
            var dt = SPs.SpSaleReportByProduct(arg.fromDate, arg.toDate, arg.categoryId).GetDataSet().Tables[0];
            e.Result = dt;            
        }

        private void bwReportProduct_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvReportProduct.DataSource = e.Result;
        }

        private void cmbProductReportCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReportProductSearch.PerformClick();
        }

        private void dgvReportProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReportProduct.SelectedRows.Count > 0)
            {
                var productid = Int32.Parse(dgvReportProduct.SelectedRows[0].Cells[0].Value.ToString());
                ReportProductArgument arg = new ReportProductArgument();
                arg.fromDate = dtpProductReportFrom.Value;
                arg.toDate = dtpProductReportTo.Value;
                arg.categoryId = productid;
                if (!bwReportProductDate.IsBusy)
                {
                    bwReportProductDate.RunWorkerAsync(arg);
                }
            }
        }

        private void bwReportProductDate_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = e.Argument as ReportProductArgument;
            var dt = SPs.SpSaleReportByProductDate(arg.fromDate, arg.toDate, arg.categoryId).GetDataSet().Tables[0];
            e.Result = dt;
        }

        private void bwReportProductDate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvReportProductDate.DataSource = e.Result;
        }

        private void bwSaleReport_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (ReportSaleArgument)e.Argument;
            var dt = SPs.SpSaleReportByDate(arg.fromDate, arg.toDate).GetDataSet().Tables[0];
            e.Result = dt;
        }

        private void bwSaleReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var dt = e.Result as DataTable;

            decimal sumProductValue = 0;
            decimal sumShip= 0;
            decimal sumTotal = 0;

            if (dt.Rows.Count > 0)
            {
                sumProductValue = decimal.Parse(dt.Compute("Sum(TotalProductValue)", "").ToString());
                sumShip = decimal.Parse(dt.Compute("Sum(TotalShip)", "").ToString());
                sumTotal = decimal.Parse(dt.Compute("Sum(Total)", "").ToString());
            }

            lblTotalSold.Text = "Tiền hàng: " + sumProductValue.ToString("N0");
            lblTotalShip.Text = "Tiền ship: " + sumShip.ToString("N0");
            lblTotalRevenue.Text = "Tổng doanh thu: " + sumTotal.ToString("N0");

            btnSaleReport_Search.Visible = true;
            pbSaleReport.Visible = false;

            dgvSaleReport_Date.DataSource = dt;
        }

        private void btnCustomerReportSearch_Click(object sender, EventArgs e)
        {
            var dtTotal = SPs.SpSaleReportByCustomer(dtpCustomerReportFrom.Value, dtpCustomerReportTo.Value).GetDataSet().Tables[0];
            dgvCustomerReport_Main.DataSource = dtTotal;
        }

        private void dgvCustomerReport_Main_SelectionChanged(object sender, EventArgs e)
        {
            dgvCustomerReport_Order.DataSource = null;
            dgvCustomerReport_OrderDetail.DataSource = null;                 
            if (dgvCustomerReport_Main.SelectedRows.Count > 0)
            {
                var cusid = int.Parse(dgvCustomerReport_Main.SelectedRows[0].Cells[0].Value.ToString());
                var dtOrder = SPs.SpSaleReportByCustomerOrder(dtpCustomerReportFrom.Value, dtpCustomerReportTo.Value, cusid).GetDataSet().Tables[0];
                dgvCustomerReport_Order.DataSource = dtOrder;
            }
        }

        private void dgvCustomerReport_Order_SelectionChanged(object sender, EventArgs e)
        {
            dgvCustomerReport_OrderDetail.DataSource = null;
            if (dgvCustomerReport_Order.SelectedRows.Count > 0)
            {
                var orderid = int.Parse(dgvCustomerReport_Order.SelectedRows[0].Cells[0].Value.ToString());
                var dt = SPs.SpGetOrderItems(orderid).GetDataSet().Tables[0];
                dgvCustomerReport_OrderDetail.DataSource = dt;
            }
        }
    }
}
