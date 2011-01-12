using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CampuSys.BO.Campus
{
    public class StudentLog
    {

	
		private    long       _skr_id            = 0;
		private    string     _viewed_job        = String.Empty;
		private    string     _keyword_history   = String.Empty;

		
			
		public long skr_id
		{
			get {return _skr_id           ;}
			set {_skr_id            = value;}
		}

		public string viewed_job
		{
			get {return _viewed_job       ;}
			set {_viewed_job        = value;}
		}

		public string keyword_history
		{
			get {return _keyword_history  ;}
			set {_keyword_history   = value;}
		}

	
		public StudentLog() {	}

        public StudentLog(DataRow dr)
		{	
		     try
		     {	
		          if (dr!=null)
		          {
				_skr_id              = Convert.ToInt64(dr["skr_id"]);
				_viewed_job          =  Convert.ToString(dr["viewed_job"]);
				_keyword_history     =  Convert.ToString(dr["keyword_history"]);
		          }
			}
			catch(Exception e)
			{	
				throw e;				
			}
			
		}
    }
}
