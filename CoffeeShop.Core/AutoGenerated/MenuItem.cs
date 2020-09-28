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
	/// Strongly-typed collection for the MenuItem class.
	/// </summary>
    [Serializable]
	public partial class MenuItemCollection : ActiveList<MenuItem, MenuItemCollection>
	{	   
		public MenuItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MenuItemCollection</returns>
		public MenuItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MenuItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblMenuItems table.
	/// </summary>
	[Serializable]
	public partial class MenuItem : ActiveRecord<MenuItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MenuItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MenuItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MenuItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MenuItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblMenuItems", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarItemText = new TableSchema.TableColumn(schema);
				colvarItemText.ColumnName = "ItemText";
				colvarItemText.DataType = DbType.String;
				colvarItemText.MaxLength = 200;
				colvarItemText.AutoIncrement = false;
				colvarItemText.IsNullable = true;
				colvarItemText.IsPrimaryKey = false;
				colvarItemText.IsForeignKey = false;
				colvarItemText.IsReadOnly = false;
				colvarItemText.DefaultSetting = @"";
				colvarItemText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItemText);
				
				TableSchema.TableColumn colvarItemName = new TableSchema.TableColumn(schema);
				colvarItemName.ColumnName = "ItemName";
				colvarItemName.DataType = DbType.String;
				colvarItemName.MaxLength = 200;
				colvarItemName.AutoIncrement = false;
				colvarItemName.IsNullable = true;
				colvarItemName.IsPrimaryKey = false;
				colvarItemName.IsForeignKey = false;
				colvarItemName.IsReadOnly = false;
				colvarItemName.DefaultSetting = @"";
				colvarItemName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarItemName);
				
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
				
				TableSchema.TableColumn colvarParentId = new TableSchema.TableColumn(schema);
				colvarParentId.ColumnName = "ParentId";
				colvarParentId.DataType = DbType.Int32;
				colvarParentId.MaxLength = 0;
				colvarParentId.AutoIncrement = false;
				colvarParentId.IsNullable = true;
				colvarParentId.IsPrimaryKey = false;
				colvarParentId.IsForeignKey = false;
				colvarParentId.IsReadOnly = false;
				colvarParentId.DefaultSetting = @"";
				colvarParentId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarParentId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["LocalProvider"].AddSchema("tblMenuItems",schema);
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
		  
		[XmlAttribute("ItemText")]
		[Bindable(true)]
		public string ItemText 
		{
			get { return GetColumnValue<string>(Columns.ItemText); }
			set { SetColumnValue(Columns.ItemText, value); }
		}
		  
		[XmlAttribute("ItemName")]
		[Bindable(true)]
		public string ItemName 
		{
			get { return GetColumnValue<string>(Columns.ItemName); }
			set { SetColumnValue(Columns.ItemName, value); }
		}
		  
		[XmlAttribute("DateCreated")]
		[Bindable(true)]
		public DateTime? DateCreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateCreated); }
			set { SetColumnValue(Columns.DateCreated, value); }
		}
		  
		[XmlAttribute("ParentId")]
		[Bindable(true)]
		public int? ParentId 
		{
			get { return GetColumnValue<int?>(Columns.ParentId); }
			set { SetColumnValue(Columns.ParentId, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varItemText,string varItemName,DateTime? varDateCreated,int? varParentId)
		{
			MenuItem item = new MenuItem();
			
			item.ItemText = varItemText;
			
			item.ItemName = varItemName;
			
			item.DateCreated = varDateCreated;
			
			item.ParentId = varParentId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varItemText,string varItemName,DateTime? varDateCreated,int? varParentId)
		{
			MenuItem item = new MenuItem();
			
				item.Id = varId;
			
				item.ItemText = varItemText;
			
				item.ItemName = varItemName;
			
				item.DateCreated = varDateCreated;
			
				item.ParentId = varParentId;
			
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
        
        
        
        public static TableSchema.TableColumn ItemTextColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ItemNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ParentIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string ItemText = @"ItemText";
			 public static string ItemName = @"ItemName";
			 public static string DateCreated = @"DateCreated";
			 public static string ParentId = @"ParentId";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
