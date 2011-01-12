using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
namespace CampuSys.Core.Web
{
    /// <summary>
    /// 创建日期：2008年7月18日
    /// 创 建 人：李维亮
    /// 功能描述：负责提供网页中的与服务器有关的参数。
    /// </summary>
    public sealed class ServerParams
    {


        public static HttpRequest ObjRequest
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        public static string KeyValue(string strKey)
        {
            return ObjRequest.ServerVariables[strKey];
        }

        public static string ClientIP
        {
            get
            {
                return KeyValue("REMOTE_ADDR");
            }
        }

        public static string ClientLanguage
        {
            get
            {
                return KeyValue("HTTP_ACCEPT_LANGUAGE");
            }
        }

        public static string ClientSoftWare
        {
            get
            {
                return KeyValue("HTTP_USER_AGENT");
            }
        }

        public static string Cookie
        {
            get
            {
                return KeyValue("HTTP_COOKIE");
            }
        }

      

        public static string ServerIP
        {
            get
            {
                return KeyValue("REMOTE_ADDR");
            }
        }

        public static string UrlParam
        {
            get
            {
                return KeyValue("QUERY_STRING");
            }
        }

        public static string PriorPage
        {
            get
            {
                return KeyValue("HTTP_REFERER");
            }
        }
        public static string ServerName
        {
            get
            {
                return KeyValue("SERVER_NAME");
            }
        }
        public static string Url
        {
            get
            {
                return KeyValue("URL");
            }
        }

        public static string Protocol
        {
            get
            {
                string _protocol = KeyValue("server_protocol");
                return _protocol.Substring(0,_protocol.IndexOf('/')).ToLower();
            }
        }
        public static string FullUrl(Page objPage)
        {
            string str = ServerParams.Protocol + "://" + objPage.Request.ServerVariables["HTTP_HOST"] + objPage.Request.ServerVariables["URL"];
            string str2 = objPage.Request.ServerVariables["QUERY_STRING"];
            if (str2 != string.Empty)
            {
                str = str + "?" + str2;
            }
            return str;

        }
        public static string FullURL
        {
            get
            {
                string str = ServerParams.Protocol+"://" + ServerParams.ServerName + ServerParams.Url;
                string str2 = ServerParams.UrlParam;
                if (str2 != string.Empty)
                {
                    str = str + "?" + str2;
                }
                return str;
            }
           
        }


    }
}
