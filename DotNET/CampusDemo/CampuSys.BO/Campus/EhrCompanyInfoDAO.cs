using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CampuSys.Core.Data;
using CampuSys.BO.Data;

namespace CampuSys.BO.Campus
{
    public class EhrCompanyInfoDAO
    {

        public DataSet  GetCompany(string compid)
        {
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT mem_id, mem_name, mem_abbr, licence_no, type_id, size_id, loc_id, address, zipcode, mem_url, email_type, linkman_name, linkman_title, linkman_gender, email, telephone, fax, intro, ind_id1, ind_id2, ind_id3, reg_date, reg_ip, last_update_date, last_login_user, last_search, last_login_date, login_count, job_option, savecv_table, apply_form, logo, job_quota,job_offlinedays"
                + " FROM Ehr_Company_Info"
                + " WHERE mem_id IN (" + compid + ")";
            return db.ExecuteSql(strSQL);
        }

        public EhrCompanyInfo  GetCompanyByID(string compid)
        {
            IDatabase db = DataManager.CampusDB();
            string strSQL = "SELECT mem_id, mem_name, mem_abbr, licence_no, type_id, size_id, loc_id, address, zipcode, mem_url, email_type, linkman_name, linkman_title, linkman_gender, email, telephone, fax, intro, ind_id1, ind_id2, ind_id3, reg_date, reg_ip, last_update_date, last_login_user, last_search, last_login_date, login_count, job_option, savecv_table, apply_form, logo, job_quota,job_offlinedays"
                + " FROM Ehr_Company_Info"
                + " WHERE mem_id IN (" + compid + ")";
            return new EhrCompanyInfo(db.ExecuteRow(strSQL));
        }

    }
}
