using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core
{
    public class ExceptionMessage
    {
        public static string Error = "系统出现异常，请稍候再试！";
        public static string DBTypeError = "无效的数据库类型，请检查配置文件的数据库类型！";
        public static string DBConnectError = "无法连接到数据库，请检查配置文件中的连接字符串！";
        public static string DBNotFoundError = "数据不存在，请检查查询条件！";




        public static string SqlError (string SqlText)
        {
            return "出错SQL语句为：" + SqlText;
        }

    }

}
