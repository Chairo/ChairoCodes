using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CampuSys.BO.Campus
{
    public class CampusJob
    {
        private int _company_id = 0;
        private int _job_id=0;
        private int _dept_id = 0;
        private int _user_id = 0;
        private string _Industry_Category = String.Empty;
        private string _Major_Category = String.Empty;
        private string _Location = String.Empty;
        private string _Occupation_Category = String.Empty;
        private string _job_desc = String.Empty;
        private string _job_title = String.Empty;
        private string _job_url = String.Empty;
        private int _job_type = 0;
        private int _apply_no = 0;
        private int _headcount = 0;
        private DateTime _create_date = DateTime.Now;
        private DateTime _update_date = DateTime.Now;
        private DateTime _post_date = DateTime.Now;
        private DateTime _end_date = DateTime.Now;
        private int _job_status = 0;

        private int _is_html = 0;
        private int _order_no = 0;
        private string _Email = String.Empty;
        private string _SearchKeyWord = String.Empty;
        private int _IsAudit = 0;
        private DateTime _AuditDate = DateTime.Now;
        private string _AuditUserId = String.Empty;




        public int Company_id
        {
            get { return _company_id; }
            set { _company_id = value; }
        }
	    public int Job_id
	    {
		    get { return _job_id; }
		    set { _job_id = value; }
	    }
           
	    public int Dept_id
	    {
		    get { return _dept_id; }
		    set { _dept_id = value; }
	    }
       
	    public int User_id
	    {
		    get { return _user_id; }
		    set { _user_id = value; }
	    }

	    public string Industry_Category
	    {
		    get { return _Industry_Category; }
		    set { _Industry_Category = value; }
	    }

	    public string Major_Category
	    {
		    get { return _Major_Category; }
		    set { _Major_Category = value; }
	    }

	    public string Location
	    {
		    get { return _Location; }
		    set { _Location = value; }
	    }

	    public string Occupation_Category
	    {
		    get { return _Occupation_Category; }
		    set { _Occupation_Category = value; }
	    }

	    public string Job_desc
	    {
		    get { return _job_desc; }
		    set { _job_desc = value; }
	    }
     

	    public string Job_title
	    {
		    get { return _job_title; }
		    set { _job_title = value; }
	    }


	    public string Job_url
	    {
		    get { return _job_url; }
		    set { _job_url = value; }
	    }

        public int Job_type
        {
            get { return _job_type; }
            set { _job_type = value; }
        }

	    public int Apply_no
	    {
		    get { return _apply_no; }
		    set { _apply_no = value; }
	    }

	    public int Headcount
	    {
		    get { return _headcount; }
		    set { _headcount = value; }
	    }

	    public DateTime Create_date
	    {
		    get { return _create_date; }
		    set { _create_date = value; }
	    }

	    public DateTime Update_date
	    {
		    get { return _update_date; }
		    set { _update_date = value; }
	    }

	    public DateTime Post_date
	    {
		    get { return _post_date; }
		    set { _post_date = value; }
	    }

	    public DateTime End_date
	    {
		    get { return _end_date; }
		    set { _end_date = value; }
	    }
        public int Job_status
        {
            get { return _job_status; }
            set { _job_status = value; }
        }
	    public int Is_html
	    {
		    get { return _is_html; }
		    set { _is_html = value; }
	    }

	    public int Order_no
	    {
		    get { return _order_no; }
		    set { _order_no = value; }
	    }

	    public string Email
	    {
		    get { return _Email; }
		    set { _Email = value; }
	    }

	    public string SearchKeyWord
	    {
		    get { return _SearchKeyWord; }
		    set { _SearchKeyWord = value; }
	    }

	    public int IsAudit
	    {
		    get { return _IsAudit; }
		    set { _IsAudit = value; }
	    }

	    public DateTime AuditDate
	    {
		    get { return _AuditDate; }
		    set { _AuditDate = value; }
	    }


        public string AuditUserId
        {
            get { return _AuditUserId; }
            set { _AuditUserId = value; }
        }

        public CampusJob()
        {

        }
        public CampusJob(DataRow dr)
        {
            if (dr!=null)
            {
                 _company_id =Convert.ToInt32(dr["company_id"]) ;
                 _job_id = Convert.ToInt32(dr["job_id"]);
                 _dept_id = Convert.ToInt32(dr["dept_id"]);
                 _user_id = Convert.ToInt32(dr["user_id"]);
                 _Industry_Category = dr["Industry_Category"].ToString();
                 _Major_Category = dr["Major_Category"].ToString();
                 _Location = dr["Location"].ToString();
                 _Occupation_Category = dr["Occupation_Category"].ToString();
                 _job_desc = dr["job_desc"].ToString();
                 _job_title = dr["job_title"].ToString();
                 _job_url = dr["job_url"].ToString();
                 _job_type = Convert.ToInt32(dr["job_type"]);
                 _apply_no = Convert.ToInt32(dr["apply_no"]);
                 _headcount = Convert.ToInt32(dr["headcount"]);
                 _create_date = Convert.ToDateTime(dr["create_date"]);
                 _update_date = Convert.ToDateTime(dr["update_date"]);
                  _post_date = Convert.ToDateTime(dr["post_date"]);
                  _end_date = Convert.ToDateTime(dr["end_date"]);
                 _is_html = Convert.ToInt32(dr["intis_html"]);
                 _job_status = Convert.ToInt32(dr["job_status"]);
                 _order_no = Convert.ToInt32(dr["intorder_no"]);
                 _Email = dr["Email"].ToString();
                 _SearchKeyWord = dr["SearchKeyWord"].ToString();
                 _IsAudit = Convert.ToInt32(dr["IsAudit"]);
                  _AuditDate = Convert.ToDateTime(dr["AuditDate"]);
                 _AuditUserId = dr["AuditUserId"].ToString();

            }
        }

    }
}
