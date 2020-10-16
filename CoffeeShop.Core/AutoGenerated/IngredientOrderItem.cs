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
	/// Strongly-typed collection for the IngredientOrderItem class.
	/// </summary>
    [Serializable]
	public partial class IngredientOrderItemCollection : ActiveList<IngredientOrderItem, IngredientOrderItemCollection>
	{	   
		public IngredientOrderItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>IngredientOrderItemCollection</returns>
		public IngredientOrderItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                IngredientOrderItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblIngredientOrderItems table.
	/// </summary>
	[Serializable]
	public partial class IngredientOrderItem : ActiveRecord<IngredientOrderItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public IngredientOrderItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public IngredientOrderItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public IngredientOrderItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public IngredientOrderItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblIngredientOrderItems", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarIngredientId = new TableSchema.TableColumn(schema);
				colvarIngredientId.ColumnName = "IngredientId";
				colvarIngredientId.DataType = DbType.Int32;
				colvarIngredientId.MaxLength = 0;
				colvarIngredientId.AutoIncrement = false;
				colvarIngredientId.IsNullable = true;
				colvarIngredientId.IsPrimaryKey = false;
				colvarIngredientId.IsForeignKey = false;
				colvarIngredientId.IsReadOnly = false;
				colvarIngredientId.DefaultSetting = @"";
				colvarIngredientId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIngredientId);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int32;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = true;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				colvarQuantity.DefaultSetting = @"";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarTotal = new TableSchema.TableColumn(schema);
				colvarTotal.ColumnName = "Total";
				colvarTotal.DataType = DbType.Decimal;
				colvarTotal.MaxLength = 0;
				colvarTotal.AutoIncrement = false;
				colvarTotal.IsNullable = true;
				colvarTotal.IsPrimaryKey = false;
				colvarTotal.IsForeignKey = false;
				colvarTotal.IsReadOnly = false;
				colvarTotal.DefaultSetting = @"";
				colvarTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotal);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["LocalProvider"].AddSchema("tblIngredientOrderItems",schema);
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
		  
		[XmlAttribute("IngredientId")]
		[Bindable(true)]
		public int? IngredientId 
		{
			get { return GetColumnValue<int?>(Columns.IngredientId); }
			set { SetColumnValue(Columns.IngredientId, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public int? Quantity 
		{
			get { return GetColumnValue<int?>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
		}
		  
		[XmlAttribute("Total")]
		[Bindable(true)]
		public decimal? Total 
		{
			get { return GetColumnValue<decimal?>(Columns.Total); }
			set { SetColumnValue(Columns.Total, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varOrderId,int? varIngredientId,int? varQuantity,decimal? varTotal)
		{
			IngredientOrderItem item = new IngredientOrderItem();
			
			item.OrderId = varOrderId;
			
			item.IngredientId = varIngredientId;
			
			item.Quantity = varQuantity;
			
			item.Total = varTotal;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varOrderId,int? varIngredientId,int? varQuantity,decimal? varTotal)
		{
			IngredientOrderItem item = new IngredientOrderItem();
			
				item.Id = varId;
			
				item.OrderId = varOrderId;
			
				item.IngredientId = varIngredientId;
			
				item.Quantity = varQuantity;
			
				item.Total = varTotal;
			
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
        
        
        
        public static TableSchema.TableColumn IngredientIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string OrderId = @"OrderId";
			 public static string IngredientId = @"IngredientId";
			 public static string Quantity = @"Quantity";
			 public static string Total = @"Total";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
