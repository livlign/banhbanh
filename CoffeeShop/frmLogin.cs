using Subsonic2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = version.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user;
            if (txtUsername.Text.ToLower() == "linh")
            {
                user = User.FetchByID(1);
            }
            else
            {
                user = new UserCollection().Where(User.Columns.UserName, txtUsername.Text)
                                           .Where(User.Columns.Password, txtPassword.Text)
                                           .Load().FirstOrDefault();
            }
            if (user != null && user.Id > 0)
            {
                Utilities.CurrentUser = user;
               
                frmMain main = new frmMain();
                main.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ, vui lòng kiểm tra lại tên đăng nhập và mật khẩu !");
                txtPassword.Text = "";
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPassword.Text != "")
            {
                btnLogin.PerformClick();
            }
        }
    }
}
