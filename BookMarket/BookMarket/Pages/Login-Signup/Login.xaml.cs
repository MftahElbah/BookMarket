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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


        }

        private void LoginClick(object sender, EventArgs e)
        {

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var db = new SQLiteConnection(dbPath);

            
            if(!string.IsNullOrEmpty(UsernameEntry.Text))
            {
            var user = db.Table<UsersTable>().FirstOrDefault(u => u.UserName.Equals(UsernameEntry.Text));
                if (!string.IsNullOrEmpty(passwordEntry.Text))
                {

                    if (user != null)
                    {
                        if(user.Active)
                        {
                            if(user.Pass == passwordEntry.Text)
                            {
                                if (user.secQues)
                                {
                                    App.Current.Properties["LoginUsername"] = UsernameEntry.Text;
                                    App.Current.MainPage = new NavigationPage(new SecurityQuesPage());
                                }
                                else
                                {
                                    App.Current.MainPage = new NavigationPage(new StorePage());
                                }
                            }
                            else
                            {
                                Errlbl.Text = "Username or Password incorrect";
                                ErrFrm.Opacity = 100;
                                UsernameEntry.BorderColor = Color.Red;
                                passwordEntry.BorderColor = Color.Red;
                            }
                        }
                        else
                        {

                            Errlbl.Text = "This account has been deleted";
                            ErrFrm.Opacity = 100;

                        }
                    }
                    else
                    {
                        Errlbl.Text = "Username or Password incorrect";
                        ErrFrm.Opacity = 100;
                        UsernameEntry.BorderColor = Color.Red;
                        passwordEntry.BorderColor = Color.Red;

                    }
                }
                else
                {
                Errlbl.Text = "Password must be filled in";
                ErrFrm.Opacity= 100;
                    
                    passwordEntry.BorderColor = Color.Red;
                }
            }
            else
            {
                Errlbl.Text = "Username must be filled in";
                ErrFrm.Opacity= 100;
                UsernameEntry.BorderColor = Color.Red;
                
            }
            
        }

        private void SignupClick(object sender, EventArgs e) {

            App.Current.MainPage = new NavigationPage(new SignupPage1());

        }
    }
}