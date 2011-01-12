using WinSys=System;
using System.Collections.Generic;
using System.Text;
using CampuSys.BO.Data;
using CampuSys.Core.Data;
using System.Data;


namespace CampuSys.BO.Campus
{
    public class CampusJobDAO
    {
        public void Insert(CampusJob job)
        {

            IDatabase db = DataManager.CampusDB();
            WinSys.Int64 jobid = WinSys.Convert.ToInt64( db.ExecuteScalar("select isnull(max(job_id),0) from campus_job "))+1;

            
            string vsSql = @"INSERT INTO [campus_job]([company_id], [job_id], [dept_id], [user_id], [Industry_Category], [Major_Category], [Location], [Occupation_Category], [job_desc], [job_title], [job_url], [job_type], [apply_no], [headcount], [create_date], [update_date], [post_date], [end_date], [job_status], [is_html], [order_no], [Email], [SearchKeyWord], [IsAudit], [AuditDate], [AuditUserId])
                          VALUES({0}, {1}, {2},{3}, '{4}','{5}', '{6}', '{7}','{8}', '{9}', '{10}', {11},{12},{13},'{14}', '{15}', '{16}', '{17}', {18},{19}, {20}, '{21}','{22}',{23}, '{24}','{25}')";
            vsSql = WinSys.String.Format(vsSql, job.Company_id, jobid, job.Dept_id, job.User_id, job.Industry_Category, job.Major_Category, job.Location, job.Occupation_Category, job.Job_desc, job.Job_title, job.Job_url, job.Job_type, job.Apply_no, job.Headcount, job.Create_date, job.Update_date, job.Post_date, job.End_date, job.Job_status, job.Is_html, job.Order_no, job.Email, job.SearchKeyWord, job.IsAudit, job.AuditDate, job.AuditUserId);
            db.Execute(vsSql);
        }

        public int CampanyJobNum(string memId)
        {
            IDatabase db = DataManager.CampusDB();
            string strSql = "select count(*) from campus_job where company_id='" + memId + "'";
            DataTable dt = db.ExecuteTable(strSql);
            if (dt.Rows.Count == 0)
                return 0;
            else
                return WinSys.Convert.ToInt32(dt.Rows[0][0]);
        }

        public void Insert(string Memid,CampusJob job)
        {
            IDatabase db = DataManager.CampusDB();
            IDbDataParameter[] param = db.CreateParamArray(14);
            param[0] = db.CreateParam("@mem_id", Memid);
            param[1] = db.CreateParam("@user_id", job.User_id);
            param[2] = db.CreateParam("@Industry_Category", job.Industry_Category);
            param[3] = db.CreateParam("@Occupation_Category",job.Occupation_Category);
            param[4] = db.CreateParam("@Major_Category", job.Major_Category);
            param[5] = db.CreateParam("@Location", job.Location);
            param[6] = db.CreateParam("@job_title", job.Job_title);
            param[7] = db.CreateParam("@job_type", job.Job_type);
            param[8] = db.CreateParam("@job_desc", job.Job_desc);
            param[9] = db.CreateParam("@headcount", job.Headcount);
            param[10] = db.CreateParam("@order_no", job.Order_no);
            param[11] = db.CreateParam("@end_date", job.End_date);
            param[12] = db.CreateParam("@SearchKeyWord", job.SearchKeyWord);
            param[13] = db.CreateParam("@Email", job.Email);
            db.Execute("usp_campus_job_add", param);
        }
        public void Delete(CampusJob job)
        {
           
        }
        public void Delete(int jobid)
        {
           
        }

        public void Delete(string joblist)
        {
            IDatabase db = DataManager.CampusDB();
            string Strsql = "Delete from campus_job where job_id in ("+joblist+") ";
            db.ExecuteSql(Strsql);
        }
        public void Update(CampusJob job)
        {

        }
        public CampusJob Get(int jobid)
        {
            return null;
        }
        public IList<CampusJob>List()
        {
            return null;
        }

