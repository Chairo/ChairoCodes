using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core
{
    /// <summary>
    /// 创建日期：2008年7月17日
    /// 创 建 人：李维亮
    /// 功能描述：Core公用异常类
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
