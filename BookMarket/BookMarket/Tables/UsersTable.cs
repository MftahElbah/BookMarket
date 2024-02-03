using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;


namespace BookMarket.Tables
{
    public class UsersTable
    {
        [Unique] 
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string Emails{ get; set; }
        public string Pass{ get; set; }
        public int Age {  get; set; }
        public int GenderId {  get; set; }


        //To show if its user or manger
       
        public bool UserType { get; set; }

        //to create security
        public int QuesID {  get; set; }
        public string QuesAns { get; set; }

        //if the account activete the security question
        public bool secQues {  get; set; }

        //if this account deleted or not
        
        public bool Active { get; set; }

    }
}
