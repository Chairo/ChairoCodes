using System;
using System.Collections.Generic;
using System.Text;
using CampuSys.Core.Data;

namespace CampuSys.BO.Data
{
    public class DataManager
    {
        public static IDatabase CampusDB()
        {
            return CampuSys.Core.Data.DatabaseFactory.GetCurrentDatabase(new CampusDBConfig());
        }
    }
}
