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
    /// Controller class for tblOrders
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OrderController
    {
        // Preload our schema..
        Order thisSchemaLoad = new Order();
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
        public OrderCollection FetchAll()
        {
            OrderCollection coll = new OrderCollection();
            Query qry = new Query(Order.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderCollection FetchByID(object Id)
        {
            OrderCollection coll = new OrderCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrderCollection FetchByQuery(Query qry)
        {
            OrderCollection coll = new OrderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Order.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Order.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string OrderRef,string OrderNumber,int? CustomerID,decimal? ValueX,decimal? Discount,int? DiscountType,decimal? AddonDiscount,decimal? TotalCost,decimal? TotalValue,string VoucherCode,DateTime? DateCreated,int? UserId,int? StatusId,int? PromoId,string Note,decimal? ShipCost,DateTime? ShipDate)
	    {
		    Order item = new Order();
		    
            item.OrderRef = OrderRef;
            
            item.OrderNumber = OrderNumber;
            
            item.CustomerID = CustomerID;
            
            item.ValueX = ValueX;
            
            item.Discount = Discount;
            
            item.DiscountType = DiscountType;
            
            item.AddonDiscount = AddonDiscount;
            
            item.TotalCost = TotalCost;
            
            item.TotalValue = TotalValue;
            
            item.VoucherCode = VoucherCode;
            
            item.DateCreated = DateCreated;
            
            item.UserId = UserId;
            
            item.StatusId = StatusId;
            
            item.PromoId = PromoId;
            
            item.Note = Note;
            
            item.ShipCost = ShipCost;
            
            item.ShipDate = ShipDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string OrderRef,string OrderNumber,int? CustomerID,decimal? ValueX,decimal? Discount,int? DiscountType,decimal? AddonDiscount,decimal? TotalCost,decimal? TotalValue,string VoucherCode,DateTime? DateCreated,int? UserId,int? StatusId,int? PromoId,string Note,decimal? ShipCost,DateTime? ShipDate)
	    {
		    Order item = new Order();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.OrderRef = OrderRef;
				
			item.OrderNumber = OrderNumber;
				
			item.CustomerID = CustomerID;
				
			item.ValueX = ValueX;
				
			item.Discount = Discount;
				
			item.DiscountType = DiscountType;
				
			item.AddonDiscount = AddonDiscount;
				
			item.TotalCost = TotalCost;
				
			item.TotalValue = TotalValue;
				
			item.VoucherCode = VoucherCode;
				
			item.DateCreated = DateCreated;
				
			item.UserId = UserId;
				
			item.StatusId = StatusId;
				
			item.PromoId = PromoId;
				
			item.Note = Note;
				
			item.ShipCost = ShipCost;
				
			item.ShipDate = ShipDate;
				
	        item.Save(UserName);
	    }
    }
}
