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
    /// Controller class for tblProducts
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductController
    {
        // Preload our schema..
        Product thisSchemaLoad = new Product();
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
        public ProductCollection FetchAll()
        {
            ProductCollection coll = new ProductCollection();
            Query qry = new Query(Product.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByID(object Id)
        {
            ProductCollection coll = new ProductCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByQuery(Query qry)
        {
            ProductCollection coll = new ProductCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Product.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Product.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? CategoryId,string ProductCode,string ProductName,string Description,decimal? Price,decimal? Cost,string Weight,DateTime? DateAdded,string Image,bool? Active)
	    {
		    Product item = new Product();
		    
            item.CategoryId = CategoryId;
            
            item.ProductCode = ProductCode;
            
            item.ProductName = ProductName;
            
            item.Description = Description;
            
            item.Price = Price;
            
            item.Cost = Cost;
            
            item.Weight = Weight;
            
            item.DateAdded = DateAdded;
            
            item.Image = Image;
            
            item.Active = Active;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int? CategoryId,string ProductCode,string ProductName,string Description,decimal? Price,decimal? Cost,string Weight,DateTime? DateAdded,string Image,bool? Active)
	    {
		    Product item = new Product();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.CategoryId = CategoryId;
				
			item.ProductCode = ProductCode;
				
			item.ProductName = ProductName;
				
			item.Description = Description;
				
			item.Price = Price;
				
			item.Cost = Cost;
				
			item.Weight = Weight;
				
			item.DateAdded = DateAdded;
				
			item.Image = Image;
				
			item.Active = Active;
				
	        item.Save(UserName);
	    }
    }
}
