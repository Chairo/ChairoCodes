using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core.Data
{
    public class SqlException : DBException
    {
         public SqlException()
         {

         }
        public SqlException(string Message)
            : base(Message)
         {

         }
        public SqlException(string Message,Exception ex):base(Message,ex)
        {

        }
        

    }
}
