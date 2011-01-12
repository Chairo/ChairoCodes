using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace CampuSys.Core.Log
{
    /// <summary>
    /// 创建日期：2008年7月18日
    /// 创 建 人：李维亮
    /// 功能描述：负责提供日志格式化方法
    /// </summary>
    public class LogFormat
    {

        /// <summary>
        ///   设置错误日志的格式
        /// </summary>
        /// <param name="ex">需要格式化的Exception对象</param>
        /// <returns>返回格式化字符串</returns>
        public virtual string FormatException(Exception ex)
        {
            return Format("Error Info ", ex.Message, ex.TargetSite);
        }

        public virtual string FormatException(string Message,MethodBase method)
        {
            return Format("Error Info ", Message, method);
        }

        /// <summary>
        ///   设置调试信息的格式
        /// </summary>
        /// <param name="Message">调试信息</param>
        /// <param name="method">调试的方法</param>
        /// <returns>返回格式化字符串</returns>
        public virtual  string FormatDebug(string Message,MethodBase method)
        {
            return Format("Debug Info ", Message, method);
        }

        protected string Format(string HeadText ,string Message,MethodBase method)
        {
            string formatMessage = String.Format(HeadText+":{0}.{1}----->{2}", method.DeclaringType.FullName, method.Name, Message);
            return formatMessage;
        }
    }
}
