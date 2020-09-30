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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Category = @"tblCategories";
        
		public static string Customer = @"tblCustomers";
        
		public static string District = @"tblDistricts";
        
		public static string Ingredient = @"tblIngredients";
        
		public static string MenuItem = @"tblMenuItems";
        
		public static string MenuPosition = @"tblMenuPosition";
        
		public static string OrderItem = @"tblOrderItems";
        
		public static string OrderNote = @"tblOrderNotes";
        
		public static string Order = @"tblOrders";
        
		public static string OrderStatus = @"tblOrderStatus";
        
		public static string PaymentHistory = @"tblPaymentHistorys";
        
		public static string PaymentType = @"tblPaymentTypes";
        
		public static string Position = @"tblPositions";
        
		public static string Product = @"tblProducts";
        
		public static string Template = @"tblTemplates";
        
		public static string Unit = @"tblUnits";
        
		public static string User = @"tblUsers";
        
		public static string Voucher = @"tblVouchers";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table Category{
            get { return DataService.GetSchema("tblCategories","LocalProvider"); }
		}
        
		public static TableSchema.Table Customer{
            get { return DataService.GetSchema("tblCustomers","LocalProvider"); }
		}
        
		public static TableSchema.Table District{
            get { return DataService.GetSchema("tblDistricts","LocalProvider"); }
		}
        
		public static TableSchema.Table Ingredient{
            get { return DataService.GetSchema("tblIngredients","LocalProvider"); }
		}
        
		public static TableSchema.Table MenuItem{
            get { return DataService.GetSchema("tblMenuItems","LocalProvider"); }
		}
        
		public static TableSchema.Table MenuPosition{
            get { return DataService.GetSchema("tblMenuPosition","LocalProvider"); }
		}
        
		public static TableSchema.Table OrderItem{
            get { return DataService.GetSchema("tblOrderItems","LocalProvider"); }
		}
        
		public static TableSchema.Table OrderNote{
            get { return DataService.GetSchema("tblOrderNotes","LocalProvider"); }
		}
        
		public static TableSchema.Table Order{
            get { return DataService.GetSchema("tblOrders","LocalProvider"); }
		}
        
		public static TableSchema.Table OrderStatus{
            get { return DataService.GetSchema("tblOrderStatus","LocalProvider"); }
		}
        
		public static TableSchema.Table PaymentHistory{
            get { return DataService.GetSchema("tblPaymentHistorys","LocalProvider"); }
		}
        
		public static TableSchema.Table PaymentType{
            get { return DataService.GetSchema("tblPaymentTypes","LocalProvider"); }
		}
        
		public static TableSchema.Table Position{
            get { return DataService.GetSchema("tblPositions","LocalProvider"); }
		}
        
		public static TableSchema.Table Product{
            get { return DataService.GetSchema("tblProducts","LocalProvider"); }
		}
        
		public static TableSchema.Table Template{
            get { return DataService.GetSchema("tblTemplates","LocalProvider"); }
		}
        
		public static TableSchema.Table Unit{
            get { return DataService.GetSchema("tblUnits","LocalProvider"); }
		}
        
		public static TableSchema.Table User{
            get { return DataService.GetSchema("tblUsers","LocalProvider"); }
		}
        
		public static TableSchema.Table Voucher{
            get { return DataService.GetSchema("tblVouchers","LocalProvider"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["LocalProvider"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository {
            get {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
	
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
            
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
     
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static string LocalProvider = @"LocalProvider";
    
}
#endregion