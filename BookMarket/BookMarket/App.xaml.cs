using System;
using Xamarin.Forms;
using Xamarin.Forms.Svg;
using Xamarin.Forms.Xaml;
using SQLite;
using BookMarket.Tables;
using System.IO;

namespace BookMarket
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SvgImageSource.RegisterAssembly();

            MainPage = new Pages.Login_Signup.Login ();
        }

        protected override void OnStart()
        {
            
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<UsersTable>();
            if(db.Table<UsersTable>().Count() == 0)
            {

            var item = new UsersTable()
            {
                UserId = 1,
                UserName = "admin",
                Fullname = "admin one",
                Emails = "admin@gmail.com",
                Pass = "adminadmin",
                Age = 20,
                GenderId = 1,
                QuesID = 1,
                QuesAns = "admin",
                UserType = true,
                Active = true,
                secQues = true

            };
            db.Insert(item);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
