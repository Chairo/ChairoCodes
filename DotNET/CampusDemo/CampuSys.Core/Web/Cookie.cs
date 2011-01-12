using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;

namespace CampuSys.Core.Web
{
    public class Cookie 
    {

        public static bool CookieExist(Page ObjPage, string strDomain, string strKey)
        {
            return (ObjPage.Request.Cookies[strDomain] != null) ? (ObjPage.Request.Cookies[strDomain][strKey] != null) : false;
        }

        public static string GetCookie(Page ObjPage, string strDomain, string strKey)
        {
            string str = string.Empty;
            if (CookieExist(ObjPage, strDomain, strKey))
                str = ObjPage.Request.Cookies[strDomain][strKey];
            return str;
        }


        public static void SetCookie(Page ObjPage, string strDomain, string strKey, string strValue)
        {
            HttpCookie cookie = ObjPage.Response.Cookies[strDomain];
            if (cookie == null)
            {
                cookie = new HttpCookie(strDomain);
            }
            cookie.Domain = strDomain;
            cookie.Values.Add(strKey, strValue);
            ObjPage.Response.SetCookie(cookie);
        }

    }
}
