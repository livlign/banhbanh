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
    /// Controller class for tblIngredientOrders
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IngredientOrderController
    {
        // Preload our schema..
        IngredientOrder thisSchemaLoad = new IngredientOrder();
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
        public IngredientOrderCollection FetchAll()
        {
            IngredientOrderCollection coll = new IngredientOrderCollection();
            Query qry = new Query(IngredientOrder.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IngredientOrderCollection FetchByID(object Id)
        {
            IngredientOrderCollection coll = new IngredientOrderCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IngredientOrderCollection FetchByQuery(Query qry)
        {
            IngredientOrderCollection coll = new IngredientOrderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (IngredientOrder.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (IngredientOrder.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? UserId,decimal? Total,string Note,DateTime? OrderDate,DateTime? CreatedDate)
	    {
		    IngredientOrder item = new IngredientOrder();
		    
            item.UserId = UserId;
            
            item.Total = Total;
            
            item.Note = Note;
            
            item.OrderDate = OrderDate;
            
            item.CreatedDate = CreatedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? UserId,decimal? Total,string Note,DateTime? OrderDate,DateTime? CreatedDate)
	    {
		    IngredientOrder item = new IngredientOrder();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.UserId = UserId;
				
			item.Total = Total;
				
			item.Note = Note;
				
			item.OrderDate = OrderDate;
				
			item.CreatedDate = CreatedDate;
				
	        item.Save(UserName);
	    }
    }
}
