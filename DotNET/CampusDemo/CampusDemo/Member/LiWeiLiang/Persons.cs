using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CampusDemo.Member.LiWeiLiang
{
     public  class Persons
    {


         public Persons()
         {

         }
         public  Persons(string groupname)
         {

         }

         private string _groupName = "";
         private int _count;
         public int Count
         {
             get { return _count; }
             set { _count = value; }
         }
         public virtual string GroupName
         {
             get { return _groupName; }
             set { _groupName = value; }
         }



        private List<string> pList = new List<string>();

   
        public void AddPersons(string name)
        {
            pList.Add(name);
        }
        public string this[int index]
        {
            get { return pList[index]; }
            set { pList[index] = value; }
        }

        internal  class Spoke
        {
            public static void Speak(string Message)
            {

            }
        }
    }

    public class PersonsA : Persons
    {
        string AName = "";
        int ACount = 0;
        public new int Count
        {
            get { return 0; }
            set { ACount = value; }
        }
        public override string GroupName
        {

            get { return AName; }
            set { AName = value; }
        }
    }
}