        public DataSet SearchJob(string strKeyWord
            , string strMC
            , string strJT
            , string strJL
            , string strDT
            , string strOC
            , string strIC
            , string strCS
            , string strCT
            , string strSort
            )
        {

            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT cj.company_id, ECI.mem_name AS CompanyName, cj.job_id, cj.Industry_Category, cj.Occupation_Category, cj.Major_Category, cj.Location AS LocationName"
                + ",  cj.job_title, cj.job_url, cj.job_type, JT.CodeNameCn AS JobType, cj.create_date"
                + ", cj.job_status, JS.CodeNameCn AS JobStatus, cj.SearchKeyWord"
                + " FROM  campus_job  cj"
                + " INNER JOIN ShareCode JS ON JS.CodeID=cj.job_status AND JS.ClassID=2"
                + " INNER JOIN ShareCode JT ON JT.CodeID=cj.job_type AND JT.ClassID=3"
                + " LEFT JOIN Ehr_Company_Info ECI ON ECI.mem_id=cj.company_id"
                + " WHERE IsAudit=1"
                ;
            if (strMC != null && strMC != string.Empty)
            {
                strSQL += " AND cj.Major_Category IN (" + strMC + ")";
            }
            if (strJT != null && strJT != string.Empty)
            {
                strSQL += " AND cj.job_type IN (" + strJT + ")";
            }
            if (strOC != null && strOC != string.Empty)
            {
                strSQL += " AND cj.Occupation_Category IN (" + strOC + ")";
            }
            if (strIC != null && strIC != string.Empty)
            {
                strSQL += " AND cj.Industry_Category IN (" + strIC + ")";
            }
            if (strCS != null && strCS != string.Empty)
            {
                strSQL += " AND ECI.size_id=" + strCS;
            }
            if (strCT != null && strCT != string.Empty)
            {
                strSQL += " AND ECI.type_id=" + strCT;
            }
            if (strJL != null && strJL != string.Empty)
            {
                string[] arrJL = strJL.Split(",".ToCharArray());
                strSQL += " AND (";
                for (int i = 0; i < arrJL.Length; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " OR ";
                    }
                    strSQL += "CHARINDEX('," + arrJL[i] + ",', ','+cj.Location+',')>0";
                }
                strSQL += ")";
            }
            if (strDT != null && strDT != string.Empty)
            {
                strSQL += " AND DATEDIFF(DAY, cj.create_date, GetDate())<=" + strDT;
            }
            if (strKeyWord != null && strKeyWord != "" && strKeyWord != string.Empty)
            {
                string strLike = strKeyWord.Replace(",", "");
                strSQL += " AND (CHARINDEX('" + strLike + "', ECI.mem_name) > 0"
                    + " OR CHARINDEX('" + strLike + "', cj.job_title) > 0"
                    + " OR CHARINDEX('" + strLike + "', cj.SearchKeyWord) > 0)";
            }
            strSQL += " AND cj.job_status=1 ";
            if (strSort != null)
            {
                strSQL += " ORDER BY " + strSort + ", cj.job_id DESC";
            }
            return db.ExecuteSql(strSQL);
        }


        public DataSet SearchJob(string strComId
            , string strKeyWord
            , string strMC
            , string strJT
            , string strJL
            , string strDT
            , string strOC
            , string strSort
            )
        {
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT cj.company_id, ECI.mem_name AS CompanyName, cj.job_id, cj.Industry_Category, cj.Occupation_Category, cj.Major_Category,  cj.Location AS LocationName"
                + ",  cj.job_title, cj.job_url, cj.job_type, JT.CodeNameCn AS JobType,  cj.create_date"
                + ", cj.job_status, JS.CodeNameCn AS JobStatus, cj.SearchKeyWord"

                + " FROM  campus_job cj"
                + " INNER JOIN ShareCode JS ON JS.CodeID=cj.job_status AND JS.ClassID=2"
                + " INNER JOIN ShareCode JT ON JT.CodeID=cj.job_type AND JT.ClassID=3"
                + " LEFT JOIN Ehr_Company_Info ECI ON ECI.mem_id=cj.company_id"
                + " WHERE IsAudit=1"
                + " AND cj.job_status=1"
                + " AND ECI.mem_id=" + strComId
                ;
            if (strMC != null && strMC != string.Empty)
            {
                strSQL += " AND cj.Major_Category IN (" + strMC + ")";
            }
            if (strJT != null && strJT != string.Empty)
            {
                strSQL += " AND cj.job_type IN (" + strJT + ")";
            }
            if (strOC != null && strOC != string.Empty)
            {
                strSQL += " AND cj.Occupation_Category IN (" + strOC + ")";
            }
            if (strJL != null && strJL != string.Empty)
            {
                string[] arrJL = strJL.Split(",".ToCharArray());
                strSQL += " AND (";
                for (int i = 0; i < arrJL.Length; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " OR ";
                    }
                    strSQL += "CHARINDEX('," + arrJL[i] + ",', ','+cj.Location+',')>0";
                }
                strSQL += ")";
            }
            if (strDT != null && strDT != string.Empty)
            {
                strSQL += " AND DATEDIFF(DAY, cj.create_date, GetDate())<=" + strDT;
            }
            if (strKeyWord != null && strKeyWord != "" && strKeyWord != string.Empty)
            {
                string strLike = strKeyWord.Replace(",","");
                strSQL += " AND (CHARINDEX('" + strLike + "', ECI.mem_name) > 0"
                    + " OR CHARINDEX('" + strLike + "', cj.job_title) > 0"
                    + " OR CHARINDEX('" + strLike + "', cj.SearchKeyWord) > 0)";
            }
            if (strSort != null)
            {
                strSQL += " ORDER BY " + strSort + ", cj.job_id DESC";
            }
            
