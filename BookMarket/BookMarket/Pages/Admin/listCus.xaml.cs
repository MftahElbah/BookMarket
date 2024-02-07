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

namespace BookMarket.Pages.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class listCus : ContentPage
	{
        private SQLiteConnection dbs;
        private ObservableCollection<UsersTable> Users;
        private Books selectedUser;

        public void refeshes()
        {

            if (Users != null)
            {
                Users.Clear();
            }
            var data = dbs.Table<UsersTable>().Where(x => x.Active.Equals(true));
            Users = new ObservableCollection<UsersTable>(data);
            lvt.ItemsSource = Users;

        }
        public listCus ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<UsersTable>();
            refeshes();
            typePicker.SelectedIndex = 0;
        }

        private void SelectedChanged(object sender, EventArgs e)
        {
            if(typePicker.SelectedIndex == 0)
            {
                refeshes();
            }
            else
                if(typePicker.SelectedIndex == 1)
            {
                if (Users != null)
                {
                    Users.Clear();
                }
                var data = dbs.Table<UsersTable>().Where(x => x.UserType.Equals(true) && x.Active.Equals(true));
                Users = new ObservableCollection<UsersTable>(data);
                lvt.ItemsSource = Users;
            }
            else
            {
                if (Users != null)
                {
                    Users.Clear();
                }
                var data = dbs.Table<UsersTable>().Where(x => x.UserType.Equals(false) && x.Active.Equals(true));
                Users = new ObservableCollection<UsersTable>(data);
                lvt.ItemsSource = Users;
            }
        }

        async void UserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user=e.SelectedItem as UsersTable;
            await Navigation.PushAsync(new UserInfo(user.UserId,user.UserName , user.Fullname , user.Emails , user.GenderId , user.Age, user.UserType,user.Pass,user.QuesID,user.QuesAns,user.secQues));
        }
	}
}