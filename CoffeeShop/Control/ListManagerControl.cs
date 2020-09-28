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

        bool isEditVoucher = false;
        Voucher _selectedVoucher;
        List<Voucher> listVoucher;

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

        public Voucher selectedVoucher
        {
            get
            {
                if (_selectedVoucher == null)
                {
                    if (dgvVoucher.SelectedRows.Count > 0)
                    {
                        _selectedVoucher = dgvVoucher.SelectedRows[0].DataBoundItem as Voucher;
                    }
                }

                return _selectedVoucher;
            }
            set
            {
                _selectedVoucher = value;
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

            //category
            dgvCategory.AutoGenerateColumns = false;
            CategoryLoadData();
            CategoryButton(false);

            //product
            dgvProduct.AutoGenerateColumns = false;
            ProductButton(false);

            //voucher
            dgvVoucher.AutoGenerateColumns = false;
            VoucherLoadData();
            VoucherButton(false);            
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

        #region Voucher
        private void VoucherLoadData()
        {
            listVoucher = new VoucherCollection().Load().OrderByDescending(c=>c.DateCreated).OrderByDescending(c=>c.Active).ToList();
            dgvVoucher.DataSource = listVoucher;
        }
        private void VoucherButton(bool IsEdit)
        {
            pnlVoucher.Enabled = IsEdit;
            btnVoucherAdd.Visible = !IsEdit;
            btnVoucherEdit.Visible = !IsEdit;
            btnVoucherSave.Visible = IsEdit;
            btnVoucherCancel.Visible = IsEdit;
            dgvVoucher.Enabled = !isEdit;
        }

        private void VoucherResetText()
        {
            txtVoucherCode.Text = "";
            txtVoucherValue.Text = "";
            cmbVoucherType.SelectedIndex = 0;
            dtpVoucherDateActive.Value = DateTime.Now;
            dtpVoucherDateActive.Checked = false;
            dtpVoucherDateExpire.Value = DateTime.Now;
            dtpVoucherDateExpire.Checked = false;
            chkVoucherActive.Checked = true;
            txtVoucherCode.Focus();
        }
        private void txtVoucherValue_TextChanged(object sender, EventArgs e)
        {
            Utilities.FormatMoney(sender);
        }
        #endregion

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.HandlerIntTextbox(e);
        }

        private void dgvVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVoucher.SelectedRows.Count > 0)
            {
                selectedVoucher = dgvVoucher.SelectedRows[0].DataBoundItem as Voucher;

                txtVoucherCode.Text = selectedVoucher.VoucherCode;
                txtVoucherValue.Text = string.Format("{0:N0}", selectedVoucher.ValueX);
                cmbVoucherType.SelectedIndex = (int)selectedVoucher.Type;
                if (selectedVoucher.DateActive != null && selectedVoucher.DateActive >= new DateTime(2016,1,1))
                {
                    dtpVoucherDateActive.Checked = true;
                    dtpVoucherDateActive.Value = selectedVoucher.DateActive.Value;
                }
                if (selectedVoucher.DateExpire != null && selectedVoucher.DateExpire >= new DateTime(2017, 1, 1))
                {
                    dtpVoucherDateExpire.Checked = true;
                    dtpVoucherDateExpire.Value = selectedVoucher.DateExpire.Value;
                }
                chkVoucherActive.Checked = (bool)selectedVoucher.Active;
            }
        }

        private void btnVoucherAdd_Click(object sender, EventArgs e)
        {
            VoucherButton(true);
            txtVoucherCode.Focus();
            chkVoucherActive.Checked = true;
            isEditVoucher = false;
            VoucherResetText();
        }

        private void btnVoucherCancel_Click(object sender, EventArgs e)
        {
            VoucherButton(false);
            VoucherResetText();
        }

        private void btnVoucherSave_Click(object sender, EventArgs e)
        {
            if (txtVoucherCode.Text == "")
            {
                MessageBox.Show("Mã giảm giá không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVoucherCode.Focus();
                return;
            }
            
            if (txtVoucherValue.Text == "")
            {
                MessageBox.Show("Giá trị không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVoucherValue.Focus();
                return;
            }

            var p = new Voucher();
            var needCheckCode = true;
            if (isEditVoucher)
            {
                p = selectedVoucher;
                needCheckCode = false;

                if (txtVoucherCode.Text != p.VoucherCode)
                    needCheckCode = true;
            }
            
            if(needCheckCode)
            {
                var voucher = new Voucher(Voucher.Columns.VoucherCode, txtVoucherCode.Text);
                if (voucher != null && voucher.Id > 0)
                {
                    MessageBox.Show("Mã giảm giá này đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductCode.Focus();
                    return;
                }
            }

            p.VoucherCode = txtVoucherCode.Text;
            p.ValueX = decimal.Parse(txtVoucherValue.Text);
            p.Type = cmbVoucherType.SelectedIndex;
            if (dtpVoucherDateActive.Checked)
                p.DateActive = dtpVoucherDateActive.Value;
            else
                p.DateActive = new DateTime(2016,1,1);

            if (dtpVoucherDateExpire.Checked)
                p.DateExpire = dtpVoucherDateExpire.Value;
            else
                p.DateExpire = new DateTime(2099, 1, 1);

            p.Active = chkVoucherActive.Checked;
            
            if (!isEditVoucher)
                p.DateCreated = DateTime.Now;

            p.Save();
            VoucherLoadData();

            if (MessageBox.Show("Thêm mã giảm giá thành công, bạn có muốn thêm nữa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                VoucherResetText();
            }
            else
            {
                VoucherResetText();
                VoucherButton(false);
            }
        }

        private void btnVoucherEdit_Click(object sender, EventArgs e)
        {
            if (selectedVoucher == null)
            {
                MessageBox.Show("Chưa chọn mã giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VoucherButton(true);
            isEditVoucher = true;
        }

        


    }
}
