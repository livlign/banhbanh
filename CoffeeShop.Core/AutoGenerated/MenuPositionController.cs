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
    /// Controller class for tblMenuPosition
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MenuPositionController
    {
        // Preload our schema..
        MenuPosition thisSchemaLoad = new MenuPosition();
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
        public MenuPositionCollection FetchAll()
        {
            MenuPositionCollection coll = new MenuPositionCollection();
            Query qry = new Query(MenuPosition.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MenuPositionCollection FetchByID(object Id)
        {
            MenuPositionCollection coll = new MenuPositionCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MenuPositionCollection FetchByQuery(Query qry)
        {
            MenuPositionCollection coll = new MenuPositionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (MenuPosition.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (MenuPosition.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? PositionID,int? MenuItemID,DateTime? DateCreated,int? Active)
	    {
		    MenuPosition item = new MenuPosition();
		    
            item.PositionID = PositionID;
            
            item.MenuItemID = MenuItemID;
            
            item.DateCreated = DateCreated;
            
            item.Active = Active;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? PositionID,int? MenuItemID,DateTime? DateCreated,int? Active)
	    {
		    MenuPosition item = new MenuPosition();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.PositionID = PositionID;
				
			item.MenuItemID = MenuItemID;
				
			item.DateCreated = DateCreated;
				
			item.Active = Active;
				
	        item.Save(UserName);
	    }
    }
}
