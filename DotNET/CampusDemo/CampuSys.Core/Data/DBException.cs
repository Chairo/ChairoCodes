using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Data
{
     public class DBException:CoreException
    {
              public DBException()
         {

         }
         public DBException(string Message)
            : base(Message)
         {

         }
         public DBException(Exception ex): base( ex)
        {
          
        }
         public DBException(string Message,Exception ex):base(Message,ex)
         {

         }
    }
}
