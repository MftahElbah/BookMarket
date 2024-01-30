﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookMarket.Tables;
using System.IO;

namespace BookMarket.Pages.Login_Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void LoginClick(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<UsersTable>();
            
            if(!string.IsNullOrEmpty(UsernameEntry.Text))
            {
            var user = db.Table<UsersTable>().FirstOrDefault(u => u.Username.Equals(UsernameEntry.Text));

                if (user != null)
                {
                    if(user.Active == true)
                    {
                        if(user.Pass == passwordEntry.Text)
                        {
                            App.Current.MainPage = new NavigationPage(new StorePage());
                        }
                        else
                        {
                            ErorrLbl.Text = "هناك خطا في اسم المستخدم أو كلمة السر";
                            ErorrLbl.Opacity = 100;
                        }
                    }
                    else
                    {
                        
                        ErorrLbl.Text = "الحساب تم حذفه";
                        ErorrLbl.Opacity = 100;

                    }
                }
                else
                {
                    ErorrLbl.Text = "هناك خطا في اسم المستخدم أو كلمة السر";
                    ErorrLbl.Opacity = 100;

                }
            }
            else
            {
                ErorrLbl.Text = "يجب إدخال اسم المستخدم";
                ErorrLbl.Opacity= 100;
            }
        }

        private void SignupClick(object sender, EventArgs e) {

            App.Current.MainPage = new NavigationPage(new SignupPage1());

        }
    }
}