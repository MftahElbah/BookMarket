using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;
namespace BookMarket.DB
{
    class UsersDB
    {
        [Unique,MaxLength(25),Column("Username")] public string Username { get; set; }
        [MaxLength(45),Column("Fullname")] public string Fullname { get; set; }
        [MaxLength(45), Column("Pass")] public string Pass{ get; set; }
        [Column("GenderID")] public int GenderId {  get; set; }

        //To show if its user or manger
        [DefaultValue(false),Column("UserType")] public bool UserType { get; set; }

        //to create security
        [Column("QuesID")]public int QuesID {  get; set; }
        [MaxLength(20),Column("QuesAns")] public string QuesAns { get; set; }

        //if this account deleted or not
        [DefaultValue(true),Column("Active")] public bool Active { get; set; }

    }
}
