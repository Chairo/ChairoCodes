using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CampuSys.BO.Campus
{
    public class CampusSearchLog
    {
        #region 
		private    long       _log_id            = 0;
		private    string     _user_id           = String.Empty;
		private    DateTime   _searchtime       ;
		private    string     _keyword           = String.Empty;
		private    string     _major             = String.Empty;
		private    string     _location          = String.Empty;
		private    string     _publishtime       = String.Empty;
		private    string     _jobtype           = String.Empty;
		private    string     _occupation        = String.Empty;
		private    string     _otherkey          = String.Empty;
		private    string     _user_ip           = String.Empty;
		private    string     _user_software     = String.Empty;
		private    string     _user_cookie       = String.Empty;
		private    string     _user_language     = String.Empty;
		private    string     _url_other_param   = String.Empty;
		#endregion
		
		#region 		
		public long log_id
		{
			get {return _log_id           ;}
			set {_log_id            = value;}
		}

		public string user_id
		{
			get {return _user_id          ;}
			set {_user_id           = value;}
		}

		public DateTime searchtime
		{
			get {return _searchtime       ;}
			set {_searchtime        = value;}
		}

		public string keyword
		{
			get {return _keyword          ;}
			set {_keyword           = value;}
		}

		public string major
		{
			get {return _major            ;}
			set {_major             = value;}
		}

		public string location
		{
			get {return _location         ;}
			set {_location          = value;}
		}

		public string publishtime
		{
			get {return _publishtime      ;}
			set {_publishtime       = value;}
		}

		public string jobtype
		{
			get {return _jobtype          ;}
			set {_jobtype           = value;}
		}

		public string occupation
		{
			get {return _occupation       ;}
			set {_occupation        = value;}
		}

		public string otherkey
		{
			get {return _otherkey         ;}
			set {_otherkey          = value;}
		}

		public string user_ip
		{
			get {return _user_ip          ;}
			set {_user_ip           = value;}
		}

		public string user_software
		{
			get {return _user_software    ;}
			set {_user_software     = value;}
		}

		public string user_cookie
		{
			get {return _user_cookie      ;}
			set {_user_cookie       = value;}
		}

		public string user_language
		{
			get {return _user_language    ;}
			set {_user_language     = value;}
		}

		public string url_other_param
		{
			get {return _url_other_param  ;}
			set {_url_other_param   = value;}
		}
		#endregion
		
		#region 
		public CampusSearchLog() {	}

        public CampusSearchLog(DataRow dr)
		{	
		     try
		     {	
		          if (dr!=null)
		          {
				_log_id              = Convert.ToInt64(dr["log_id"]);
				_user_id             =  Convert.ToString(dr["user_id"]);
				_searchtime          = Convert.ToDateTime(dr["searchtime"]);
				_keyword             =  Convert.ToString(dr["keyword"]);
				_major               =  Convert.ToString(dr["major"]);
				_location            =  Convert.ToString(dr["location"]);
				_publishtime         =  Convert.ToString(dr["publishtime"]);
				_jobtype             =  Convert.ToString(dr["jobtype"]);
				_occupation          =  Convert.ToString(dr["occupation"]);
				_otherkey            =  Convert.ToString(dr["otherkey"]);
				_user_ip             =  Convert.ToString(dr["user_ip"]);
				_user_software       =  Convert.ToString(dr["user_software"]);
				_user_cookie         =  Convert.ToString(dr["user_cookie"]);
				_user_language       =  Convert.ToString(dr["user_language"]);
				_url_other_param     =  Convert.ToString(dr["url_other_param"]);
		          }
			}
			catch(Exception e)
			{	
				throw e;				
			}
			
		}
		

		#endregion
    }
}
