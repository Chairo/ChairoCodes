using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace CampuSys.BO.System
{
    public class Session
    {
        public  const string EhrLoginUrl ="ehr5CheckLogURL";
        public static void CheckEhrLogin(Page objPage)
        {
            if (CookieManager.EhrMemId(objPage)==String.Empty)
            {
                PageTureMgr.TurnEhrLoginPage(objPage, EhrLoginUrl);
            }

        }
    }
}
