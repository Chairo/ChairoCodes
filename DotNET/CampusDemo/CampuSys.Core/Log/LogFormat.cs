using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace CampuSys.Core.Log
{
    /// <summary>
    /// �������ڣ�2008��7��18��
    /// �� �� �ˣ���ά��
    /// ���������������ṩ��־��ʽ������
    /// </summary>
    public class LogFormat
    {

        /// <summary>
        ///   ���ô�����־�ĸ�ʽ
        /// </summary>
        /// <param name="ex">��Ҫ��ʽ����Exception����</param>
        /// <returns>���ظ�ʽ���ַ���</returns>
        public virtual string FormatException(Exception ex)
        {
            return Format("Error Info ", ex.Message, ex.TargetSite);
        }

        public virtual string FormatException(string Message,MethodBase method)
        {
            return Format("Error Info ", Message, method);
        }

        /// <summary>
        ///   ���õ�����Ϣ�ĸ�ʽ
        /// </summary>
        /// <param name="Message">������Ϣ</param>
        /// <param name="method">���Եķ���</param>
        /// <returns>���ظ�ʽ���ַ���</returns>
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
