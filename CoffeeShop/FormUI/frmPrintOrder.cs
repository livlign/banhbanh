using Subsonic2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.FormUI
{
    public partial class frmPrintOrder : Form
    {
        private bool needPrint = false;
        public frmPrintOrder(string path)
        {
            InitializeComponent();
            needPrint = true;
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(path);   

        }

        public frmPrintOrder(Order order)
        {
            InitializeComponent();
            needPrint = false;
            webBrowser1.ScriptErrorsSuppressed = true;
            var ReciptFolder = @"C:/CoffeeShop/Recipt/" + order.DateCreated.Value.Year
                + "/" + order.DateCreated.Value.Month + "/" + order.DateCreated.Value.Day + "/";
            var filename = ReciptFolder + "HoaDon_" + order.OrderRef + ".html";
            webBrowser1.Navigate(filename);         
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (needPrint)
                {
                    webBrowser1.Print();
                    Thread.Sleep(1000);
                    webBrowser1.Print();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteLogError("Error Print: " + ex.Message);
            }
            
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
