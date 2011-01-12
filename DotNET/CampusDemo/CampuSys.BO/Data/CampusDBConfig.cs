using System;
using System.Collections.Generic;
using System.Text;
using CampuSys.Core.Data;
namespace CampuSys.BO.Data
{
    public class CampusDBConfig:IConnectionConfig
    {

      
        public string ConnectionString
        {
            get { return CampuSys.Core.Text.Config.GetConfig("CampusJobConnString"); }
        }

        public DatabaseType DBType
        {
            get { return CampuSys.Core.Data.DatabaseType.SqlServer; }
        }

      
    }
}
