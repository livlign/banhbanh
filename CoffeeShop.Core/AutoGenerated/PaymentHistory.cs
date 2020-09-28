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
	/// Strongly-typed collection for the PaymentHistory class.
	/// </summary>
    [Serializable]
	public partial class PaymentHistoryCollection : ActiveList<PaymentHistory, PaymentHistoryCollection>
	{	   
		public PaymentHistoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PaymentHistoryCollection</returns>
		public PaymentHistoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PaymentHistory o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblPaymentHistorys table.
	/// </summary>
	[Serializable]
	public partial class PaymentHistory : ActiveRecord<PaymentHistory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PaymentHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PaymentHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PaymentHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PaymentHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblPaymentHistorys", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarOrderId = new TableSchema.TableColumn(schema);
				colvarOrderId.ColumnName = "OrderId";
				colvarOrderId.DataType = DbType.Int32;
				colvarOrderId.MaxLength = 0;
				colvarOrderId.AutoIncrement = false;
				colvarOrderId.IsNullable = true;
				colvarOrderId.IsPrimaryKey = false;
				colvarOrderId.IsForeignKey = false;
				colvarOrderId.IsReadOnly = false;
				colvarOrderId.DefaultSetting = @"";
				colvarOrderId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderId);
				
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
				
				TableSchema.TableColumn colvarTypeId = new TableSchema.TableColumn(schema);
				colvarTypeId.ColumnName = "TypeId";
				colvarTypeId.DataType = DbType.Int32;
				colvarTypeId.MaxLength = 0;
				colvarTypeId.AutoIncrement = false;
				colvarTypeId.IsNullable = true;
				colvarTypeId.IsPrimaryKey = false;
				colvarTypeId.IsForeignKey = false;
				colvarTypeId.IsReadOnly = false;
				colvarTypeId.DefaultSetting = @"";
				colvarTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTypeId);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Int32;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = true;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = false;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				colvarUserId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserId);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["LocalProvider"].AddSchema("tblPaymentHistorys",schema);
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
		  
		[XmlAttribute("OrderId")]
		[Bindable(true)]
		public int? OrderId 
		{
			get { return GetColumnValue<int?>(Columns.OrderId); }
			set { SetColumnValue(Columns.OrderId, value); }
		}
		  
		[XmlAttribute("ValueX")]
		[Bindable(true)]
		public decimal? ValueX 
		{
			get { return GetColumnValue<decimal?>(Columns.ValueX); }
			set { SetColumnValue(Columns.ValueX, value); }
		}
		  
		[XmlAttribute("TypeId")]
		[Bindable(true)]
		public int? TypeId 
		{
			get { return GetColumnValue<int?>(Columns.TypeId); }
			set { SetColumnValue(Columns.TypeId, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public int? UserId 
		{
			get { return GetColumnValue<int?>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		  
		[XmlAttribute("DateCreated")]
		[Bindable(true)]
		public DateTime? DateCreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateCreated); }
			set { SetColumnValue(Columns.DateCreated, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varOrderId,decimal? varValueX,int? varTypeId,int? varUserId,DateTime? varDateCreated)
		{
			PaymentHistory item = new PaymentHistory();
			
			item.OrderId = varOrderId;
			
			item.ValueX = varValueX;
			
			item.TypeId = varTypeId;
			
			item.UserId = varUserId;
			
			item.DateCreated = varDateCreated;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varOrderId,decimal? varValueX,int? varTypeId,int? varUserId,DateTime? varDateCreated)
		{
			PaymentHistory item = new PaymentHistory();
			
				item.Id = varId;
			
				item.OrderId = varOrderId;
			
				item.ValueX = varValueX;
			
				item.TypeId = varTypeId;
			
				item.UserId = varUserId;
			
				item.DateCreated = varDateCreated;
			
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
        
        
        
        public static TableSchema.TableColumn OrderIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ValueXColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string OrderId = @"OrderId";
			 public static string ValueX = @"Value";
			 public static string TypeId = @"TypeId";
			 public static string UserId = @"UserId";
			 public static string DateCreated = @"DateCreated";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
