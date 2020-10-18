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

            lblInfo.Text =  "Ngày " + DateTime.Now.Date.Day 
                        +  " Tháng " + DateTime.Now.Month +  " Năm " + DateTime.Now.Year;
        }
    }
}
