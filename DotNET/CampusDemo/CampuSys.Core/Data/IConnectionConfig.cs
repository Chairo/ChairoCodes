using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Data
{

    public interface IConnectionConfig
    {
        string ConnectionString
        {
            get;
        }
        DatabaseType DBType
        {
           get;
        }
    }
}
