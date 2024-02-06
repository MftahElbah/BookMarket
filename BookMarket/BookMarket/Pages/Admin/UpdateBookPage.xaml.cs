using System;
using System.Collections.Generic;
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
        public byte[] imgcon { get; set; }
        public UpdateBookPage(int id,string bname,string aname,float p , byte[] pic)
        {
            InitializeComponent();

            Resources.Add("ByteToImageConverter", new ByteToImageSourceConverter());
            int ids = id;
            BookNameEntry.Text = bname;
            AuthNameEntry.Text = aname;
            PriceEntry.Text=p.ToString();
            imgcon = pic;
            BindingContext = this;

        }
    }
}