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
	/// Strongly-typed collection for the MenuPosition class.
	/// </summary>
    [Serializable]
	public partial class MenuPositionCollection : ActiveList<MenuPosition, MenuPositionCollection>
	{	   
		public MenuPositionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>MenuPositionCollection</returns>
		public MenuPositionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                MenuPosition o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblMenuPosition table.
	/// </summary>
	[Serializable]
	public partial class MenuPosition : ActiveRecord<MenuPosition>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public MenuPosition()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public MenuPosition(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public MenuPosition(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public MenuPosition(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblMenuPosition", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarPositionID = new TableSchema.TableColumn(schema);
				colvarPositionID.ColumnName = "PositionID";
				colvarPositionID.DataType = DbType.Int32;
				colvarPositionID.MaxLength = 0;
				colvarPositionID.AutoIncrement = false;
				colvarPositionID.IsNullable = true;
				colvarPositionID.IsPrimaryKey = false;
				colvarPositionID.IsForeignKey = false;
				colvarPositionID.IsReadOnly = false;
				colvarPositionID.DefaultSetting = @"";
				colvarPositionID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPositionID);
				
				TableSchema.TableColumn colvarMenuItemID = new TableSchema.TableColumn(schema);
				colvarMenuItemID.ColumnName = "MenuItemID";
				colvarMenuItemID.DataType = DbType.Int32;
				colvarMenuItemID.MaxLength = 0;
				colvarMenuItemID.AutoIncrement = false;
				colvarMenuItemID.IsNullable = true;
				colvarMenuItemID.IsPrimaryKey = false;
				colvarMenuItemID.IsForeignKey = false;
				colvarMenuItemID.IsReadOnly = false;
				colvarMenuItemID.DefaultSetting = @"";
				colvarMenuItemID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMenuItemID);
				
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
				colvarActive.DataType = DbType.Int32;
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
				DataService.Providers["LocalProvider"].AddSchema("tblMenuPosition",schema);
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
		  
		[XmlAttribute("PositionID")]
		[Bindable(true)]
		public int? PositionID 
		{
			get { return GetColumnValue<int?>(Columns.PositionID); }
			set { SetColumnValue(Columns.PositionID, value); }
		}
		  
		[XmlAttribute("MenuItemID")]
		[Bindable(true)]
		public int? MenuItemID 
		{
			get { return GetColumnValue<int?>(Columns.MenuItemID); }
			set { SetColumnValue(Columns.MenuItemID, value); }
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
		public int? Active 
		{
			get { return GetColumnValue<int?>(Columns.Active); }
			set { SetColumnValue(Columns.Active, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varPositionID,int? varMenuItemID,DateTime? varDateCreated,int? varActive)
		{
			MenuPosition item = new MenuPosition();
			
			item.PositionID = varPositionID;
			
			item.MenuItemID = varMenuItemID;
			
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
		public static void Update(int varId,int? varPositionID,int? varMenuItemID,DateTime? varDateCreated,int? varActive)
		{
			MenuPosition item = new MenuPosition();
			
				item.Id = varId;
			
				item.PositionID = varPositionID;
			
				item.MenuItemID = varMenuItemID;
			
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
        
        
        
        public static TableSchema.TableColumn PositionIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MenuItemIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string PositionID = @"PositionID";
			 public static string MenuItemID = @"MenuItemID";
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
