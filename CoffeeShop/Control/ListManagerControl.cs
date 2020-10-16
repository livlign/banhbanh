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
using CoffeeShop.Core.Extension;

namespace CoffeeShop.Control
{
    public partial class ListManagerControl : UserControl
    {
        bool isEdit = false;
        Customer _selectedCustomer;
        List<Customer> listCustomers;

        bool isEditCategory = false;
        Category _selectedCategory;
        List<Category> listCategory;

        bool isEditProduct = false;
        Product _selectedProduct;
        List<Product> listProduct;

        bool isEditIngredient = false;
        Ingredient _selectedIngredient;
        List<Ingredient> listIngredient;
        List<TempIngredient> listImportTemp;

        public Customer selectedCustomer
        {
            get
            {
                if (_selectedCustomer == null)
                {
                    if (dgvCustomer.SelectedRows.Count > 0)
                    {
                        _selectedCustomer = dgvCustomer.SelectedRows[0].DataBoundItem as Customer;
                    }
                }

                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
            }
        }

        public Category selectedCategory
        {
            get
            {
                if (_selectedCategory == null)
                {
                    if (dgvCategory.SelectedRows.Count > 0)
                    {
                        _selectedCategory = dgvCategory.SelectedRows[0].DataBoundItem as Category;
                    }
                }

                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
            }
        }

        public Product selectedProduct
        {
            get
            {
                if (_selectedProduct == null)
                {
                    if (dgvProduct.SelectedRows.Count > 0)
                    {
                        _selectedProduct = dgvProduct.SelectedRows[0].DataBoundItem as Product;
                    }
                }

                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
            }
        }

        public Ingredient selectedIngredient
        {
            get
            {
                if (_selectedIngredient == null)
                {
                    if (dgvIngredient.SelectedRows.Count > 0)
                    {
                        _selectedIngredient = dgvIngredient.SelectedRows[0].DataBoundItem as Ingredient;
                    }
                }

                return _selectedIngredient;
            }
            set
            {
                _selectedIngredient = value;
            }
        }

        public ListManagerControl()
        {
            InitializeComponent();

            //customer
            dgvCustomer.AutoGenerateColumns = false;
            CustomerLoadData();

            var listDistrict = new DistrictCollection().Load();
            cmbDistrict.ValueMember = District.Columns.Id;
            cmbDistrict.DisplayMember = District.Columns.Name;
            cmbDistrict.DataSource = listDistrict;
            cmbDistrict.SelectedIndex = 0;

            CustomerButton(false);

            //import
            dgvImportList.AutoGenerateColumns = false;
            dgvImportTemp.AutoGenerateColumns = false;
            dgvImportOrder.AutoGenerateColumns = false;
            dgvImportOrderItem.AutoGenerateColumns = false;

            listImportTemp = new List<TempIngredient>();
            dtpImportOrderFrom.Value = DateTime.Now.AddMonths(-1);
            dtpImportOrderTo.Value = DateTime.Now;
            LoadImportOrder();

            //category
            dgvCategory.AutoGenerateColumns = false;
            CategoryLoadData();
            CategoryButton(false);

            //product
            dgvProduct.AutoGenerateColumns = false;
            ProductButton(false);

            //ingredient
            dgvIngredient.AutoGenerateColumns = false;
            IngredientLoadData();
            IngredientButton(false);
        }

        #region Customer
        private void CustomerLoadData()
        {
            //User tab
            listCustomers = new CustomerCollection().Load().ToList();
            dgvCustomer.DataSource = listCustomers;
        }

        private void CustomerButton(bool IsEdit)
        {
            grpCustomerInfo.Enabled = IsEdit;
            btnCustomerAdd.Visible = !IsEdit;
            btnCustomerEdit.Visible = !IsEdit;
            btnCustomerSave.Visible = IsEdit;
            btnCustomerCancel.Visible = IsEdit;
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            CustomerButton(true);            
            txtName.Focus();
            chkEnable.Checked = true;
            isEdit = false;
            CustomerResetText();
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                selectedCustomer = dgvCustomer.SelectedRows[0].DataBoundItem as Customer;

                txtName.Text = selectedCustomer.Name;
                txtPhone.Text = selectedCustomer.Phone;
                chkEnable.Checked = (bool)selectedCustomer.Active;
                cmbDistrict.SelectedValue = selectedCustomer.DistrictId;
                txtAddress.Text = selectedCustomer.Address;
            }            
        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Chưa chọn khách hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CustomerButton(true);
            isEdit = true;
        }

