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
    /// Controller class for tblVouchers
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class VoucherController
    {
        // Preload our schema..
        Voucher thisSchemaLoad = new Voucher();
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
        public VoucherCollection FetchAll()
        {
            VoucherCollection coll = new VoucherCollection();
            Query qry = new Query(Voucher.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public VoucherCollection FetchByID(object Id)
        {
            VoucherCollection coll = new VoucherCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public VoucherCollection FetchByQuery(Query qry)
        {
            VoucherCollection coll = new VoucherCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Voucher.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Voucher.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string VoucherCode,decimal? ValueX,int? Type,DateTime? DateActive,DateTime? DateExpire,DateTime? DateCreated,bool? Active)
	    {
		    Voucher item = new Voucher();
		    
            item.VoucherCode = VoucherCode;
            
            item.ValueX = ValueX;
            
            item.Type = Type;
            
            item.DateActive = DateActive;
            
            item.DateExpire = DateExpire;
            
            item.DateCreated = DateCreated;
            
            item.Active = Active;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string VoucherCode,decimal? ValueX,int? Type,DateTime? DateActive,DateTime? DateExpire,DateTime? DateCreated,bool? Active)
	    {
		    Voucher item = new Voucher();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.VoucherCode = VoucherCode;
				
			item.ValueX = ValueX;
				
			item.Type = Type;
				
			item.DateActive = DateActive;
				
			item.DateExpire = DateExpire;
				
			item.DateCreated = DateCreated;
				
			item.Active = Active;
				
	        item.Save(UserName);
	    }
    }
}
