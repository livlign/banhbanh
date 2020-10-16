using Subsonic2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.FormUI
{
    public partial class frmPrintOrder : Form
    {
        public frmPrintOrder(string path)
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(path);   
        }

        public frmPrintOrder(Order order)
        {
            InitializeComponent();

            string template = Templates.banhbanhTemp.TemplateText;

            var data = SPs.SpPrintOrder(order.Id).GetDataSet().Tables[0];

            var summary = "Giá: " + order.ValueX.Value.ToString("n0")
                        + " - Ship: " + order.ShipCost.Value.ToString("n0")
                        + " - Thành tiền: " + order.TotalValue.Value.ToString("n0")
                        + " - Note: " + order.Note;

            template = template.Replace("<orderref>", data.Rows[0]["OrderRef"].ToString())
                               .Replace("<name>", data.Rows[0]["Name"].ToString())
                               .Replace("<phone>", data.Rows[0]["Phone"].ToString())
                               .Replace("<address>", data.Rows[0]["Address"].ToString())
                               .Replace("<item>", data.Rows[0]["Product"].ToString())
                               .Replace("<summary>", summary);
            webBrowser1.DocumentText = template;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }
    }
}
