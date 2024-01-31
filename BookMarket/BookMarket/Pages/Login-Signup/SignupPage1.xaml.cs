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

namespace BookMarket.Pages.Login_Signup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignupPage1 : ContentPage
	{
		public SignupPage1 ()
		{
			InitializeComponent ();
		}

        private bool IsAllLetters(string text) 
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private string RemoveNonLetters(string text)
        {
            // Remove non-letter characters from the input
            return new string(text.Where(char.IsLetter).ToArray());
        }
        private void FNChange(object sender, TextChangedEventArgs e)
		{
            var entry = (Entry)sender;
            string newText = e.NewTextValue;

            if (!IsAllLetters(newText))
            {
                // If the entered text contains non-letter characters, remove them
                entry.Text = RemoveNonLetters(newText);
            }
        }private void LNChange(object sender, TextChangedEventArgs e)
		{
            var entry = (Entry)sender;
            string newText = e.NewTextValue;

            if (!IsAllLetters(newText))
            {
                // If the entered text contains non-letter characters, remove them
                entry.Text = RemoveNonLetters(newText);
            }
        }
        private void NextClicked(object sender, EventArgs e)
        {

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<UsersTable>();

            if (!string.IsNullOrEmpty(UsernameEntry.Text) && !string.IsNullOrEmpty(Firstname.Text) && !string.IsNullOrEmpty(Lastname.Text))
			{
                var user = db.Table<UsersTable>().FirstOrDefault(u => u.UserName.Equals(UsernameEntry.Text));
                if (user == null)
				{
					App.Current.Properties["UserName"] = UsernameEntry.Text;
                    App.Current.Properties["FullName"]=Firstname.Text + " " + Lastname.Text;
                    App.Current.MainPage = new NavigationPage (new SignupPage2());
                   
				}
				else
				{
                    ErorrLbl.Text = "هذا المستخدم موجود بالفعل";
                    ErorrLbl.Opacity = 1.0;
                }
			}
			else
			{
				ErorrLbl.Text = "يجب ملئ جميع الحقول";
				ErorrLbl.Opacity = 1.0;
			}
            
        }

        private void CancelClicked(object sender, EventArgs e)
		{
			App.Current.MainPage= new NavigationPage (new Login());
		}
	}
}