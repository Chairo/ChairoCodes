using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CampuSys.Core.Data
{

    public enum DatabaseType { SqlServer, Oracle, DB2, MySql, Access, PostgreSql, Excel, Other };


    public sealed class Convert
    {
        public DatabaseType ConvertToDBType(string dbType)
        {
            DatabaseType dbtype ;
            switch (dbType.ToUpper())
            {
                
                case "SQL":
                case "MSSQL":
                case "SQLSERVER": dbtype = DatabaseType.SqlServer;
                    break;
                case "ORA":
                case "ORACLE": dbtype = DatabaseType.Oracle;
                    break;
                case "DB2": dbtype = DatabaseType.DB2;
                    break;
                case "MYSQL": dbtype = DatabaseType.MySql;
                    break;
                case "ACCESS": dbtype = DatabaseType.Access;
                    break;
                case "POSTGRE":
                case "POSTGRESQL": dbtype = DatabaseType.PostgreSql;
                    break;
                case "EXCEL": dbtype = DatabaseType.Excel;
                    break;
                default :
                    dbtype = DatabaseType.Other;
                    break;
                  
            }
            return dbtype;
        }

       

    }
}
