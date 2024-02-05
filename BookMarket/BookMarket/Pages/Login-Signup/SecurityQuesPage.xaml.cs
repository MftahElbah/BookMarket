using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMarket.Tables;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecurityQuesPage : ContentPage
	{
		public SecurityQuesPage ()
		{
			InitializeComponent ();
			var un = App.Current.Properties["LoginUsername"];

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);
            var user = db.Table<UsersTable>().FirstOrDefault(u => u.UserName.Equals(un));

			if(user.QuesID == 0) {
			quesLbl.Text = "First Pet you have ?";
			}
			else
				if(user.QuesID == 1)
			{
				quesLbl.Text = "First School name ?";
            }
			else
			{
				quesLbl.Text = "First car name ?";
            }
		}

		private void answerEntryChange(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty(answerEntry.Text))
			{
                ansbtn.IsCheckable = true;

            }
		}

        public void AnswerClicked(object sender, EventArgs e)
		{
            var un = App.Current.Properties["LoginUsername"];

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);
            var user = db.Table<UsersTable>().FirstOrDefault(u => u.UserName.Equals(un));

            if (user.QuesAns == answerEntry.Text ) {

                    App.Current.MainPage = new NavigationPage(new StorePage());
               
			}
			else
			{
				ErrFrm.Opacity = 1;
				Errlbl.Text = "Wrong Answer";
			}

        }

    }
}