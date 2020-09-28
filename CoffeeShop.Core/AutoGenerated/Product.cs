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
	/// Strongly-typed collection for the Product class.
	/// </summary>
    [Serializable]
	public partial class ProductCollection : ActiveList<Product, ProductCollection>
	{	   
		public ProductCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductCollection</returns>
		public ProductCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Product o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblProducts table.
	/// </summary>
	[Serializable]
	public partial class Product : ActiveRecord<Product>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Product()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Product(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Product(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Product(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblProducts", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarCategoryId = new TableSchema.TableColumn(schema);
				colvarCategoryId.ColumnName = "CategoryId";
				colvarCategoryId.DataType = DbType.Int32;
				colvarCategoryId.MaxLength = 0;
				colvarCategoryId.AutoIncrement = false;
				colvarCategoryId.IsNullable = true;
				colvarCategoryId.IsPrimaryKey = false;
				colvarCategoryId.IsForeignKey = false;
				colvarCategoryId.IsReadOnly = false;
				colvarCategoryId.DefaultSetting = @"";
				colvarCategoryId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryId);
				
				TableSchema.TableColumn colvarProductCode = new TableSchema.TableColumn(schema);
				colvarProductCode.ColumnName = "ProductCode";
				colvarProductCode.DataType = DbType.String;
				colvarProductCode.MaxLength = 10;
				colvarProductCode.AutoIncrement = false;
				colvarProductCode.IsNullable = true;
				colvarProductCode.IsPrimaryKey = false;
				colvarProductCode.IsForeignKey = false;
				colvarProductCode.IsReadOnly = false;
				colvarProductCode.DefaultSetting = @"";
				colvarProductCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductCode);
				
				TableSchema.TableColumn colvarProductName = new TableSchema.TableColumn(schema);
				colvarProductName.ColumnName = "ProductName";
				colvarProductName.DataType = DbType.String;
				colvarProductName.MaxLength = 200;
				colvarProductName.AutoIncrement = false;
				colvarProductName.IsNullable = true;
				colvarProductName.IsPrimaryKey = false;
				colvarProductName.IsForeignKey = false;
				colvarProductName.IsReadOnly = false;
				colvarProductName.DefaultSetting = @"";
				colvarProductName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = -1;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
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
				
				TableSchema.TableColumn colvarWeight = new TableSchema.TableColumn(schema);
				colvarWeight.ColumnName = "Weight";
				colvarWeight.DataType = DbType.String;
				colvarWeight.MaxLength = 50;
				colvarWeight.AutoIncrement = false;
				colvarWeight.IsNullable = true;
				colvarWeight.IsPrimaryKey = false;
				colvarWeight.IsForeignKey = false;
				colvarWeight.IsReadOnly = false;
				colvarWeight.DefaultSetting = @"";
				colvarWeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWeight);
				
				TableSchema.TableColumn colvarDateAdded = new TableSchema.TableColumn(schema);
				colvarDateAdded.ColumnName = "DateAdded";
				colvarDateAdded.DataType = DbType.DateTime;
				colvarDateAdded.MaxLength = 0;
				colvarDateAdded.AutoIncrement = false;
				colvarDateAdded.IsNullable = true;
				colvarDateAdded.IsPrimaryKey = false;
				colvarDateAdded.IsForeignKey = false;
				colvarDateAdded.IsReadOnly = false;
				colvarDateAdded.DefaultSetting = @"";
				colvarDateAdded.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateAdded);
				
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
				DataService.Providers["LocalProvider"].AddSchema("tblProducts",schema);
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
		  
		[XmlAttribute("CategoryId")]
		[Bindable(true)]
		public int? CategoryId 
		{
			get { return GetColumnValue<int?>(Columns.CategoryId); }
			set { SetColumnValue(Columns.CategoryId, value); }
		}
		  
		[XmlAttribute("ProductCode")]
		[Bindable(true)]
		public string ProductCode 
		{
			get { return GetColumnValue<string>(Columns.ProductCode); }
			set { SetColumnValue(Columns.ProductCode, value); }
		}
		  
		[XmlAttribute("ProductName")]
		[Bindable(true)]
		public string ProductName 
		{
			get { return GetColumnValue<string>(Columns.ProductName); }
			set { SetColumnValue(Columns.ProductName, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
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
		  
		[XmlAttribute("Weight")]
		[Bindable(true)]
		public string Weight 
		{
			get { return GetColumnValue<string>(Columns.Weight); }
			set { SetColumnValue(Columns.Weight, value); }
		}
		  
		[XmlAttribute("DateAdded")]
		[Bindable(true)]
		public DateTime? DateAdded 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateAdded); }
			set { SetColumnValue(Columns.DateAdded, value); }
		}
		  
		[XmlAttribute("Image")]
		[Bindable(true)]
		public string Image 
		{
			get { return GetColumnValue<string>(Columns.Image); }
			set { SetColumnValue(Columns.Image, value); }
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
		public static void Insert(int? varCategoryId,string varProductCode,string varProductName,string varDescription,decimal? varPrice,decimal? varCost,string varWeight,DateTime? varDateAdded,string varImage,bool? varActive)
		{
			Product item = new Product();
			
			item.CategoryId = varCategoryId;
			
			item.ProductCode = varProductCode;
			
			item.ProductName = varProductName;
			
			item.Description = varDescription;
			
			item.Price = varPrice;
			
			item.Cost = varCost;
			
			item.Weight = varWeight;
			
			item.DateAdded = varDateAdded;
			
			item.Image = varImage;
			
			item.Active = varActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varCategoryId,string varProductCode,string varProductName,string varDescription,decimal? varPrice,decimal? varCost,string varWeight,DateTime? varDateAdded,string varImage,bool? varActive)
		{
			Product item = new Product();
			
				item.Id = varId;
			
				item.CategoryId = varCategoryId;
			
				item.ProductCode = varProductCode;
			
				item.ProductName = varProductName;
			
				item.Description = varDescription;
			
				item.Price = varPrice;
			
				item.Cost = varCost;
			
				item.Weight = varWeight;
			
				item.DateAdded = varDateAdded;
			
				item.Image = varImage;
			
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
        
        
        
        public static TableSchema.TableColumn CategoryIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductCodeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PriceColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CostColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn WeightColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DateAddedColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string CategoryId = @"CategoryId";
			 public static string ProductCode = @"ProductCode";
			 public static string ProductName = @"ProductName";
			 public static string Description = @"Description";
			 public static string Price = @"Price";
			 public static string Cost = @"Cost";
			 public static string Weight = @"Weight";
			 public static string DateAdded = @"DateAdded";
			 public static string Image = @"Image";
			 public static string Active = @"Active";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
