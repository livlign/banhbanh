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
using CoffeeShop.Core.Extension;

namespace CoffeeShop.Control
{
    public partial class OrderControl : UserControl
    {
        List<Product> ListProduct;
        List<TempOrderItem> ListTempItem;

        public OrderControl()
        {
            InitializeComponent();

            ListTempItem = new List<TempOrderItem>();
            dgvOrderItem.AutoGenerateColumns = false;

            dgvCategory.AutoGenerateColumns = false;
            var listCategory = new CategoryCollection().Where(Category.Columns.Active, true).Load();
            dgvCategory.DataSource = listCategory;
           
            ListProduct = new ProductCollection().Where(Product.Columns.Active, true).Load().ToList();
            cmbSearch.DataSource = ListProduct;
            cmbSearch.DisplayMember = "IdName";
            cmbSearch.ValueMember = "Id";
            cmbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSearch.AutoCompleteSource = AutoCompleteSource.ListItems;

            txtOrderNote.Text = Utilities.orderNote == null ? "" : Utilities.orderNote.Note;

            if (txtOrderNumber.Text == "")
            {
                DialogOrderNumber();
            }
        }

        public void DialogOrderNumber()
        {
            frmInputOrderNumber frm = new frmInputOrderNumber();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                txtOrderNumber.Text = frm.ordernumber;
                cmbSearch.Focus();
            }
            else
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// Tạo phím tắt
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                btnConfirm.PerformClick();
            }
            if (keyData == (Keys.Escape))
            {
                btnCancel.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                lvProduct.Items.Clear();
                var category = dgvCategory.SelectedRows[0].DataBoundItem as Category;
                var listProduct = new ProductCollection().Where(Product.Columns.CategoryId, category.Id)
                                                    .Where(Product.Columns.Active, true).Load();
                foreach (var item in listProduct)
                {
                    lvProduct.Items.Add(item.ProductCode + "." + item.ProductName, 0);
                }
            }
        }

        private void lvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count > 0)
            {
                var item = lvProduct.SelectedItems[0];
                var productcode = item.Text.Split('.')[0].Trim();
                var product = new ProductCollection()
                    .Where(Product.Columns.ProductCode, productcode)
                    .Where(Product.Columns.Active, true).Load().FirstOrDefault();
                AddProduct(product);
            }
        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            if (txtOrderNumber.Text == "")
            {
                MessageBox.Show("Chưa nhập số bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOrderNumber.Focus();
                return;
            }
            if (ListTempItem.Count <= 0)
            {                
                //MessageBox.Show("Chưa chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            ConfirmOrder c = new ConfirmOrder(txtOrderNumber.Text,txtNote.Text,ListTempItem);

            if (c.ShowDialog() == DialogResult.OK)
                ResetAllText();
        }

        private void cmbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbSearch.SelectedItem != null)
                {
                    var selectedProduct = cmbSearch.SelectedItem as Product;
                    AddProduct(selectedProduct);
                }
            }
        }

        private void LoadItem()
        {
            dgvOrderItem.DataSource = null;
            dgvOrderItem.Rows.Clear();
            dgvOrderItem.Refresh();

            dgvOrderItem.DataSource = ListTempItem;
            
            lblTotal.Text = ListTempItem == null ? "" : ListTempItem.Sum(c => c.TotalPrice).ToString("N0");
        }

        private void dgvOrderItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            LoadItem();
        }

        private void AddProduct(Product product)
        {
            var check = ListTempItem.Where(c => c.ProductId == product.Id).FirstOrDefault();
            if (check != null)
            {
                check.Qty = check.Qty + 1;
            }
            else
            {
                var item = new TempOrderItem();
                item.ProductName = product.ProductName;
                item.ProductId = product.Id;
                item.Price = (decimal)product.Price;
                item.Cost = (decimal)product.Cost;
                item.Qty = 1;
                ListTempItem.Add(item);
            }

            LoadItem();
        }

        private void dgvOrderItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                if (MessageBox.Show("Xóa sản phẩm này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var item = dgvOrderItem.Rows[e.RowIndex].DataBoundItem as TempOrderItem;
                    ListTempItem.Remove(item);
                    LoadItem();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn hủy ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetAllText();
            }
        }

        private void ResetAllText()
        {
            ListTempItem.Clear();
            txtOrderNumber.Text = "";
            txtNote.Text = "";
            lblTotal.Text = "";
            LoadItem();
            txtOrderNumber.Focus();

            DialogOrderNumber();
        }

        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.HandlerIntTextbox(e);
        }

        private void OrderControl_Load(object sender, EventArgs e)
        {
            cmbSearch.Focus();
        }
    }
}
