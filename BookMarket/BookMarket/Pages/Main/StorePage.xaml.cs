using BookMarket.Controls;
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

	public partial class StorePage : ContentPage
	{
        private SQLiteConnection dbs;
        private ObservableCollection<Books> books;
        private Books selectedBook;


        public void refeshes()
        {

            if (books != null)
            {
                books.Clear();
            }
            var data = dbs.Table<Books>();
            books = new ObservableCollection<Books>(data);
            lvt.ItemsSource = books;


        }
        public StorePage ()
		{
            
            InitializeComponent ();
            Resources.Add("ByteToImageConverter", new ByteToImageSourceConverter());

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BookDB.db");
            dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<Books>();
            refeshes();
        }

        public async void buyCLicked(object sender, EventArgs e)
        {
            await DisplayAlert(null, "Thanks for buying!!", "Continue");
        }
	}
}