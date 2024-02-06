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

namespace BookMarket.Pages.Admin.People
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
            var data = dbs.Table<UsersTable>();
            Users = new ObservableCollection<UsersTable>(data);
            lvt.ItemsSource = Users;

        }
        public listCus ()
		{
			InitializeComponent ();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
            dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<UsersTable>();
            refeshes();
        }

        async void UserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user=e.SelectedItem as UsersTable;
            await Navigation.PushAsync(new UserInfo(user.UserName , user.Fullname , user.Emails , user.GenderId , user.Age, user.UserType));
        }
	}
}