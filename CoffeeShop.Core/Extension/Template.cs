using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsonic2
{
    public partial class Templates
    {
        private static Template _orderTemp;
        public static Template orderTemp
        {
            get
            {
                if (_orderTemp == null)
                {
                    _orderTemp = new TemplateCollection().Where(Template.Columns.Name, "OrderTemp").Load().FirstOrDefault();
                }
                return _orderTemp;
            }
        }

        private static Template _orderItemTemp;
        public static Template orderItemTemp
        {
            get
            {
                if (_orderItemTemp == null)
                {
                    _orderItemTemp = new TemplateCollection().Where(Template.Columns.Name, "OrderItemTemp").Load().FirstOrDefault();
                }
                return _orderItemTemp;
            }
        }
    }
}
