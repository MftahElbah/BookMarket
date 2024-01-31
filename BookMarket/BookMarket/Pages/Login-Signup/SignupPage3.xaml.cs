using System;
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
	public partial class SignupPage3 : ContentPage
	{
		public SignupPage3 ()
		{
			InitializeComponent ();
		}
		
		private void RegClicked(object sender, EventArgs e)
		{
			int age = 0;
			if (!string.IsNullOrEmpty(AgeEntry.Text))
			{
				age = int.Parse(AgeEntry.Text);
				if(age < 18)
				{
                    ErorrLbl.Text = "لا زلت صغير للدخول الى التطبيق";
                    ErorrLbl.Opacity = 1;

                }
				else
				if(age > 100)
				{
                    ErorrLbl.Text = "يجب ادخال العمر بشكل صحيح";
					ErorrLbl.Opacity = 1;

                }
				
			}
			else
			{
				ErorrLbl.Text = "يجب ادخال العمر";
				ErorrLbl.Opacity = 1;
			}

			if (MaleRad.IsChecked || FeMaleRad.IsChecked)
			{
				int gen;

				if (MaleRad.IsChecked)
				{
					gen = 1;
				}

				else {
					gen = 2; 
				}

			}
			else
			{
                ErorrLbl.Text = "يجب اختيار الجنس";
                ErorrLbl.Opacity = 1;
            }

            if (QuesPicker.SelectedItem != null)
            {
                int selcetedItem = QuesPicker.SelectedIndex;
            }
			else
			{
                ErorrLbl.Text = "أختيار سؤال الامان امر ضروري";
                ErorrLbl.Opacity = 1;
            }

            if (!string.IsNullOrEmpty(AsrEntry.Text))
			{
				var ans = AsrEntry.Text;
			}
			else
			{
                ErorrLbl.Text = "يجب كتابة الاجابة";
                ErorrLbl.Opacity = 1;
            }

			if (!TAcept.IsChecked)
			{
                ErorrLbl.Text = "يجب الموافقة على الشروط للتسجيل على البرنامج";
				ErorrLbl.Opacity = 1;
				TAcept.Color=Color.Red;

            }

			var un = App.Current.Properties["UserName"];
			var fn = App.Current.Properties["FullName"];
			var em = App.Current.Properties["Email"];
			var ps = App.Current.Properties["Password"];
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<UsersTable>();
			var item = new UsersTable()
			{
				UserName = un.ToString(),
				Fullname = fn.ToString(),
				Emails = em.ToString(),
				Pass = ps.ToString(),
				Age = age,
				GenderId = gen,

            };

        }

		private void CancelClicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new NavigationPage(new Login());
		}
		
    }
}