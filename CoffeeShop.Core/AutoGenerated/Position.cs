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
	/// Strongly-typed collection for the Position class.
	/// </summary>
    [Serializable]
	public partial class PositionCollection : ActiveList<Position, PositionCollection>
	{	   
		public PositionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PositionCollection</returns>
		public PositionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Position o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblPositions table.
	/// </summary>
	[Serializable]
	public partial class Position : ActiveRecord<Position>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Position()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Position(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Position(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Position(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblPositions", TableType.Table, DataService.GetInstance("LocalProvider"));
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
				
				TableSchema.TableColumn colvarPositionX = new TableSchema.TableColumn(schema);
				colvarPositionX.ColumnName = "Position";
				colvarPositionX.DataType = DbType.String;
				colvarPositionX.MaxLength = 50;
				colvarPositionX.AutoIncrement = false;
				colvarPositionX.IsNullable = true;
				colvarPositionX.IsPrimaryKey = false;
				colvarPositionX.IsForeignKey = false;
				colvarPositionX.IsReadOnly = false;
				colvarPositionX.DefaultSetting = @"";
				colvarPositionX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPositionX);
				
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
				DataService.Providers["LocalProvider"].AddSchema("tblPositions",schema);
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
		  
		[XmlAttribute("PositionX")]
		[Bindable(true)]
		public string PositionX 
		{
			get { return GetColumnValue<string>(Columns.PositionX); }
			set { SetColumnValue(Columns.PositionX, value); }
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
		public static void Insert(string varPositionX,bool? varActive)
		{
			Position item = new Position();
			
			item.PositionX = varPositionX;
			
			item.Active = varActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varPositionX,bool? varActive)
		{
			Position item = new Position();
			
				item.Id = varId;
			
				item.PositionX = varPositionX;
			
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
        
        
        
        public static TableSchema.TableColumn PositionXColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string PositionX = @"Position";
			 public static string Active = @"Active";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
