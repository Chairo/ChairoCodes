using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Data
{
    public class DatabaseFactory
    {
        public static IDatabase GetCurrentDatabase(IConnectionConfig cfg)
        {
            IDatabase database=null;
            switch (cfg.DBType)
            {
                case DatabaseType.SqlServer: database = new SqlServer(cfg);
                    break;
                default:
                    database = null;
                    break;
            }
            return database;
        }
    }
}
