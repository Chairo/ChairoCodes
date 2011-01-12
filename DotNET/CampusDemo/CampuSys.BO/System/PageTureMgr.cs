using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using CampuSys.Core.Web;
using CampuSys.Core.Text;

namespace CampuSys.BO.System
{
    public class PageTureMgr
    {
        public static void TurnEhrLoginPage(Page objPage, string ConfigName)
        {
            string fullURL = ServerParams.FullUrl(objPage);
            objPage.Response.Redirect(Config.GetConfig(ConfigName) + fullURL);
            objPage.Response.End();
        }
    }
}
