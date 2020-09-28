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
    public partial class UtilityControl : UserControl
    {
        public UtilityControl()
        {
            InitializeComponent();

            txtOrderNote.Text = Utilities.orderNote == null ? "" : Utilities.orderNote.Note;

            txtMainNote.Text = Utilities.mainNote == null ? "" : Utilities.mainNote.Note;
        }

        private void btnSaveOrderNote_Click(object sender, EventArgs e)
        {
            var note = Utilities.orderNote;
            if (note == null || note.Id <= 0)
            {
                note = new OrderNote();
            }
            note.Type = 2;
            note.Note = txtOrderNote.Text;
            note.DateCreated = DateTime.Now;
            note.Save();

            MessageBox.Show("Lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void btnMainNote_Click(object sender, EventArgs e)
        {
            var note = Utilities.mainNote;
            if (note == null || note.Id <= 0)
            {
                note = new OrderNote();
            }
            note.Type = 1;
            note.Note = txtMainNote.Text;
            note.DateCreated = DateTime.Now;
            note.Save();

            MessageBox.Show("Lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }
    }
}
