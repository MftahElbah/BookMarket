using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using BookMarket.Tables;
using Xamarin.Essentials;
using System.Threading;
using System.Diagnostics;

namespace BookMarket.Pages.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBooks : ContentPage
    {
            private byte[] _bookImageBytes;
        public AddBooks()
        {
            InitializeComponent();
        }

        private async void UploadClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Pick an image"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        _bookImageBytes = memoryStream.ToArray();
                        bookPictureImage.Source = ImageSource.FromStream(() => new MemoryStream(_bookImageBytes));
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., user canceled the file picker)
            }
        }
        public void AddBookClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BookNameEntry.Text) && !string.IsNullOrEmpty(AuthNameEntry.Text) && !string.IsNullOrEmpty(PriceEntry.Text) && _bookImageBytes != null)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BookDB.db");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Books>();
                var item = new Books()
                {
                    BookName = BookNameEntry.Text,
                    AuthorName = AuthNameEntry.Text,
                    Price = float.Parse(PriceEntry.Text),
                    BookPic = _bookImageBytes
                };
                db.Insert(item);
                db.Close();
                Errlbl.Text = "Good";
                ErrFrm.Opacity = 1;
                BookNameEntry.Text="";
                AuthNameEntry.Text = "";
                PriceEntry.Text = "";
                _bookImageBytes = null;

            }
            else
            {
                Errlbl.Text = "All fields must be filled out";
                ErrFrm.Opacity = 1;
                BookNameEntry.BorderColor = Color.Red;
                AuthNameEntry.BorderColor = Color.Red;
                PriceEntry.BorderColor = Color.Red;
                bookPictureImage.BackgroundColor = Color.Red;
            }
        }


    }
}