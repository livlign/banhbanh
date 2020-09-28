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
	/// Strongly-typed collection for the User class.
	/// </summary>
    [Serializable]
	public partial class UserCollection : ActiveList<User, UserCollection>
	{	   
		public UserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UserCollection</returns>
		public UserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                User o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblUsers table.
	/// </summary>
	[Serializable]
	public partial class User : ActiveRecord<User>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public User()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public User(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public User(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public User(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblUsers", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.String;
				colvarUserName.MaxLength = 200;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = true;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "Password";
				colvarPassword.DataType = DbType.String;
				colvarPassword.MaxLength = 50;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = true;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				colvarPassword.DefaultSetting = @"";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				TableSchema.TableColumn colvarFullName = new TableSchema.TableColumn(schema);
				colvarFullName.ColumnName = "FullName";
				colvarFullName.DataType = DbType.String;
				colvarFullName.MaxLength = 200;
				colvarFullName.AutoIncrement = false;
				colvarFullName.IsNullable = true;
				colvarFullName.IsPrimaryKey = false;
				colvarFullName.IsForeignKey = false;
				colvarFullName.IsReadOnly = false;
				colvarFullName.DefaultSetting = @"";
				colvarFullName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFullName);
				
				TableSchema.TableColumn colvarPositionId = new TableSchema.TableColumn(schema);
				colvarPositionId.ColumnName = "PositionId";
				colvarPositionId.DataType = DbType.Int32;
				colvarPositionId.MaxLength = 0;
				colvarPositionId.AutoIncrement = false;
				colvarPositionId.IsNullable = true;
				colvarPositionId.IsPrimaryKey = false;
				colvarPositionId.IsForeignKey = false;
				colvarPositionId.IsReadOnly = false;
				colvarPositionId.DefaultSetting = @"";
				colvarPositionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPositionId);
				
				TableSchema.TableColumn colvarSalary = new TableSchema.TableColumn(schema);
				colvarSalary.ColumnName = "Salary";
				colvarSalary.DataType = DbType.Decimal;
				colvarSalary.MaxLength = 0;
				colvarSalary.AutoIncrement = false;
				colvarSalary.IsNullable = true;
				colvarSalary.IsPrimaryKey = false;
				colvarSalary.IsForeignKey = false;
				colvarSalary.IsReadOnly = false;
				colvarSalary.DefaultSetting = @"";
				colvarSalary.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalary);
				
				TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
				colvarPhone.ColumnName = "Phone";
				colvarPhone.DataType = DbType.String;
				colvarPhone.MaxLength = 50;
				colvarPhone.AutoIncrement = false;
				colvarPhone.IsNullable = true;
				colvarPhone.IsPrimaryKey = false;
				colvarPhone.IsForeignKey = false;
				colvarPhone.IsReadOnly = false;
				colvarPhone.DefaultSetting = @"";
				colvarPhone.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhone);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.String;
				colvarAddress.MaxLength = 200;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarDateStart = new TableSchema.TableColumn(schema);
				colvarDateStart.ColumnName = "DateStart";
				colvarDateStart.DataType = DbType.DateTime;
				colvarDateStart.MaxLength = 0;
				colvarDateStart.AutoIncrement = false;
				colvarDateStart.IsNullable = true;
				colvarDateStart.IsPrimaryKey = false;
				colvarDateStart.IsForeignKey = false;
				colvarDateStart.IsReadOnly = false;
				colvarDateStart.DefaultSetting = @"";
				colvarDateStart.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateStart);
				
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
				
				TableSchema.TableColumn colvarImage = new TableSchema.TableColumn(schema);
				colvarImage.ColumnName = "Image";
				colvarImage.DataType = DbType.String;
				colvarImage.MaxLength = 500;
				colvarImage.AutoIncrement = false;
				colvarImage.IsNullable = true;
				colvarImage.IsPrimaryKey = false;
				colvarImage.IsForeignKey = false;
				colvarImage.IsReadOnly = false;
				colvarImage.DefaultSetting = @"";
				colvarImage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImage);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["LocalProvider"].AddSchema("tblUsers",schema);
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
		  
		[XmlAttribute("UserName")]
		[Bindable(true)]
		public string UserName 
		{
			get { return GetColumnValue<string>(Columns.UserName); }
			set { SetColumnValue(Columns.UserName, value); }
		}
		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }
			set { SetColumnValue(Columns.Password, value); }
		}
		  
		[XmlAttribute("FullName")]
		[Bindable(true)]
		public string FullName 
		{
			get { return GetColumnValue<string>(Columns.FullName); }
			set { SetColumnValue(Columns.FullName, value); }
		}
		  
		[XmlAttribute("PositionId")]
		[Bindable(true)]
		public int? PositionId 
		{
			get { return GetColumnValue<int?>(Columns.PositionId); }
			set { SetColumnValue(Columns.PositionId, value); }
		}
		  
		[XmlAttribute("Salary")]
		[Bindable(true)]
		public decimal? Salary 
		{
			get { return GetColumnValue<decimal?>(Columns.Salary); }
			set { SetColumnValue(Columns.Salary, value); }
		}
		  
		[XmlAttribute("Phone")]
		[Bindable(true)]
		public string Phone 
		{
			get { return GetColumnValue<string>(Columns.Phone); }
			set { SetColumnValue(Columns.Phone, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("DateStart")]
		[Bindable(true)]
		public DateTime? DateStart 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateStart); }
			set { SetColumnValue(Columns.DateStart, value); }
		}
		  
		[XmlAttribute("Active")]
		[Bindable(true)]
		public bool? Active 
		{
			get { return GetColumnValue<bool?>(Columns.Active); }
			set { SetColumnValue(Columns.Active, value); }
		}
		  
		[XmlAttribute("Image")]
		[Bindable(true)]
		public string Image 
		{
			get { return GetColumnValue<string>(Columns.Image); }
			set { SetColumnValue(Columns.Image, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUserName,string varPassword,string varFullName,int? varPositionId,decimal? varSalary,string varPhone,string varAddress,DateTime? varDateStart,bool? varActive,string varImage)
		{
			User item = new User();
			
			item.UserName = varUserName;
			
			item.Password = varPassword;
			
			item.FullName = varFullName;
			
			item.PositionId = varPositionId;
			
			item.Salary = varSalary;
			
			item.Phone = varPhone;
			
			item.Address = varAddress;
			
			item.DateStart = varDateStart;
			
			item.Active = varActive;
			
			item.Image = varImage;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varUserName,string varPassword,string varFullName,int? varPositionId,decimal? varSalary,string varPhone,string varAddress,DateTime? varDateStart,bool? varActive,string varImage)
		{
			User item = new User();
			
				item.Id = varId;
			
				item.UserName = varUserName;
			
				item.Password = varPassword;
			
				item.FullName = varFullName;
			
				item.PositionId = varPositionId;
			
				item.Salary = varSalary;
			
				item.Phone = varPhone;
			
				item.Address = varAddress;
			
				item.DateStart = varDateStart;
			
				item.Active = varActive;
			
				item.Image = varImage;
			
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
        
        
        
        public static TableSchema.TableColumn UserNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FullNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PositionIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SalaryColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PhoneColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DateStartColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string UserName = @"UserName";
			 public static string Password = @"Password";
			 public static string FullName = @"FullName";
			 public static string PositionId = @"PositionId";
			 public static string Salary = @"Salary";
			 public static string Phone = @"Phone";
			 public static string Address = @"Address";
			 public static string DateStart = @"DateStart";
			 public static string Active = @"Active";
			 public static string Image = @"Image";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
