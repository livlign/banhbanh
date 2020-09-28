using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsonic2
{
    public partial class Voucher
    {
        [Bindable(true)]
        public string ActiveText
        {
            get
            {
                return this.Active == true ? "Có" : "Không";
            }
        }

        public string TypeText
        {
            get
            {
                return this.Type == 0 ? "Phần trăm" : "Tiền mặt"; 
            }
        }
    }
}
