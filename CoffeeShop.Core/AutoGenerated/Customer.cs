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
	/// Strongly-typed collection for the Customer class.
	/// </summary>
    [Serializable]
	public partial class CustomerCollection : ActiveList<Customer, CustomerCollection>
	{	   
		public CustomerCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CustomerCollection</returns>
		public CustomerCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Customer o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the tblCustomers table.
	/// </summary>
	[Serializable]
	public partial class Customer : ActiveRecord<Customer>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Customer()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Customer(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Customer(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Customer(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("tblCustomers", TableType.Table, DataService.GetInstance("LocalProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 200;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = true;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.String;
				colvarAddress.MaxLength = 500;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
				colvarPhone.ColumnName = "Phone";
				colvarPhone.DataType = DbType.String;
				colvarPhone.MaxLength = 20;
				colvarPhone.AutoIncrement = false;
				colvarPhone.IsNullable = true;
				colvarPhone.IsPrimaryKey = false;
				colvarPhone.IsForeignKey = false;
				colvarPhone.IsReadOnly = false;
				colvarPhone.DefaultSetting = @"";
				colvarPhone.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhone);
				
				TableSchema.TableColumn colvarDistrictId = new TableSchema.TableColumn(schema);
				colvarDistrictId.ColumnName = "DistrictId";
				colvarDistrictId.DataType = DbType.Int32;
				colvarDistrictId.MaxLength = 0;
				colvarDistrictId.AutoIncrement = false;
				colvarDistrictId.IsNullable = true;
				colvarDistrictId.IsPrimaryKey = false;
				colvarDistrictId.IsForeignKey = false;
				colvarDistrictId.IsReadOnly = false;
				colvarDistrictId.DefaultSetting = @"";
				colvarDistrictId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDistrictId);
				
				TableSchema.TableColumn colvarActive = new TableSchema.TableColumn(schema);
				colvarActive.ColumnName = "Active";
				colvarActive.DataType = DbType.Boolean;
				colvarActive.MaxLength = 0;
				colvarActive.AutoIncrement = false;
				colvarActive.IsNullable = true;
				colvarActive.IsPrimaryKey = false;
				colvarActive.IsForeignKey = false;
				colvarActive.IsReadOnly = false;
				colvarActive.DefaultSetting = @"";
				colvarActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActive);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["LocalProvider"].AddSchema("tblCustomers",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("Phone")]
		[Bindable(true)]
		public string Phone 
		{
			get { return GetColumnValue<string>(Columns.Phone); }
			set { SetColumnValue(Columns.Phone, value); }
		}
		  
		[XmlAttribute("DistrictId")]
		[Bindable(true)]
		public int? DistrictId 
		{
			get { return GetColumnValue<int?>(Columns.DistrictId); }
			set { SetColumnValue(Columns.DistrictId, value); }
		}
		  
		[XmlAttribute("Active")]
		[Bindable(true)]
		public bool? Active 
		{
			get { return GetColumnValue<bool?>(Columns.Active); }
			set { SetColumnValue(Columns.Active, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varAddress,string varPhone,int? varDistrictId,bool? varActive)
		{
			Customer item = new Customer();
			
			item.Name = varName;
			
			item.Address = varAddress;
			
			item.Phone = varPhone;
			
			item.DistrictId = varDistrictId;
			
			item.Active = varActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varName,string varAddress,string varPhone,int? varDistrictId,bool? varActive)
		{
			Customer item = new Customer();
			
				item.Id = varId;
			
				item.Name = varName;
			
				item.Address = varAddress;
			
				item.Phone = varPhone;
			
				item.DistrictId = varDistrictId;
			
				item.Active = varActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PhoneColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DistrictIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Name = @"Name";
			 public static string Address = @"Address";
			 public static string Phone = @"Phone";
			 public static string DistrictId = @"DistrictId";
			 public static string Active = @"Active";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