        private void CustomerResetText()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            chkEnable.Checked = true;
            cmbDistrict.SelectedIndex = 0;
            txtName.Focus();
        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            CustomerButton(false);
            CustomerResetText();
        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Tên khách hàng không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = new Customer();
            if (isEdit)
            {
                customer = selectedCustomer;
            }
            customer.Name = txtName.Text;
            customer.Phone = txtPhone.Text;
            customer.DistrictId = (int)cmbDistrict.SelectedValue;
            customer.Address = txtAddress.Text;
            customer.Active = chkEnable.Checked;
            customer.Save();
            CustomerLoadData();

            if (MessageBox.Show("Thêm khách hàng thành công, bạn có muốn thêm nữa ?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CustomerResetText();
            }
            else
            {
                CustomerResetText();
                CustomerButton(false);
            }
        }

        private void txtCustomerSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listdata = listCustomers;
                if (txtCustomerSearch.Text != "")
                {
                    listdata = listCustomers.Where(c => c.Name.ToLower().Contains(txtCustomerSearch.Text.ToLower()) || c.Phone.Contains(txtCustomerSearch.Text))
                               .ToList();
                }
                dgvCustomer.DataSource = listdata;
            }
        }

        #endregion

        #region Category
        private void CategoryLoadData()
        {
            listCategory = new CategoryCollection().Load().ToList();
            Category all = new Category(0);
            all.Name = "TÁT CẢ";
            all.Active = true;
            listCategory.Insert(0, all);
            dgvCategory.DataSource = listCategory;
        }
        private void CategoryButton(bool IsEdit)
        {
            pnlCategoryInfo.Enabled = IsEdit;
            btnCategoryAdd.Visible = !IsEdit;
            btnCategoryEdit.Visible = !IsEdit;
            btnCategorySave.Visible = IsEdit;
            btnCategoryCancel.Visible = IsEdit;
        }
        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                selectedCategory = dgvCategory.SelectedRows[0].DataBoundItem as Category;

                txtCategoryName.Text = selectedCategory.Name;
                txtCategoryDescription.Text = selectedCategory.Description;
                chkCategoryActive.Checked = (bool)selectedCategory.Active;

                txtProductCategory.Text = selectedCategory.Name;
                ProductLoadData();
            }
        }
        private void CategoryResetText()
        {
            txtCategoryName.Text = "";
            txtCategoryDescription.Text = "";
            chkCategoryActive.Checked = true;
            txtCategoryName.Focus();
        }

        private void btnCategoryEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null || selectedCategory.Id == 0)
            {
                MessageBox.Show("Chưa chọn nhóm sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CategoryButton(true);
            isEditCategory = true;
        }
        private void btnCategoryCancel_Click(object sender, EventArgs e)
        {
            CategoryButton(false);
            CategoryResetText();
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            CategoryButton(true);
            txtCategoryName.Focus();
            chkCategoryActive.Checked = true;
            isEditCategory = false;
            CategoryResetText();
        }
        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Tên nhóm sản phẩm không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cat = new Category();
            if (isEditCategory)
            {
                cat = selectedCategory;
            }
            cat.Name = txtCategoryName.Text;
            cat.Description = txtCategoryDescription.Text;
            cat.Active = chkCategoryActive.Checked;
            if(!isEditCategory)
                cat.DateAdded = DateTime.Now;
            cat.Save();
            CategoryLoadData();

            if (MessageBox.Show("Thêm nhóm sản phẩm thành công, bạn có muốn thêm nữa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CategoryResetText();
            }
            else
            {
                CategoryResetText();
                CategoryButton(false);
            }
        }
        private void txtCategorySearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listdata = listCategory;
                if (txtCustomerSearch.Text != "")
                {
                    listdata = listCategory.Where(c => c.Name.Contains(txtCategorySearch.Text))
                               .ToList();
                }
                dgvCategory.DataSource = listdata;
            }
        }
        #endregion

        #region Product
        private void ProductLoadData()
        {
            listProduct = new ProductCollection().Load().ToList();
            if (selectedCategory.Id > 0)
            {
                listProduct = listProduct.Where(c=>c.CategoryId == selectedCategory.Id).ToList();
            }
                
            dgvProduct.DataSource = listProduct.OrderBy(c=>c.ProductCode).ToList();
        }
        private void ProductButton(bool IsEdit)
        {
            pnlProductInfo.Enabled = IsEdit;
            btnProductAdd.Visible = !IsEdit;
            btnProductEdit.Visible = !IsEdit;
            btnProductSave.Visible = IsEdit;
            btnProductCancel.Visible = IsEdit;
            dgvCategory.Enabled = !isEdit;
        }
        private void ProductResetText()
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            txtProductDescription.Text = "";
            txtProductPrice.Text = "";
            txtWeight.Text = "";
            chkProductActive.Checked = true;
            txtProductCode.Focus();
        }
        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null || selectedCategory.Id == 0)
            {
                MessageBox.Show("Chưa chọn nhóm sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProductButton(true);
            txtProductCode.Focus();
            chkProductActive.Checked = true;
            isEditProduct = false;
            ProductResetText();
        }
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                selectedProduct = dgvProduct.SelectedRows[0].DataBoundItem as Product;

                txtProductCode.Text = selectedProduct.ProductCode;
                txtProductName.Text = selectedProduct.ProductName;
                txtProductDescription.Text = selectedProduct.Description;
                txtWeight.Text = selectedProduct.Weight;
                txtProductPrice.Text = string.Format("{0:N0}",selectedProduct.Price);                    
                chkProductActive.Checked = (bool)selectedProduct.Active;
            }
        }

        private void btnProductCancel_Click(object sender, EventArgs e)
        {
            ProductButton(false);
            ProductResetText();
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Chưa chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ProductButton(true);
            isEditProduct = true;
        }
        private void txtProductSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listdata = listProduct;
                if (txtCustomerSearch.Text != "")
                {
                    listdata = listProduct.Where(c => c.ProductName.Contains(txtProductSearch.Text))
                               .ToList();
                }
                dgvProduct.DataSource = listdata;
            }
        }
        private void btnProductSave_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text == "")
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductCode.Focus();
                return;
            }
            if (txtProductName.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName.Focus();
                return;
            }
            if (txtProductPrice.Text == "")
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductPrice.Focus();
                return;
            }

            var p = new Product();
            if (isEditProduct)
            {
                p = selectedProduct;
            }
            else
            {
                var product = new Product(Product.Columns.ProductCode, txtProductCode.Text);
                if (product != null && product.Id > 0)
                {
                    MessageBox.Show("Mã sản phẩm này đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Focus();
                    return;
                }
            }

            p.ProductCode = txtProductCode.Text;
            p.ProductName = txtProductName.Text;
            p.Description = txtProductDescription.Text;
            p.Price = txtProductPrice.Text == "" ? 0 : decimal.Parse(txtProductPrice.Text);
            p.Weight = txtWeight.Text;
            p.Active = chkProductActive.Checked;
            p.CategoryId = selectedCategory.Id;
            if (!isEditProduct)
                p.DateAdded = DateTime.Now;
            p.Save();
            ProductLoadData();

            if (MessageBox.Show("Thêm sản phẩm thành công, bạn có muốn thêm nữa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isEditProduct = false;
                ProductResetText();
            }
            else
            {
                ProductResetText();
                ProductButton(false);
            }
        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            Utilities.FormatMoney(sender);
        }

        #endregion

        #region Ingredient
        private void IngredientLoadData()
        {
            listIngredient = new IngredientCollection().Load().OrderByDescending(c=>c.Active).ToList();
            dgvIngredient.DataSource = listIngredient;
            dgvImportList.DataSource = listIngredient;
        }
        private void IngredientButton(bool IsEdit)
        {
            pnlIngredient.Enabled = IsEdit;
            btnIngredientAdd.Visible = !IsEdit;
            btnIngredientEdit.Visible = !IsEdit;
            btnIngredientSave.Visible = IsEdit;
            btnIngredientCancel.Visible = IsEdit;
            dgvIngredient.Enabled = !isEdit;
        }

        private void IngredientResetText()
        {
            txtIngredientName.Text = "";
            txtIngredientPrice.Text = "";
            txtIngredientUnit.Text = "";
            chkIngredientActive.Checked = true;
            txtIngredientName.Focus();
        }

        private void dgvIngredient_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIngredient.SelectedRows.Count > 0)
            {
                selectedIngredient = dgvIngredient.SelectedRows[0].DataBoundItem as Ingredient;

                txtIngredientName.Text = selectedIngredient.Name;
                txtIngredientPrice.Text = string.Format("{0:N0}", selectedIngredient.Price);
                txtIngredientUnit.Text = selectedIngredient.Unit;
                chkIngredientActive.Checked = (bool)selectedIngredient.Active;
            }
        }

        private void btnIngredientSave_Click(object sender, EventArgs e)
        {
            if (txtIngredientName.Text == "")
            {
                MessageBox.Show("Tên nguyên liệu không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ingredient = new Ingredient();
            if (isEditIngredient)
            {
                ingredient = selectedIngredient;
            }
            ingredient.Name = txtIngredientName.Text;
            ingredient.Price = txtIngredientPrice.Text == "" ? 0 : decimal.Parse(txtIngredientPrice.Text);
            ingredient.Unit = txtIngredientUnit.Text;
            ingredient.Active = chkIngredientActive.Checked;
            ingredient.Save();
            IngredientLoadData();

            if (MessageBox.Show("Thêm nguyên liệu thành công, bạn có muốn thêm nữa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IngredientResetText();
            }
            else
            {
                IngredientResetText();
                IngredientButton(false);
            }
        }

        private void btnIngredientEdit_Click(object sender, EventArgs e)
        {
            if (selectedIngredient == null)
            {
                MessageBox.Show("Chưa chọn nguyên liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            IngredientButton(true);
            isEditIngredient = true;
        }

        private void btnIngredientCancel_Click(object sender, EventArgs e)
        {
            IngredientButton(false);
            IngredientResetText();
        }

        private void btnIngredientAdd_Click(object sender, EventArgs e)
        {
            IngredientButton(true);
            txtIngredientName.Focus();
            chkIngredientActive.Checked = true;
            isEditIngredient = false;
            IngredientResetText();
        }

        private void txtIngredientPrice_TextChanged(object sender, EventArgs e)
        {
            Utilities.FormatMoney(sender);
        }
        #endregion

        #region Import
        private void dgvImportList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var selectedIngredient = dgvImportList.Rows[e.RowIndex].DataBoundItem as Ingredient;
                var check = listImportTemp.FirstOrDefault(c => c.Id == selectedIngredient.Id);
                if (check == null || check.Id <= 0)
                {
                    var temp = new TempIngredient();
                    temp.Id = selectedIngredient.Id;
                    temp.Name = selectedIngredient.Name;
                    temp.Unit = selectedIngredient.Unit;
                    temp.Price = (decimal)selectedIngredient.Price;
                    temp.Quantity = 1;
                    listImportTemp.Add(temp);
                }
                else
                {
                    check.Quantity += 1;
                }
                LoadItemImport();
            }
        }

        public void LoadItemImport()
        {
            dgvImportTemp.DataSource = null;
            dgvImportTemp.Rows.Clear();
            dgvImportTemp.Refresh();

            dgvImportTemp.DataSource = listImportTemp;

            if (listImportTemp != null)
            {
                lblImportTotal.Text = "Tổng tiền: " + string.Format("{0:N0}", listImportTemp.Sum(c => c.Total));
            }
        }

        private void btnImportCancel_Click(object sender, EventArgs e)
        {
            ImportResetText();
        }

        private void ImportResetText()
        {
            dtpImportDate.Value = DateTime.Now;
            txtImportNote.Text = "";
            listImportTemp = new List<TempIngredient>();
            LoadItemImport();
        }

        private void dgvImportTemp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            LoadItemImport();
        }

        private void dgvImportTemp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var removeIngredient = dgvImportTemp.Rows[e.RowIndex].DataBoundItem as TempIngredient;
                listImportTemp.Remove(removeIngredient);
                LoadItemImport();
            }
        }

        private void btnImportSave_Click(object sender, EventArgs e)
        {
            if (listImportTemp.Count == 0) return;

            IngredientOrder order = new IngredientOrder();
            order.UserId = Utilities.CurrentUser.Id;
            order.OrderDate = dtpImportDate.Value;
            order.CreatedDate = DateTime.Now;
            order.Total = listImportTemp.Sum(c => c.Total);
            order.Note = txtImportNote.Text;
            order.Save();

            foreach (var ingredient in listImportTemp)
            {
                IngredientOrderItem item = new IngredientOrderItem();
                item.OrderId = order.Id;
                item.IngredientId = ingredient.Id;
                item.Quantity = ingredient.Quantity;
                item.Total = ingredient.Total;
                item.Save();
            }
            ImportResetText();
            LoadImportOrder();
        }

        private void btnImportSearchOrder_Click(object sender, EventArgs e)
        {
            LoadImportOrder();
        }

        private void LoadImportOrder()
        {
            var list = SPs.SpImportOrder(dtpImportOrderFrom.Value, dtpImportOrderTo.Value).GetDataSet().Tables[0];
            dgvImportOrder.DataSource = list;
        }

        private void dgvImportOrder_SelectionChanged(object sender, EventArgs e)
        {
            dgvImportOrderItem.DataSource = null;
            if (dgvImportOrder.SelectedRows.Count > 0)
            {
                var orderid = int.Parse(dgvImportOrder.SelectedRows[0].Cells[0].Value.ToString());
                var dt = SPs.SpImportOrderItem(orderid).GetDataSet().Tables[0];
                dgvImportOrderItem.DataSource = dt;
            }
        }

        #endregion

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.HandlerIntTextbox(e);
        }

        private void dgvImportOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {                
                if (MessageBox.Show("Xóa hóa đơn này?","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var orderid = int.Parse(dgvImportOrder.Rows[e.RowIndex].Cells[0].Value.ToString());
                    IngredientOrder.Delete(orderid);
                    IngredientOrderItem.Delete(IngredientOrderItem.Columns.OrderId, orderid);
                    LoadImportOrder();
                }
            }
        }
    }
}
