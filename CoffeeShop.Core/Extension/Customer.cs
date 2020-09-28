using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsonic2
{
    public partial class Customer
    {
        [Bindable(true)]
        public string ActiveText
        {
            get
            {
                return this.Active == true ? "Có" : "Không";
            }
        }
        
        [Bindable(true)]
        public string DistrictName
        {
            get
            {
                return new District(this.DistrictId).Name;
            }
        }

        
    }
}
