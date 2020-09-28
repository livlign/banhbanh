using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsonic2
{
    public partial class Category
    {
        [Bindable(true)]
        public string ActiveText
        {
            get
            {
                return this.Active == true ? "Có" : "Không";
            }
        }
    }
}
