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
    /// Controller class for tblMenuItems
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MenuItemController
    {
        // Preload our schema..
        MenuItem thisSchemaLoad = new MenuItem();
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
        public MenuItemCollection FetchAll()
        {
            MenuItemCollection coll = new MenuItemCollection();
            Query qry = new Query(MenuItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MenuItemCollection FetchByID(object Id)
        {
            MenuItemCollection coll = new MenuItemCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MenuItemCollection FetchByQuery(Query qry)
        {
            MenuItemCollection coll = new MenuItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (MenuItem.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (MenuItem.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ItemText,string ItemName,DateTime? DateCreated,int? ParentId)
	    {
		    MenuItem item = new MenuItem();
		    
            item.ItemText = ItemText;
            
            item.ItemName = ItemName;
            
            item.DateCreated = DateCreated;
            
            item.ParentId = ParentId;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string ItemText,string ItemName,DateTime? DateCreated,int? ParentId)
	    {
		    MenuItem item = new MenuItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ItemText = ItemText;
				
			item.ItemName = ItemName;
				
			item.DateCreated = DateCreated;
				
			item.ParentId = ParentId;
				
	        item.Save(UserName);
	    }
    }
}
