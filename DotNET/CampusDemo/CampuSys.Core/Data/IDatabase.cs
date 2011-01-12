using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CampuSys.Core.Data
{

    public delegate object TransExecute(IDbConnection conn,IDatabase db);
    public interface IDatabase
    {
        DataSet ExecuteSql(string SqlText);
        void Execute(string SqlText);
        Object ExecuteScalar(string SqlText);
        DataTable ExecuteTable(string SqlText);
        DataRow ExecuteRow(string SqlText);

        DataSet ExecuteSql(string SqlText, IDbDataParameter[] DBParams);
        void Execute(string SqlText, IDbDataParameter[] DBParams);
        Object ExecuteScalar(string SqlText, IDbDataParameter[] DBParams);
        DataTable ExecuteTable(string SqlText,IDbDataParameter[] DBParams);
        DataRow ExecuteRow(string SqlText, IDbDataParameter[] DBParams);

        void ExecuteList(IList<string> SqlList);
        IDbDataParameter CreateParam(string ParamName, object Value);
        IDbDataParameter[] CreateParamArray(int Len);
        object ExecuteWithTrans(TransExecute trans);

       

    }
}
