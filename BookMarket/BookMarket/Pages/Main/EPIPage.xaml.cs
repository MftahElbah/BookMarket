using BookMarket.Pages.Admin;
using BookMarket.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EPIPage : ContentPage
    {
        public int id;
        public EPIPage()
        {
            InitializeComponent();
            var uid = App.Current.Properties["USID"];
            
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<UsersTable>();
            var user = dbs.Table<UsersTable>().FirstOrDefault(u => u.UserId.Equals(uid));
            id = user.UserId;
            unEntry.Text = user.UserName;
            fnEntry.Text = user.Fullname;
            emEntry.Text = user.Emails;
            ageEntry.Text = Convert.ToString( user.Age);
            if(user.GenderId == 1)
            {
                genLbl.Text = "Male";
            }
            else
            {
                genLbl.Text = "Female";
            }

            if(user.secQues) {
            secSwitch.IsToggled = true;
            }
            else {
                secSwitch.IsToggled = false;
            }

            saveBtn.IsVisible = false;
            ErrFrm.IsVisible = false;

        }

        public void editInfoClicked(object sender, EventArgs e)
        {
            fnEntry.IsEnabled = true;
            emEntry.IsEnabled = true;
            ageEntry.IsEnabled = true;
            secSwitch.IsEnabled = true;
            saveBtn.IsVisible=true;
            cancalpiBtn.IsVisible=true;
            editBTN.IsVisible = false;
        }

        public void cancalpiClicked(object sender, EventArgs e)
        {
            var uid = App.Current.Properties["USID"];
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<UsersTable>();
            var user = dbs.Table<UsersTable>().FirstOrDefault(u => u.UserId.Equals(uid));
            unEntry.Text = user.UserName;
            fnEntry.Text = user.Fullname;
            emEntry.Text = user.Emails;
            ageEntry.Text = Convert.ToString(user.Age);
            if (user.secQues)
            {
                secSwitch.IsToggled = true;
            }
            else
            {
                secSwitch.IsToggled = false;
            }
        }
            
        public async void saveBtnClicked(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            var dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<UsersTable>();
            var user = dbs.Table<UsersTable>().FirstOrDefault(u => u.UserId.Equals(id));
            if (!string.IsNullOrEmpty(fnEntry.Text) && !string.IsNullOrEmpty(emEntry.Text) && !string.IsNullOrEmpty(ageEntry.Text))
            {
                if(int.Parse(ageEntry.Text) >= 18)
                {
                    var item = new UsersTable()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        Active = user.Active,
                        Age = int.Parse(ageEntry.Text),
                        Emails = emEntry.Text,
                        Fullname = fnEntry.Text,
                        GenderId = user.GenderId,
                        Pass = user.Pass,
                        QuesAns = user.QuesAns,
                        QuesID = user.QuesID,
                        secQues = secSwitch.IsToggled,
                        UserType = user.UserType
                    };
                    dbs.Update(item);
                    await Navigation.PopAsync();
                }
                else
                {
                    ErrFrm.IsVisible = true;
                    Errlbl.Text = "must be 18 or older";
                }
            }
            else
            {
                ErrFrm.IsVisible = true;
                Errlbl.Text = "All fields must be filled out";
            }
        }
        public async void DelAcc(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Confirmation", "Are you sure you want to delete the account?", "Yes", "Cancal");
            if (result)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
                var dbs = new SQLiteConnection(dbPath);
                var del = new UsersTable()
                {
                    UserId = id,
                    UserName = unEntry.Text,
                    Active = false,
                    Age = 0,
                    Emails = null,
                    Fullname = null,
                    GenderId = 0,
                    Pass = null,
                    QuesAns = null,
                    QuesID = 0,
                    secQues = false,
                    UserType = false
                };
                dbs.Update(del);
                App.Current.MainPage = new NavigationPage(new Login_Signup.Login());
            }
        }
    }
}