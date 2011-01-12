using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CampuSys.Core.Data
{
    public class SqlServer : Database, IDatabase
    {

     


        public SqlServer(IConnectionConfig cfg):base(cfg)
        {
   
        }

   
        public DataSet ExecuteSql(string SqlText)
        {   
            try
            {
               using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
               {
                   if (conn.State != ConnectionState.Open)
                       conn.Open();
                   DataSet ds = new DataSet();
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = conn;
                   cmd.CommandText = SqlText;
                   try
                   {
                       SqlDataAdapter dpa = new SqlDataAdapter(cmd);
                       dpa.Fill(ds);
                   }
                   catch (Exception ex)
                   {
                       throw new SqlException(ExceptionMessage.SqlError(SqlText),ex);
                   }
                   return ds;
               }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
             
            }
        }

        public void Execute(string SqlText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = SqlText;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch 
                    {
                        throw new SqlException(ExceptionMessage.SqlError(SqlText));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
            }
        }

        public object ExecuteScalar(string SqlText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();   
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = SqlText;
                    try
                    {
                        return cmd.ExecuteScalar();
                    }
                    catch
                    {
                        throw new SqlException(ExceptionMessage.SqlError(SqlText));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
            }
        }

        public System.Data.DataTable ExecuteTable(string SqlText)
        {
            return ExecuteSql(SqlText).Tables[0];
        }

        public System.Data.DataRow ExecuteRow(string SqlText)
        {
            try
            {
                return ExecuteSql(SqlText).Tables[0].Rows[0];
            }
            catch 
            {
                throw new DBException(ExceptionMessage.DBNotFoundError);
            }
        }




        public System.Data.DataSet ExecuteSql(string SqlText, IDbDataParameter[] DBParams)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = SqlText;
                    if (DBParams != null)
                    {
                        foreach (IDbDataParameter parm in DBParams)
                        {
                            if (parm.Value == null)
                                parm.Value = System.Convert.DBNull;
                            cmd.Parameters.Add(parm);
                        }
                    }
                   
                    try
                    {
                        SqlDataAdapter dpa = new SqlDataAdapter(cmd);
                        dpa.Fill(ds);
                    }
                    catch
                    {
                        throw new SqlException(ExceptionMessage.SqlError(SqlText));
                    }
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
            }
        }

        public void Execute(string SqlText,IDbDataParameter[] DBParams)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = SqlText;
                    if (DBParams != null)
                    {
                        foreach (IDbDataParameter parm in DBParams)
                        {
                            if (parm.Value == null)
                                parm.Value = System.Convert.DBNull;
                            cmd.Parameters.Add(parm);
                        }
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw new SqlException(ExceptionMessage.SqlError(SqlText));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
            }
        }

        public object ExecuteScalar(string SqlText, System.Data.IDbDataParameter[] DBParams)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = SqlText;
                    if (DBParams != null)
                    {
                        foreach (IDbDataParameter parm in DBParams)
                        {
                            if (parm.Value == null)
                                parm.Value = System.Convert.DBNull;
                            cmd.Parameters.Add(parm);
                        }
                    }

                    try
                    {
                        return cmd.ExecuteScalar();
                    }
                    catch
                    {
                        throw new SqlException(ExceptionMessage.SqlError(SqlText));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
            }
        }

        public System.Data.DataTable ExecuteTable(string SqlText, System.Data.IDbDataParameter[] DBParams)
        {
            return ExecuteSql(SqlText, DBParams).Tables[0];
        }

        public System.Data.DataRow ExecuteRow(string SqlText, System.Data.IDbDataParameter[] DBParams)
        {
            try
            {
                return ExecuteSql(SqlText,DBParams).Tables[0].Rows[0];
            }
            catch
            {
                throw new DBException(ExceptionMessage.DBNotFoundError);
            }
        }

        public System.Data.IDbDataParameter CreateParam(string ParamName, object Value)
        {
            return new SqlParameter(ParamName, Value);   
        }

        public  void ExecuteList(IList<string> SqlList)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    try
                    {
                        for (int i = 0; i < SqlList.Count; i++)
                        {
                            cmd.CommandText = SqlList[i];
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw new SqlException(ExceptionMessage.SqlError(cmd.CommandText));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DBException(ex);
            }
        }

        public IDbDataParameter[] CreateParamArray(int Len)
        {
            return new SqlParameter[Len];
        }
        public object ExecuteWithTrans(TransExecute trans)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionConfig.ConnectionString))
                {
                    conn.Open();
                    return trans(conn, this);

                }
            }
            catch(Exception ex)
            {
                throw new DBException(ex);
            }
            
        }

    }
}
