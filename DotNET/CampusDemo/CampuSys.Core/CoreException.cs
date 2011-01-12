using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core
{
    /// <summary>
    /// �������ڣ�2008��7��17��
    /// �� �� �ˣ���ά��
    /// ����������Core�����쳣��
    /// </summary>
    public class CoreException:ApplicationException
    {
         public CoreException()
         {
             
         }
        public CoreException(string Message)
            : base(Message)
         {
             Log.CommonLog.Error(Message);
         }
        public override string Message
        {
            get { return (CoreSys.MaskError? ExceptionMessage.Error : base.Message); }
        }
        public CoreException(Exception ex) : base(ex.Message, ex)
        {
            Log.CommonLog.Error(ex);
        }
        public CoreException(string Message,Exception ex):base(Message,ex)
        {
            Log.CommonLog.Error(ex);
        }
    }
}
