using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CampuSys.Core.Text
{
    public class Config
    {
        public static string GetConfig(string strKey)
        {
            return  ConfigurationManager.AppSettings[strKey];
        }

    }
}
