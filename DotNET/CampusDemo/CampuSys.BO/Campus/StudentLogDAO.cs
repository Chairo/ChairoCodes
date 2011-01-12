using System;
using System.Collections.Generic;
using System.Text;
using CampuSys.Core.Data;
using CampuSys.BO.Data;
using System.Data;
using CampuSys.Core.Text;

namespace CampuSys.BO.Campus
{
    public class StudentLogDAO
    {





       

        // 是否已经有记录
        public bool Exist(long userid)
        {
            IDatabase db = DataManager.CampusDB();
            string strSql = "Select * From campuschannel_student_log where skr_id='" + userid + "'";
            DataTable dt = db.ExecuteTable(strSql);
            return dt.Rows.Count > 0;
          
        }

        // 插入MtLog
        public void Insert(StudentLog log)
        {
            if (log.skr_id!=0)
            {
                if (log.keyword_history.Trim()!=SearchCondition.KeyWordDefault)
                {

               
                IDatabase db = DataManager.CampusDB();
                if (Exist(log.skr_id) == true)
                {
                    Update(log);
                }
                else
                {
                    string strSQL = "INSERT INTO campuschannel_student_log (skr_id, viewed_job, keyword_history)"
                        + " VALUES({0}, '{1}', '{2}')";
                    strSQL = string.Format(strSQL, log.skr_id, log.viewed_job, log.keyword_history);
                    db.Execute(strSQL);
                }
               }
            }
        }

        public void Update(StudentLog log)
        {
        
            IDatabase db = DataManager.CampusDB();

            string strSQL = "UPDATE campuschannel_student_log SET";
            string strField = "";
            if (log.viewed_job != "" && log.viewed_job != null)
            {
                strField += " viewed_job=substring( '{1},'+view_job,1,1024)";
            }
            if (log.keyword_history != "" && log.keyword_history != null)
            {
                strField += " keyword_history=substring('{2},'+keyword_history,1,1024)";
            }
            if (strField.Trim()!="")
            {

                strSQL += strField;
            strSQL += " WHERE skr_id={0}";
            strSQL = string.Format(strSQL, log.skr_id, log.viewed_job, log.keyword_history);
            db.Execute(strSQL);
           }
            
        }









        public string GetViewJobs(string userid,int viewNum)
        {
            if (userid == "")
                return "''";
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT  viewed_job FROM "
                + "campuschannel_student_log "
                + " WHERE skr_id='" + userid + "'";
            DataSet ds = db.ExecuteSql(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
                return "''";
            else if (ds.Tables[0].Rows[0][0].ToString().Trim() == "")
                return "''";
            else
               return CommonText.PartStr(ds.Tables[0].Rows[0][0].ToString(),',',viewNum);

        }
        public string GetKeyWord(string userid,int keyNum)
        {
            if (userid == "")
                return "''";
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT  keyword_history FROM "
                + "campuschannel_student_log "
                + " WHERE skr_id='" + userid + "'";
            DataSet ds = db.ExecuteSql(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
                return "";
            else if (ds.Tables[0].Rows[0][0].ToString().Trim() == "")
                return "''";
            else
                return CommonText.PartStr(ds.Tables[0].Rows[0][0].ToString(), ',', keyNum);
      
        }
    }
}
