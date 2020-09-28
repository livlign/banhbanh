using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Control
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();

            lblMainNote.Text = Utilities.mainNote == null ? "" : Utilities.mainNote.Note;

            label2.Text = "Tổng doanh thu" + Environment.NewLine + "1.000.000";
            label3.Text = "Tổng đơn hàng" + Environment.NewLine + "100";
            label4.Text = "Tổng số khách" + Environment.NewLine + "50";

            label5.Text = "Sản phẩm bán chạy" + Environment.NewLine + "Cà phê đen";
            label6.Text = "Sản phẩm doanh thu" + Environment.NewLine + "Mỳ ý";
            label7.Text = "Sản phẩm hot" + Environment.NewLine + "Cà phê vàng";

            label8.Text = "So với hôm qua" + Environment.NewLine + "10/15";
            label9.Text = "So với tuần trước" + Environment.NewLine + "12/15";
            label10.Text = "So với tháng trước" + Environment.NewLine + "1/15";
        }
    }
}
