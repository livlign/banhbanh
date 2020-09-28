using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace Subsonic2
{
    /// <summary>
    /// Controller class for tblOrderItems
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OrderItemController
    {
        // Preload our schema..
        OrderItem thisSchemaLoad = new OrderItem();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public OrderItemCollection FetchAll()
        {
            OrderItemCollection coll = new OrderItemCollection();
            Query qry = new Query(OrderItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderItemCollection FetchByID(object Id)
        {
            OrderItemCollection coll = new OrderItemCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderItemCollection FetchByQuery(Query qry)
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (OrderItem.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (OrderItem.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? OrderId,int? ProductId,int? Qty,decimal? Price,decimal? Cost,string Note)
	    {
		    OrderItem item = new OrderItem();
		    
            item.OrderId = OrderId;
            
            item.ProductId = ProductId;
            
            item.Qty = Qty;
            
            item.Price = Price;
            
            item.Cost = Cost;
            
            item.Note = Note;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? OrderId,int? ProductId,int? Qty,decimal? Price,decimal? Cost,string Note)
	    {
		    OrderItem item = new OrderItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.OrderId = OrderId;
				
			item.ProductId = ProductId;
				
			item.Qty = Qty;
				
			item.Price = Price;
				
			item.Cost = Cost;
				
			item.Note = Note;
				
	        item.Save(UserName);
	    }
    }
}
