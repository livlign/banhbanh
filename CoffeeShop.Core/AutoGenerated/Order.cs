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
	/// Strongly-typed collection for the Order class.
	/// </summary>
    [Serializable]
	public partial class OrderCollection : ActiveList<Order, OrderCollection>
	{	   
		public OrderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>OrderCollection</returns>
		public OrderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Order o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblOrders table.
	/// </summary>
	[Serializable]
	public partial class Order : ActiveRecord<Order>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Order()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Order(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Order(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Order(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblOrders", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarOrderRef = new TableSchema.TableColumn(schema);
				colvarOrderRef.ColumnName = "OrderRef";
				colvarOrderRef.DataType = DbType.String;
				colvarOrderRef.MaxLength = 50;
				colvarOrderRef.AutoIncrement = false;
				colvarOrderRef.IsNullable = true;
				colvarOrderRef.IsPrimaryKey = false;
				colvarOrderRef.IsForeignKey = false;
				colvarOrderRef.IsReadOnly = false;
				colvarOrderRef.DefaultSetting = @"";
				colvarOrderRef.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderRef);
				
				TableSchema.TableColumn colvarOrderNumber = new TableSchema.TableColumn(schema);
				colvarOrderNumber.ColumnName = "OrderNumber";
				colvarOrderNumber.DataType = DbType.String;
				colvarOrderNumber.MaxLength = 50;
				colvarOrderNumber.AutoIncrement = false;
				colvarOrderNumber.IsNullable = true;
				colvarOrderNumber.IsPrimaryKey = false;
				colvarOrderNumber.IsForeignKey = false;
				colvarOrderNumber.IsReadOnly = false;
				colvarOrderNumber.DefaultSetting = @"";
				colvarOrderNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderNumber);
				
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
				
				TableSchema.TableColumn colvarDiscount = new TableSchema.TableColumn(schema);
				colvarDiscount.ColumnName = "Discount";
				colvarDiscount.DataType = DbType.Decimal;
				colvarDiscount.MaxLength = 0;
				colvarDiscount.AutoIncrement = false;
				colvarDiscount.IsNullable = true;
				colvarDiscount.IsPrimaryKey = false;
				colvarDiscount.IsForeignKey = false;
				colvarDiscount.IsReadOnly = false;
				colvarDiscount.DefaultSetting = @"";
				colvarDiscount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscount);
				
				TableSchema.TableColumn colvarDiscountType = new TableSchema.TableColumn(schema);
				colvarDiscountType.ColumnName = "DiscountType";
				colvarDiscountType.DataType = DbType.Int32;
				colvarDiscountType.MaxLength = 0;
				colvarDiscountType.AutoIncrement = false;
				colvarDiscountType.IsNullable = true;
				colvarDiscountType.IsPrimaryKey = false;
				colvarDiscountType.IsForeignKey = false;
				colvarDiscountType.IsReadOnly = false;
				colvarDiscountType.DefaultSetting = @"";
				colvarDiscountType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscountType);
				
				TableSchema.TableColumn colvarAddonDiscount = new TableSchema.TableColumn(schema);
				colvarAddonDiscount.ColumnName = "AddonDiscount";
				colvarAddonDiscount.DataType = DbType.Decimal;
				colvarAddonDiscount.MaxLength = 0;
				colvarAddonDiscount.AutoIncrement = false;
				colvarAddonDiscount.IsNullable = true;
				colvarAddonDiscount.IsPrimaryKey = false;
				colvarAddonDiscount.IsForeignKey = false;
				colvarAddonDiscount.IsReadOnly = false;
				colvarAddonDiscount.DefaultSetting = @"";
				colvarAddonDiscount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddonDiscount);
				
				TableSchema.TableColumn colvarTotalCost = new TableSchema.TableColumn(schema);
				colvarTotalCost.ColumnName = "TotalCost";
				colvarTotalCost.DataType = DbType.Decimal;
				colvarTotalCost.MaxLength = 0;
				colvarTotalCost.AutoIncrement = false;
				colvarTotalCost.IsNullable = true;
				colvarTotalCost.IsPrimaryKey = false;
				colvarTotalCost.IsForeignKey = false;
				colvarTotalCost.IsReadOnly = false;
				colvarTotalCost.DefaultSetting = @"";
				colvarTotalCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalCost);
				
				TableSchema.TableColumn colvarTotalValue = new TableSchema.TableColumn(schema);
				colvarTotalValue.ColumnName = "TotalValue";
				colvarTotalValue.DataType = DbType.Decimal;
				colvarTotalValue.MaxLength = 0;
				colvarTotalValue.AutoIncrement = false;
				colvarTotalValue.IsNullable = true;
				colvarTotalValue.IsPrimaryKey = false;
				colvarTotalValue.IsForeignKey = false;
				colvarTotalValue.IsReadOnly = false;
				colvarTotalValue.DefaultSetting = @"";
				colvarTotalValue.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalValue);
				
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
				
				TableSchema.TableColumn colvarStatusId = new TableSchema.TableColumn(schema);
				colvarStatusId.ColumnName = "StatusId";
				colvarStatusId.DataType = DbType.Int32;
				colvarStatusId.MaxLength = 0;
				colvarStatusId.AutoIncrement = false;
				colvarStatusId.IsNullable = true;
				colvarStatusId.IsPrimaryKey = false;
				colvarStatusId.IsForeignKey = false;
				colvarStatusId.IsReadOnly = false;
				colvarStatusId.DefaultSetting = @"";
				colvarStatusId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatusId);
				
				TableSchema.TableColumn colvarPromoId = new TableSchema.TableColumn(schema);
				colvarPromoId.ColumnName = "PromoId";
				colvarPromoId.DataType = DbType.Int32;
				colvarPromoId.MaxLength = 0;
				colvarPromoId.AutoIncrement = false;
				colvarPromoId.IsNullable = true;
				colvarPromoId.IsPrimaryKey = false;
				colvarPromoId.IsForeignKey = false;
				colvarPromoId.IsReadOnly = false;
				colvarPromoId.DefaultSetting = @"";
				colvarPromoId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPromoId);
				
				TableSchema.TableColumn colvarNote = new TableSchema.TableColumn(schema);
				colvarNote.ColumnName = "Note";
				colvarNote.DataType = DbType.String;
				colvarNote.MaxLength = 500;
				colvarNote.AutoIncrement = false;
				colvarNote.IsNullable = true;
				colvarNote.IsPrimaryKey = false;
				colvarNote.IsForeignKey = false;
				colvarNote.IsReadOnly = false;
				colvarNote.DefaultSetting = @"";
				colvarNote.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNote);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["LocalProvider"].AddSchema("tblOrders",schema);
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
		  
		[XmlAttribute("OrderRef")]
		[Bindable(true)]
		public string OrderRef 
		{
			get { return GetColumnValue<string>(Columns.OrderRef); }
			set { SetColumnValue(Columns.OrderRef, value); }
		}
		  
		[XmlAttribute("OrderNumber")]
		[Bindable(true)]
		public string OrderNumber 
		{
			get { return GetColumnValue<string>(Columns.OrderNumber); }
			set { SetColumnValue(Columns.OrderNumber, value); }
		}
		  
		[XmlAttribute("ValueX")]
		[Bindable(true)]
		public decimal? ValueX 
		{
			get { return GetColumnValue<decimal?>(Columns.ValueX); }
			set { SetColumnValue(Columns.ValueX, value); }
		}
		  
		[XmlAttribute("Discount")]
		[Bindable(true)]
		public decimal? Discount 
		{
			get { return GetColumnValue<decimal?>(Columns.Discount); }
			set { SetColumnValue(Columns.Discount, value); }
		}
		  
		[XmlAttribute("DiscountType")]
		[Bindable(true)]
		public int? DiscountType 
		{
			get { return GetColumnValue<int?>(Columns.DiscountType); }
			set { SetColumnValue(Columns.DiscountType, value); }
		}
		  
		[XmlAttribute("AddonDiscount")]
		[Bindable(true)]
		public decimal? AddonDiscount 
		{
			get { return GetColumnValue<decimal?>(Columns.AddonDiscount); }
			set { SetColumnValue(Columns.AddonDiscount, value); }
		}
		  
		[XmlAttribute("TotalCost")]
		[Bindable(true)]
		public decimal? TotalCost 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalCost); }
			set { SetColumnValue(Columns.TotalCost, value); }
		}
		  
		[XmlAttribute("TotalValue")]
		[Bindable(true)]
		public decimal? TotalValue 
		{
			get { return GetColumnValue<decimal?>(Columns.TotalValue); }
			set { SetColumnValue(Columns.TotalValue, value); }
		}
		  
		[XmlAttribute("VoucherCode")]
		[Bindable(true)]
		public string VoucherCode 
		{
			get { return GetColumnValue<string>(Columns.VoucherCode); }
			set { SetColumnValue(Columns.VoucherCode, value); }
		}
		  
		[XmlAttribute("DateCreated")]
		[Bindable(true)]
		public DateTime? DateCreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateCreated); }
			set { SetColumnValue(Columns.DateCreated, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public int? UserId 
		{
			get { return GetColumnValue<int?>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		  
		[XmlAttribute("StatusId")]
		[Bindable(true)]
		public int? StatusId 
		{
			get { return GetColumnValue<int?>(Columns.StatusId); }
			set { SetColumnValue(Columns.StatusId, value); }
		}
		  
		[XmlAttribute("PromoId")]
		[Bindable(true)]
		public int? PromoId 
		{
			get { return GetColumnValue<int?>(Columns.PromoId); }
			set { SetColumnValue(Columns.PromoId, value); }
		}
		  
		[XmlAttribute("Note")]
		[Bindable(true)]
		public string Note 
		{
			get { return GetColumnValue<string>(Columns.Note); }
			set { SetColumnValue(Columns.Note, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varOrderRef,string varOrderNumber,decimal? varValueX,decimal? varDiscount,int? varDiscountType,decimal? varAddonDiscount,decimal? varTotalCost,decimal? varTotalValue,string varVoucherCode,DateTime? varDateCreated,int? varUserId,int? varStatusId,int? varPromoId,string varNote)
		{
			Order item = new Order();
			
			item.OrderRef = varOrderRef;
			
			item.OrderNumber = varOrderNumber;
			
			item.ValueX = varValueX;
			
			item.Discount = varDiscount;
			
			item.DiscountType = varDiscountType;
			
			item.AddonDiscount = varAddonDiscount;
			
			item.TotalCost = varTotalCost;
			
			item.TotalValue = varTotalValue;
			
			item.VoucherCode = varVoucherCode;
			
			item.DateCreated = varDateCreated;
			
			item.UserId = varUserId;
			
			item.StatusId = varStatusId;
			
			item.PromoId = varPromoId;
			
			item.Note = varNote;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varOrderRef,string varOrderNumber,decimal? varValueX,decimal? varDiscount,int? varDiscountType,decimal? varAddonDiscount,decimal? varTotalCost,decimal? varTotalValue,string varVoucherCode,DateTime? varDateCreated,int? varUserId,int? varStatusId,int? varPromoId,string varNote)
		{
			Order item = new Order();
			
				item.Id = varId;
			
				item.OrderRef = varOrderRef;
			
				item.OrderNumber = varOrderNumber;
			
				item.ValueX = varValueX;
			
				item.Discount = varDiscount;
			
				item.DiscountType = varDiscountType;
			
				item.AddonDiscount = varAddonDiscount;
			
				item.TotalCost = varTotalCost;
			
				item.TotalValue = varTotalValue;
			
				item.VoucherCode = varVoucherCode;
			
				item.DateCreated = varDateCreated;
			
				item.UserId = varUserId;
			
				item.StatusId = varStatusId;
			
				item.PromoId = varPromoId;
			
				item.Note = varNote;
			
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
        
        
        
        public static TableSchema.TableColumn OrderRefColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderNumberColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValueXColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountTypeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AddonDiscountColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalCostColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalValueColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn VoucherCodeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusIdColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PromoIdColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn NoteColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string OrderRef = @"OrderRef";
			 public static string OrderNumber = @"OrderNumber";
			 public static string ValueX = @"Value";
			 public static string Discount = @"Discount";
			 public static string DiscountType = @"DiscountType";
			 public static string AddonDiscount = @"AddonDiscount";
			 public static string TotalCost = @"TotalCost";
			 public static string TotalValue = @"TotalValue";
			 public static string VoucherCode = @"VoucherCode";
			 public static string DateCreated = @"DateCreated";
			 public static string UserId = @"UserId";
			 public static string StatusId = @"StatusId";
			 public static string PromoId = @"PromoId";
			 public static string Note = @"Note";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
