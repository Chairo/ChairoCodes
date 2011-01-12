using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Reflection;
using System.Diagnostics;

namespace CampuSys.Core.Log
{
    /// <summary>
    /// �������ڣ�2008��7��18��
    /// �� �� �ˣ���ά��
    /// ���������������ṩ����־��صĲ���
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
        ///  ���������־
        /// </summary>
        /// <param name="ex">�����׳���Exception����</param>

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
        ///  ���������Ϣ
        /// </summary>
        /// <param name="Message">������Ϣ</param>
        public static void Debug(string Message)
        {
            if (CommonLog.LogMgr.IsDebugEnabled)
                CommonLog.LogMgr.Debug(new LogFormat().FormatDebug(Message, new StackTrace().GetFrame(1).GetMethod()));
        }
    }
}
