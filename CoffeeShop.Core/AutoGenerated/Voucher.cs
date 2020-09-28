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
	/// Strongly-typed collection for the Voucher class.
	/// </summary>
    [Serializable]
	public partial class VoucherCollection : ActiveList<Voucher, VoucherCollection>
	{	   
		public VoucherCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>VoucherCollection</returns>
		public VoucherCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Voucher o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblVouchers table.
	/// </summary>
	[Serializable]
	public partial class Voucher : ActiveRecord<Voucher>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Voucher()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Voucher(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Voucher(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Voucher(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblVouchers", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarVoucherCode = new TableSchema.TableColumn(schema);
				colvarVoucherCode.ColumnName = "VoucherCode";
				colvarVoucherCode.DataType = DbType.String;
				colvarVoucherCode.MaxLength = 100;
				colvarVoucherCode.AutoIncrement = false;
				colvarVoucherCode.IsNullable = true;
				colvarVoucherCode.IsPrimaryKey = false;
				colvarVoucherCode.IsForeignKey = false;
				colvarVoucherCode.IsReadOnly = false;
				colvarVoucherCode.DefaultSetting = @"";
				colvarVoucherCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVoucherCode);
				
				TableSchema.TableColumn colvarValueX = new TableSchema.TableColumn(schema);
				colvarValueX.ColumnName = "Value";
				colvarValueX.DataType = DbType.Decimal;
				colvarValueX.MaxLength = 0;
				colvarValueX.AutoIncrement = false;
				colvarValueX.IsNullable = true;
				colvarValueX.IsPrimaryKey = false;
				colvarValueX.IsForeignKey = false;
				colvarValueX.IsReadOnly = false;
				colvarValueX.DefaultSetting = @"";
				colvarValueX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValueX);
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.Int32;
				colvarType.MaxLength = 0;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = true;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				colvarType.DefaultSetting = @"";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				TableSchema.TableColumn colvarDateActive = new TableSchema.TableColumn(schema);
				colvarDateActive.ColumnName = "DateActive";
				colvarDateActive.DataType = DbType.DateTime;
				colvarDateActive.MaxLength = 0;
				colvarDateActive.AutoIncrement = false;
				colvarDateActive.IsNullable = true;
				colvarDateActive.IsPrimaryKey = false;
				colvarDateActive.IsForeignKey = false;
				colvarDateActive.IsReadOnly = false;
				colvarDateActive.DefaultSetting = @"";
				colvarDateActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateActive);
				
				TableSchema.TableColumn colvarDateExpire = new TableSchema.TableColumn(schema);
				colvarDateExpire.ColumnName = "DateExpire";
				colvarDateExpire.DataType = DbType.DateTime;
				colvarDateExpire.MaxLength = 0;
				colvarDateExpire.AutoIncrement = false;
				colvarDateExpire.IsNullable = true;
				colvarDateExpire.IsPrimaryKey = false;
				colvarDateExpire.IsForeignKey = false;
				colvarDateExpire.IsReadOnly = false;
				colvarDateExpire.DefaultSetting = @"";
				colvarDateExpire.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateExpire);
				
				TableSchema.TableColumn colvarDateCreated = new TableSchema.TableColumn(schema);
				colvarDateCreated.ColumnName = "DateCreated";
				colvarDateCreated.DataType = DbType.DateTime;
				colvarDateCreated.MaxLength = 0;
				colvarDateCreated.AutoIncrement = false;
				colvarDateCreated.IsNullable = true;
				colvarDateCreated.IsPrimaryKey = false;
				colvarDateCreated.IsForeignKey = false;
				colvarDateCreated.IsReadOnly = false;
				colvarDateCreated.DefaultSetting = @"";
				colvarDateCreated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateCreated);
				
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
				DataService.Providers["LocalProvider"].AddSchema("tblVouchers",schema);
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
		  
		[XmlAttribute("VoucherCode")]
		[Bindable(true)]
		public string VoucherCode 
		{
			get { return GetColumnValue<string>(Columns.VoucherCode); }
			set { SetColumnValue(Columns.VoucherCode, value); }
		}
		  
		[XmlAttribute("ValueX")]
		[Bindable(true)]
		public decimal? ValueX 
		{
			get { return GetColumnValue<decimal?>(Columns.ValueX); }
			set { SetColumnValue(Columns.ValueX, value); }
		}
		  
		[XmlAttribute("Type")]
		[Bindable(true)]
		public int? Type 
		{
			get { return GetColumnValue<int?>(Columns.Type); }
			set { SetColumnValue(Columns.Type, value); }
		}
		  
		[XmlAttribute("DateActive")]
		[Bindable(true)]
		public DateTime? DateActive 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateActive); }
			set { SetColumnValue(Columns.DateActive, value); }
		}
		  
		[XmlAttribute("DateExpire")]
		[Bindable(true)]
		public DateTime? DateExpire 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateExpire); }
			set { SetColumnValue(Columns.DateExpire, value); }
		}
		  
		[XmlAttribute("DateCreated")]
		[Bindable(true)]
		public DateTime? DateCreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateCreated); }
			set { SetColumnValue(Columns.DateCreated, value); }
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
		public static void Insert(string varVoucherCode,decimal? varValueX,int? varType,DateTime? varDateActive,DateTime? varDateExpire,DateTime? varDateCreated,bool? varActive)
		{
			Voucher item = new Voucher();
			
			item.VoucherCode = varVoucherCode;
			
			item.ValueX = varValueX;
			
			item.Type = varType;
			
			item.DateActive = varDateActive;
			
			item.DateExpire = varDateExpire;
			
			item.DateCreated = varDateCreated;
			
			item.Active = varActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varVoucherCode,decimal? varValueX,int? varType,DateTime? varDateActive,DateTime? varDateExpire,DateTime? varDateCreated,bool? varActive)
		{
			Voucher item = new Voucher();
			
				item.Id = varId;
			
				item.VoucherCode = varVoucherCode;
			
				item.ValueX = varValueX;
			
				item.Type = varType;
			
				item.DateActive = varDateActive;
			
				item.DateExpire = varDateExpire;
			
				item.DateCreated = varDateCreated;
			
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
        
        
        
        public static TableSchema.TableColumn VoucherCodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ValueXColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DateActiveColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DateExpireColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string VoucherCode = @"VoucherCode";
			 public static string ValueX = @"Value";
			 public static string Type = @"Type";
			 public static string DateActive = @"DateActive";
			 public static string DateExpire = @"DateExpire";
			 public static string DateCreated = @"DateCreated";
			 public static string Active = @"Active";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
