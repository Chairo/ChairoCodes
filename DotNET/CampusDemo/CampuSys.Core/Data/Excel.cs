using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Data
{
    public class Excel :Database
    {
        public Excel(IConnectionConfig cfg)
            : base(cfg)
        {
        }
    }
}
