using BookMarket.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditBooks : ContentPage
	{
        private SQLiteConnection dbs;
        private ObservableCollection<Books> books;
        private Books selectedBook;
        public EditBooks ()
		{
			InitializeComponent ();
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BookDB.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Books>();

            books = new ObservableCollection<Books>(dbs.Table<Books>());
            lvt.ItemsSource = books;
        }

        public void DeleteClicked (object sender, EventArgs e)
        {
            selectedBook = (Books)((Button)sender).BindingContext;

            // Delete the book from the database
            dbs.Delete<Books>(selectedBook.BookId);

            // Remove the book from the ObservableCollection
            books.Remove(selectedBook);

            // Clear the selected book
            selectedBook = null;
        }
    }
}