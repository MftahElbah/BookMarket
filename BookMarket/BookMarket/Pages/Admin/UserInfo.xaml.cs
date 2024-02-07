using BookMarket.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserInfo : ContentPage
	{
		public string UserName;
		public string FullName;
		public string Email;
		public bool tu;
		public int id;
		public int gd;
		public string pass;
		public bool secq;
		public int quesid;
		public string quesans;
		public int ag;
		public UserInfo (int ID,string Username,string Fullname , string email , int gid,int age,bool ut,string ps,int qid,string qa,bool sq)
		{
			InitializeComponent ();
			UserName = Username;
			FullName = Fullname;
			Email = email;
            id = ID;
			gd = gid;
			pass = ps;
			quesid = qid;
            quesans = qa;
			secq = sq;
			ag = age;

            UNlbl.Text ="Username: " + UserName;
			FNlbl.Text = "Fullname: "+ FullName;
			Elbl.Text= "Email: "+ Email;
			Agelbl.Text = "Age: "+ Convert.ToString(ag);
			tu = ut;

			if(gd == 1)
			{
				gen.Text = "Gender: Male";
			}
			else
			{
				gen.Text = "Gender: Female";

			}
			if (ut)
			{
				type.Text = "Permissions: Administrator";
                MakeAdmin.Text = "Make this account as an User";

            }
			else
			{
				type.Text = "Permissions: User";
                MakeAdmin.Text = "Make this account as an Admin";
            }
		}
		private async void MAClicked(object sender, EventArgs e)
		{
			var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
			var dbs = new SQLiteConnection(dbPath);
			if (tu)
			{
				tu = false;
			}
			else
			{
				tu = true;
			}
			var item = new UsersTable()
			{
				UserId= id,
                UserName = UserName,
                Active = true,
                Age = ag,
                Emails = Email,
                Fullname = FullName,
                GenderId = gd,
                Pass = pass,
                QuesAns = quesans,
                QuesID = quesid,
                secQues = secq,
                UserType =tu
			};
			dbs.Update(item);
			if (tu)
			{
			await DisplayAlert(null, "The account has become an Administrator","ok");
                App.Current.MainPage = new NavigationPage(new AdminFlayout());
            }
			else {
				await DisplayAlert(null, "The account has become a User", "ok");
                App.Current.MainPage = new NavigationPage(new AdminFlayout());
            }

        }
		private async void DAClicked(object sender, EventArgs e)
		{
            var result = await DisplayAlert("Confirmation", "Are you sure you want to delete the account?", "Yes","Cancal");
			if (result)
			{
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var dbs = new SQLiteConnection(dbPath);
                var del= new UsersTable()
                {
                    UserId = id,
                    UserName = UserName,
					Active = false,
					Age = 0,
					Emails=null,
					Fullname=null,
					GenderId=0,
					Pass=null,
					QuesAns=null,
					QuesID=0,
					secQues=false,
                    UserType = false
                };
                dbs.Update(del);
				App.Current.MainPage = new NavigationPage(new AdminFlayout());
            }

        }
	}
}