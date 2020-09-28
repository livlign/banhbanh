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

            dgvSaleReport_Order.AutoGenerateColumns = false;
            dgvSaleReport_Item.AutoGenerateColumns = false;
            dgvSaleReport_Date.AutoGenerateColumns = false;
            dtpSaleReport_FromDate.Value = DateTime.Now.AddMonths(-1);
            dtpSaleReport_ToDate.Value = DateTime.Now;

            dgvSaleReport_Order.ContextMenuStrip = cmsOrder;

            dgvVoucherReport_Stat.AutoGenerateColumns = false;
            dgvVoucherReport_Value.AutoGenerateColumns = false;
            dtpVoucherReportFrom.Value = DateTime.Now.AddYears(-1);
            dtpVoucherReportTo.Value = DateTime.Now;

            //Report product
            var listcategory = new CategoryCollection().Where(Category.Columns.Active, true).Load().ToList();
            var c = new Category();
            c.Id = 0;
            c.Name = "Tất cả";
            listcategory.Insert(0, c);
            cmbProductReportCategory.DataSource = listcategory;
            cmbProductReportCategory.DisplayMember = "Name";
            cmbProductReportCategory.ValueMember = "Id";
            cmbProductReportCategory.SelectedIndex = 0;
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

        private void btnVoucherReportSearch_Click(object sender, EventArgs e)
        {
            var dtTotal = SPs.SpVoucherTotal(dtpVoucherReportFrom.Value, dtpVoucherReportTo.Value).GetDataSet().Tables[0];
            var dtStat = SPs.SpVoucherStats(dtpVoucherReportFrom.Value, dtpVoucherReportTo.Value).GetDataSet().Tables[0];

            dgvVoucherReport_Value.DataSource = dtTotal;
            dgvVoucherReport_Stat.DataSource = dtStat;
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

            decimal sumTotal = 0;
            decimal sumCost = 0;
               
            if (dt.Rows.Count > 0)
            {
                sumTotal = decimal.Parse(dt.Compute("Sum(Total)", "").ToString());
                sumCost = decimal.Parse(dt.Compute("Sum(TotalCost)", "").ToString());
            }
            var sumRevenue = sumTotal - sumCost;

            lblTotalSold.Text = "Tổng tiền: " + sumTotal.ToString("N0");
            lblTotalCost.Text = "Tổng nhập: " + sumCost.ToString("N0");
            lblTotalRevenue.Text = "Tổng doanh thu: " + sumRevenue.ToString("N0");

            btnSaleReport_Search.Visible = true;
            pbSaleReport.Visible = false;

            dgvSaleReport_Date.DataSource = dt;
        }
    }
}
