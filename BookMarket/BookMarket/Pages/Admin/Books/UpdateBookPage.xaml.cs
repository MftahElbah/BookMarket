using BookMarket.Controls;
using BookMarket.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateBookPage : ContentPage
    {
        public byte[] IMGPIC { get; set; }
        public int ids { get; set; }
        public string bn { get; set; }
        public string an { get; set; }
        public float pri { get; set; }
        
        public UpdateBookPage(int id,string bname,string aname,float p , byte[] pic)
        {

            InitializeComponent();

            ids = id;
            bn= bname;
            an = aname;
            pri = p;
            BookNameEntry.Text = bn;
            AuthNameEntry.Text = an;
            PriceEntry.Text=pri.ToString();
            IMGPIC= pic;
            BindingContext = this;

        }

        private void UpdateClicked (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BookNameEntry.Text)) {
                bn = BookNameEntry.Text;
            }
            if(!string.IsNullOrEmpty(AuthNameEntry.Text))
            {
                an = AuthNameEntry.Text;
            }

            if (!string.IsNullOrEmpty(PriceEntry.Text))
            {
                pri = float.Parse(PriceEntry.Text);
            }
            else { pri = pri; }

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BookDB.db");
            var db = new SQLiteConnection(dbPath);

            var item = new Books()
            {
                BookId = ids,
                BookName = bn,
                AuthorName = an,
                Price = pri,
                BookPic = IMGPIC
            };
            db.Update(item);
            App.Current.MainPage = new NavigationPage(new Admin.EditBooks());
        }
        public void CancelClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage (new EditBooks());
        }
    }
}