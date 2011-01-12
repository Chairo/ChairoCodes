using System;
using System.Collections.Generic;
using System.Text;
using CampuSys.Core.Web;
using System.Web.UI;
using System.Web;
using System.Collections;

namespace CampuSys.BO.System
{
    public class CookieManager
    {
        public const string Ehr_CookieDomain = "ehr5";
        public const string Ehr_CookieMemID = "Mem_ID";
        public const string CookieUserID = "UserID";


        public const string User_CookieDomain = "User";
        public const string User_CokkieHabit = "UserHabit";
        public const string User_CookieSeekerId = "SeekerId";
        public const string User_CookieJob = "CampusChannelViewedJobId";
        public const string User_CookieKeyWord = "CampusChannelKeyWordHistory";

        /// <summary>
        /// ªÒ»°Mem_Id
        /// </summary>
        public static string EhrMemId(Page ObjPage)
        {
            string strRet = Cookie.GetCookie(ObjPage, Ehr_CookieDomain, Ehr_CookieMemID);
            return strRet;
        }
        public static string GetSeekerID(Page ObjPage)
        {
            return CookieManager.GetCookieWithLog(ObjPage, User_CookieDomain, User_CookieSeekerId);
        }
        public static string UserID(Page Objpage)
        {
            return Cookie.GetCookie(Objpage, Ehr_CookieDomain, CookieUserID);
        }

        public static void SetMemID(Page objPage,string strValue)
        {
            Cookie.SetCookie(objPage, Ehr_CookieDomain, Ehr_CookieMemID, strValue);
        }
        public static string GetCookieWithLog(Page ObjPage, string C_COOKIE_DOMAIN, string strKey)
        {
            string s = string.Empty;
            bool flag = false;
            HttpCookie cookie = ObjPage.Request.Cookies[C_COOKIE_DOMAIN];
            if (cookie != null)
            {
                string[] strArray = ObjPage.Server.UrlDecode(cookie.Values.ToString()).Split("&".ToCharArray());
                Hashtable hashtable = new Hashtable();
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split("=".ToCharArray());
                    if (strArray2[1] != string.Empty)
                    {
                        flag = true;
                    }
                    hashtable.Add(strArray2[0], strArray2[1]);
                }
                if (flag && (hashtable[strKey] != null))
                {
                    s = hashtable[strKey].ToString();
                    s = ObjPage.Server.UrlDecode(s);
                }
            }
            return s;
        }

 

 




    }
}