            return db.ExecuteSql(strSQL);
        }



        public DataSet TopCompanys(int intNum, int intDay)
        {
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT TOP " + intNum.ToString() + " cj.company_id, ECI.mem_name AS CompanyName, SUM(cj.apply_no) AS ApplyNo"
                + " FROM  campus_job cj"
                + " LEFT JOIN Ehr_Company_Info ECI ON ECI.mem_id=cj.company_id"
                + " WHERE cj.IsAudit=1"
                + " AND cj.job_status=1"
                + " AND DATEDIFF(DAY, cj.post_date, GETDATE())<=" + intDay.ToString()
                + " GROUP BY cj.company_id, ECI.mem_name"
                + " ORDER BY ApplyNo DESC";

            return db.ExecuteSql(strSQL);
        }

        public DataSet TopJobs(int intNum, int intDay)
        {
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT TOP " + intNum.ToString() + " cj.company_id, cj.job_id"
             + ",  cj.job_title, cj.job_url"
             + " FROM  campus_job cj"
             + " WHERE cj.IsAudit=1"
             + " AND cj.job_status=1"
             + " AND DATEDIFF(DAY, cj.post_date, GETDATE())<=" + intDay.ToString()
             + " ORDER BY cj.apply_no DESC";

            return db.ExecuteSql(strSQL);
        }


        public DataSet CampusJobData(string job_id)
        {
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT  cj.job_id,"
                + "  cj.job_title, cj.job_url,  cj.apply_no"
                + " FROM campus_job  cj"
                + " Where cj.IsAudit = 1 AND cj.job_status = 1 AND cj.job_id IN (" + job_id + ")";

            return db.ExecuteSql(strSQL); ;
        }


        public DataSet CampusJobList(string mem_id, string strSort)
        {
            
            IDatabase db = DataManager.CampusDB();
            string strSQL = "Select 1";
            //string strSQL = "SELECT cj.company_id, cj.job_id, cj.dept_id, cj.Industry_Category, cj.Occupation_Category, cj.Major_Category, cj.Industry_Category AS IC, cj.Location, cj.Location AS LocationName"
            //    + ", cj.job_desc, cj.job_title, cj.job_type, JT.CodeNameCn AS JobType, cj.apply_no, headcount = CASE cj.headcount WHEN 0 THEN 'Èô¸É' ELSE STR(cj.headcount, LEN(cj.headcount)) END, cj.create_date, cj.update_date, cj.post_date, CONVERT(char(19), cj.end_date, 120) AS end_date, cj.job_status"
            //    + ", JS.CodeNameCn AS JobStatus, cj.is_html, cj.order_no, cj.SearchKeyWord, cj.Email"
            //    + ", cj.IsAudit, DBO.GetCode(cj.IsAudit, 4) AS AuditStatus"
            //    + ", cj.user_id AS CreateUser, cj.AuditDate, cj.AuditUserId"
            //    + " FROM  campus_job cj"
            //    + " INNER JOIN ShareCode JS ON JS.CodeID=cj.job_status AND JS.ClassID=2"
            //    + " INNER JOIN ShareCode JT ON JT.CodeID=cj.job_type AND JT.ClassID=3"
            //    + " AND cj.company_id='" + mem_id + "'  order by update_date desc";
            //    if (strSort != null)
            //    {
            //        strSQL += " ORDER BY " + strSort;
            //    }
                return db.ExecuteSql(strSQL);
        }


    }


}
