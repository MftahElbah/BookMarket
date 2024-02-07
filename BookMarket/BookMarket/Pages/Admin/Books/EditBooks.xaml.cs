using BookMarket.Controls;
using BookMarket.Tables;
using SQLite;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        public EditBooks()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            Resources.Add("ByteToImageConverter", new ByteToImageSourceConverter());

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BookDB.db");
            dbs = new SQLiteConnection(dbPath);
            dbs.CreateTable<Books>();
            refeshes();
        }

        public async void EditClicked(object sender, EventArgs e)
        {
            SfButton button = (SfButton)sender;
            Books book = (Books)button.BindingContext;

            await Navigation.PushAsync(new UpdateBookPage(book.BookId, book.BookName, book.AuthorName, book.Price, book.BookPic));
        }
        public async void DeleteClicked(object sender, EventArgs e)
        {
            
            bool result = await DisplayAlert("Confirmation", "Are you sure want to delete this book ?", "Yes", "Cancel");
            if (result)
            {

            SfButton button = (SfButton)sender;
            Books book = (Books)button.BindingContext;

            dbs.Delete(book);

            refeshes();

            selectedBook = null;
            lvt.ItemsSource = null;
            lvt.ItemsSource = books;
            }
            
        }

    }
}