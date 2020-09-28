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
    /// Controller class for tblPaymentHistorys
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PaymentHistoryController
    {
        // Preload our schema..
        PaymentHistory thisSchemaLoad = new PaymentHistory();
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
        public PaymentHistoryCollection FetchAll()
        {
            PaymentHistoryCollection coll = new PaymentHistoryCollection();
            Query qry = new Query(PaymentHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PaymentHistoryCollection FetchByID(object Id)
        {
            PaymentHistoryCollection coll = new PaymentHistoryCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PaymentHistoryCollection FetchByQuery(Query qry)
        {
            PaymentHistoryCollection coll = new PaymentHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PaymentHistory.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PaymentHistory.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? OrderId,decimal? ValueX,int? TypeId,int? UserId,DateTime? DateCreated)
	    {
		    PaymentHistory item = new PaymentHistory();
		    
            item.OrderId = OrderId;
            
            item.ValueX = ValueX;
            
            item.TypeId = TypeId;
            
            item.UserId = UserId;
            
            item.DateCreated = DateCreated;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? OrderId,decimal? ValueX,int? TypeId,int? UserId,DateTime? DateCreated)
	    {
		    PaymentHistory item = new PaymentHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.OrderId = OrderId;
				
			item.ValueX = ValueX;
				
			item.TypeId = TypeId;
				
			item.UserId = UserId;
				
			item.DateCreated = DateCreated;
				
	        item.Save(UserName);
	    }
    }
}
