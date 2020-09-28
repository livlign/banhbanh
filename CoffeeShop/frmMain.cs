using CoffeeShop.Control;
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
    public partial class frmMain : Form
    {
        HomeControl homeCtr;
        OrderControl orderCtr;
        ListManagerControl listCtr;
        ReportControl reportCtr;
        UtilityControl utilityCtr;
        
        public frmMain()
        {
            InitializeComponent();

            lblUser.Text = Utilities.CurrentUser == null ? "" : "Người dùng: " + Utilities.CurrentUser.FullName;

            mnHome.PerformClick();
        }

        private void mnHome_Click(object sender, EventArgs e)
        {
            MenuSelected((sender as ToolStripMenuItem).Name);
            if (homeCtr == null)
            {
                homeCtr = new HomeControl();
                homeCtr.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(homeCtr);
            }
            homeCtr.BringToFront();
        }

        private void mnOrder_Click(object sender, EventArgs e)
        {
            MenuSelected((sender as ToolStripMenuItem).Name);
            if (orderCtr == null || orderCtr.IsDisposed)
            {
                orderCtr = new OrderControl();
                orderCtr.Dock = DockStyle.Fill;
                if (!orderCtr.IsDisposed)
                {
                    pnlMain.Controls.Add(orderCtr);
                }                
            }
            orderCtr.BringToFront();
        }

        private void MenuSelected(string menu)
        {
            foreach (ToolStripMenuItem item in menuMain.Items)
            {
                if (item.Name == menu)
                    item.BackColor = Color.LightSkyBlue;
                else
                    item.BackColor = Color.DodgerBlue;
            }
        }

        private void mnList_Click(object sender, EventArgs e)
        {
            if (Utilities.CurrentUser.PositionId != 1)
            {
                MessageBox.Show("Bạn không thể truy cập chức năng này");
                return;
            }
            MenuSelected((sender as ToolStripMenuItem).Name);
            if (listCtr == null)
            {
                listCtr = new ListManagerControl();
                listCtr.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(listCtr);
            }
            listCtr.BringToFront();
        }

        private void mnReport_Click(object sender, EventArgs e)
        {
            if (Utilities.CurrentUser.PositionId != 1)
            {
                MessageBox.Show("Bạn không thể truy cập chức năng này");
                return;
            }
            MenuSelected((sender as ToolStripMenuItem).Name);
            if (reportCtr == null)
            {
                reportCtr = new ReportControl();
                reportCtr.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(reportCtr);
            }
            reportCtr.BringToFront();
        }

        private void mnSetting_Click(object sender, EventArgs e)
        {
            if (Utilities.CurrentUser.PositionId != 1)
            {
                MessageBox.Show("Bạn không thể truy cập chức năng này");
                return;
            }
            MenuSelected((sender as ToolStripMenuItem).Name);
            if (utilityCtr == null)
            {
                utilityCtr = new UtilityControl();
                utilityCtr.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(utilityCtr);
            }
            utilityCtr.BringToFront();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát khỏi phần mềm ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
