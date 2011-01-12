using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.BO.Campus
{
    public class SearchCondition
    {
        public static string KeyWordDefault = "公司/职位名称";
        private string _keyWord=string.Empty;
        private string _majorCategory = string.Empty;
        private string _jobType = string.Empty;
        private string _jobLocation = string.Empty;
        private string _jobDateTime = string.Empty;
        private string _occupationCategory = string.Empty;
        private string _industryCategory = string.Empty;
        private string _companyType = string.Empty;
        private string _companySize = string.Empty;
        private string _userID = string.Empty;
        private bool _secondSearch = false;
        private string _sort = string.Empty;

	    public string Sort
	    {
		    get { return _sort; }
		    set { _sort = value; }
	    }
	    public bool SecondSearch
	    {
		    get { return _secondSearch; }
		    set { _secondSearch = value; }
	    }
	    public string UserID
	    {
		    get { return _userID; }
		    set { _userID = value; }
	    }

        public string KeyWord
	    {
		    get {
                   _keyWord = _keyWord.Trim() == SearchCondition.KeyWordDefault ? "" : _keyWord;
                   return _keyWord;   
                }
		    set { _keyWord = value; }
	    }

	    public string MajorCategory
	    {
		    get { return _majorCategory; }
		    set { _majorCategory = value; }
	    }
           
	    public string JobType
	    {
		    get { return _jobType; }
		    set { _jobType = value; }
	    }
           
	    public string JobLocation
	    {
		    get { return _jobLocation; }
		    set { _jobLocation = value; }
	    }

	    public string JobDateTime
	    {
		    get { return _jobDateTime; }
		    set { _jobDateTime = value; }
	    }

	    public string OccupationCategory
	    {
		    get { return _occupationCategory; }
		    set { _occupationCategory = value; }
	    }

	    public string IndustryCategory
	    {
		    get { return _industryCategory; }
		    set { _industryCategory = value; }
	    }

	    public string CompanySize
	    {
		    get { return _companySize; }
		    set { _companySize = value; }
	    }

	    public string CompanyType
	    {
		    get { return _companyType; }
		    set { _companyType = value; }
	    }

        }
    }
