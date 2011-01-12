using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Data
{
    public class Database
    {
        private IConnectionConfig conncfg;
        public IConnectionConfig ConnectionConfig
        {
            get { return conncfg; }
        }
         public Database(IConnectionConfig cfg)
        {
            if (cfg.DBType == DatabaseType.Other || cfg == null)
                throw new DBException(ExceptionMessage.DBTypeError);
            conncfg = cfg;
        }

      
       
    }
}
