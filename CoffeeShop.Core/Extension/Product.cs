using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsonic2
{
    public partial class Product
    {
        [Bindable(true)]
        public string ActiveText
        {
            get
            {
                return this.Active == true ? "Có" : "Không";
            }
        }

        public string IdName
        {
            get
            {
                return this.ProductCode + " - " + this.ProductName;
            }
        }
    }
}
