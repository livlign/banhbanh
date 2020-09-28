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
	/// Strongly-typed collection for the OrderItem class.
	/// </summary>
    [Serializable]
	public partial class OrderItemCollection : ActiveList<OrderItem, OrderItemCollection>
	{	   
		public OrderItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>OrderItemCollection</returns>
		public OrderItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                OrderItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblOrderItems table.
	/// </summary>
	[Serializable]
	public partial class OrderItem : ActiveRecord<OrderItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public OrderItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public OrderItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public OrderItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public OrderItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblOrderItems", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarProductId = new TableSchema.TableColumn(schema);
				colvarProductId.ColumnName = "ProductId";
				colvarProductId.DataType = DbType.Int32;
				colvarProductId.MaxLength = 0;
				colvarProductId.AutoIncrement = false;
				colvarProductId.IsNullable = true;
				colvarProductId.IsPrimaryKey = false;
				colvarProductId.IsForeignKey = false;
				colvarProductId.IsReadOnly = false;
				colvarProductId.DefaultSetting = @"";
				colvarProductId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductId);
				
				TableSchema.TableColumn colvarQty = new TableSchema.TableColumn(schema);
				colvarQty.ColumnName = "Qty";
				colvarQty.DataType = DbType.Int32;
				colvarQty.MaxLength = 0;
				colvarQty.AutoIncrement = false;
				colvarQty.IsNullable = true;
				colvarQty.IsPrimaryKey = false;
				colvarQty.IsForeignKey = false;
				colvarQty.IsReadOnly = false;
				colvarQty.DefaultSetting = @"";
				colvarQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQty);
				
				TableSchema.TableColumn colvarPrice = new TableSchema.TableColumn(schema);
				colvarPrice.ColumnName = "Price";
				colvarPrice.DataType = DbType.Decimal;
				colvarPrice.MaxLength = 0;
				colvarPrice.AutoIncrement = false;
				colvarPrice.IsNullable = true;
				colvarPrice.IsPrimaryKey = false;
				colvarPrice.IsForeignKey = false;
				colvarPrice.IsReadOnly = false;
				colvarPrice.DefaultSetting = @"";
				colvarPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrice);
				
				TableSchema.TableColumn colvarCost = new TableSchema.TableColumn(schema);
				colvarCost.ColumnName = "Cost";
				colvarCost.DataType = DbType.Decimal;
				colvarCost.MaxLength = 0;
				colvarCost.AutoIncrement = false;
				colvarCost.IsNullable = true;
				colvarCost.IsPrimaryKey = false;
				colvarCost.IsForeignKey = false;
				colvarCost.IsReadOnly = false;
				colvarCost.DefaultSetting = @"";
				colvarCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCost);
				
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
				DataService.Providers["LocalProvider"].AddSchema("tblOrderItems",schema);
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
		  
		[XmlAttribute("ProductId")]
		[Bindable(true)]
		public int? ProductId 
		{
			get { return GetColumnValue<int?>(Columns.ProductId); }
			set { SetColumnValue(Columns.ProductId, value); }
		}
		  
		[XmlAttribute("Qty")]
		[Bindable(true)]
		public int? Qty 
		{
			get { return GetColumnValue<int?>(Columns.Qty); }
			set { SetColumnValue(Columns.Qty, value); }
		}
		  
		[XmlAttribute("Price")]
		[Bindable(true)]
		public decimal? Price 
		{
			get { return GetColumnValue<decimal?>(Columns.Price); }
			set { SetColumnValue(Columns.Price, value); }
		}
		  
		[XmlAttribute("Cost")]
		[Bindable(true)]
		public decimal? Cost 
		{
			get { return GetColumnValue<decimal?>(Columns.Cost); }
			set { SetColumnValue(Columns.Cost, value); }
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
		public static void Insert(int? varOrderId,int? varProductId,int? varQty,decimal? varPrice,decimal? varCost,string varNote)
		{
			OrderItem item = new OrderItem();
			
			item.OrderId = varOrderId;
			
			item.ProductId = varProductId;
			
			item.Qty = varQty;
			
			item.Price = varPrice;
			
			item.Cost = varCost;
			
			item.Note = varNote;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varOrderId,int? varProductId,int? varQty,decimal? varPrice,decimal? varCost,string varNote)
		{
			OrderItem item = new OrderItem();
			
				item.Id = varId;
			
				item.OrderId = varOrderId;
			
				item.ProductId = varProductId;
			
				item.Qty = varQty;
			
				item.Price = varPrice;
			
				item.Cost = varCost;
			
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
        
        
        
        public static TableSchema.TableColumn OrderIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn QtyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PriceColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CostColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NoteColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string OrderId = @"OrderId";
			 public static string ProductId = @"ProductId";
			 public static string Qty = @"Qty";
			 public static string Price = @"Price";
			 public static string Cost = @"Cost";
			 public static string Note = @"Note";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
