using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Reflection;
using System.Diagnostics;

namespace CampuSys.Core.Log
{
    /// <summary>
    /// 创建日期：2008年7月18日
    /// 创 建 人：李维亮
    /// 功能描述：负责提供与日志相关的操作
    /// </summary>
    public sealed class CommonLog
    {

        public static ILog LogMgr = LogManager.GetLogger(MethodInfo.GetCurrentMethod().DeclaringType);
        public static void Error(string Message)
        {
            if (CommonLog.LogMgr.IsErrorEnabled)
            {
                CommonLog.LogMgr.Error(new LogFormat().FormatException(Message, new StackTrace().GetFrame(1).GetMethod()));
            }
        }

        /// <summary>
        ///  保存错误日志
        /// </summary>
        /// <param name="ex">出错抛出的Exception对象</param>

        public static void Error(Exception ex)
        {
            if (ex.TargetSite!=null)
            {
                if (CommonLog.LogMgr.IsErrorEnabled)
                    CommonLog.LogMgr.Error(new LogFormat().FormatException(ex));
            }
            else
            {
                CommonLog.LogMgr.Error(ex.Message);
            }
        }

        /// <summary>
        ///  保存调试信息
        /// </summary>
        /// <param name="Message">调试信息</param>
        public static void Debug(string Message)
        {
            if (CommonLog.LogMgr.IsDebugEnabled)
                CommonLog.LogMgr.Debug(new LogFormat().FormatDebug(Message, new StackTrace().GetFrame(1).GetMethod()));
        }
    }
}
