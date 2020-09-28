using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.FormUI
{
    public partial class frmInputOrderNumber : Form
    {
        public string ordernumber;
        public frmInputOrderNumber()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtOrderNumber.Text != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                ordernumber = txtOrderNumber.Text;
            }            
        }

        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.HandlerIntTextbox(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txtOrderNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }
    }
}
