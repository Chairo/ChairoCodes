using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Text
{
    public class CommonText
    {

        public static string IsNull(string strSrc, string strDefault)
        {
            string str = strSrc;
            if (((strSrc != null) && !(strSrc == "")) && !(strSrc == string.Empty))
            {
                return str;
            }
            return strDefault;
        }
        public static string toHtml(string strSrc)
        {
            string str = strSrc;
            return str.Replace("&lt;", "<").Replace("&gt;", ">");
        }

        public static string LimitLen(string strSrc, string strLimit, int intLen)
        {
            string strRet = strSrc;
            if (strRet.Length > intLen)
            {
                strRet = strRet.Substring(0, intLen) + strLimit;
            }
            return strRet;
        }

        public static string PartStr(string Str,char Sep,int Num)
        {
            string[] temp = Str.Split(Sep);
            if (Num >= temp.Length)
                return Str;
            else
            {
                string Strtemp="";
                for (int i = 0; i < Num; i++)
                    Strtemp += temp[i]+Sep.ToString();
                return Strtemp.Substring(0,Strtemp.Length-1);
            }

        }
    }
}
