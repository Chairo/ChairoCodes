using System;
using System.Collections.Generic;
using System.Text;
using CampuSys.Core.Data;
using CampuSys.BO.Data;
using CampuSys.Core.Web;

namespace CampuSys.BO.Campus
{ 
    public  class CampusSearchLogDAO
    {

        public void Insert(CampusSearchLog log)
        {

            log.otherkey = "";
            log.user_ip = ServerParams.ClientIP;
            log.user_software =ServerParams.ClientSoftWare;
            log.user_language =ServerParams.ClientLanguage ;
            log.url_other_param = ServerParams.UrlParam;
            log.user_cookie = ServerParams.Cookie != null ? ServerParams.Cookie : " ";
            if (log.user_cookie.Length >= 255)
                log.user_cookie = log.user_cookie.Substring(0, 255);

            IDatabase db = DataManager.CampusDB();
            string strSQL = "INSERT INto  campus_job_search_log(user_id, keyword, major, location, publishtime, jobtype, occupation, otherkey, user_ip, user_software, user_cookie, url_other_param, user_language)"
                + " VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')";
            strSQL = String.Format(strSQL, log.user_id, log.keyword, log.major, log.location, log.publishtime, log.jobtype, log.occupation, log.otherkey, log.user_ip, log.user_software,log.user_cookie, log.url_other_param, log.user_language);
            db.Execute(strSQL);
        }
        public void Insert(SearchCondition condition)
        {
            CampusSearchLog log = new CampusSearchLog();
            log.keyword = condition.KeyWord;
            log.major = condition.MajorCategory;
            log.location = condition.JobLocation;
            log.publishtime = condition.JobDateTime;
            log.jobtype = condition.JobType;
            log.occupation = condition.OccupationCategory;
            this.Insert(log);
        }
    }
}
