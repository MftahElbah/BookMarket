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
using BookMarket.Tables;

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
            var dbp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db");
            var db = new SQLiteConnection(dbp);
            var UsernameExist = db.Table<UsersTable>().Where(u => u.Username == usernameEntry.Text).FirstOrDefault();

            if (UsernameExist != null)
            {
                if(UsernameExist.Active == true)
                {
                    if(UsernameExist.Pass == passwordEntry.Text)
                    {
                        App.Current.MainPage = new NavigationPage(new StorePage());
                    }
                    else
                    {
                        ErorrLbl.Text = "هناك خطا في اسم المستخدم أو كلمة السر";
                        ErorrLbl.IsVisible = true;
                    }
                }
                else
                {
                    ErorrLbl.Text = "الحساب تم حذفه";
                    ErorrLbl.IsVisible = true;
                }
            }
            else
            {
                ErorrLbl.Text = "هناك خطا في اسم المستخدم أو كلمة السر";
                ErorrLbl.IsVisible = true;

            }
        }

        private void SignupClick(object sender, EventArgs e) {

            App.Current.MainPage = new NavigationPage(new SignupPage1());

        }
    }
}