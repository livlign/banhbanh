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
namespace Subsonic2{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the spGetOrderItems Procedure
        /// </summary>
        public static StoredProcedure SpGetOrderItems(int? orderid)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spGetOrderItems", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@orderid", orderid, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the spSaleReport Procedure
        /// </summary>
        public static StoredProcedure SpSaleReport(DateTime? fromDate, DateTime? toDate, string username)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spSaleReport", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@fromDate", fromDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@toDate", toDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@username", username, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the spSaleReportByDate Procedure
        /// </summary>
        public static StoredProcedure SpSaleReportByDate(DateTime? fromDate, DateTime? toDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spSaleReportByDate", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@fromDate", fromDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@toDate", toDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the spSaleReportByProduct Procedure
        /// </summary>
        public static StoredProcedure SpSaleReportByProduct(DateTime? fromDate, DateTime? toDate, int? categoryid)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spSaleReportByProduct", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@fromDate", fromDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@toDate", toDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@categoryid", categoryid, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the spSaleReportByProductDate Procedure
        /// </summary>
        public static StoredProcedure SpSaleReportByProductDate(DateTime? fromDate, DateTime? toDate, int? productid)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spSaleReportByProductDate", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@fromDate", fromDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@toDate", toDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@productid", productid, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the spVoucherStats Procedure
        /// </summary>
        public static StoredProcedure SpVoucherStats(DateTime? fromdate, DateTime? todate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spVoucherStats", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@fromdate", fromdate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@todate", todate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the spVoucherTotal Procedure
        /// </summary>
        public static StoredProcedure SpVoucherTotal(DateTime? fromdate, DateTime? todate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("spVoucherTotal", DataService.GetInstance("LocalProvider"), "dbo");
        	
            sp.Command.AddParameter("@fromdate", fromdate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@todate", todate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
    }
    
}
