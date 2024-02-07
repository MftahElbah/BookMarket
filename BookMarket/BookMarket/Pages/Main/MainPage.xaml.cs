using BookMarket.Pages.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Svg;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
 

        
        public MainPage()
        {
            InitializeComponent();
            
            var storepage = new StorePage
            {
                Title ="Store",
                IconImageSource= SvgImageSource.FromResource("shop-solid")
                
            };
            var settings = new SettingsPage
            {
                Title = "Settings",
                IconImageSource = SvgImageSource.FromResource("gear-solid")

            };
            Children.Add(storepage);
            Children.Add(settings);
        }
    }
}