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
            NavigationPage navigationPage1 = new NavigationPage(new StorePage());
            navigationPage1.IconImageSource = "shopsolid.png";
            navigationPage1.Title = "Store";
            NavigationPage navigationPage2 = new NavigationPage(new SettingsPage());
            navigationPage2.IconImageSource = "gearsolid.png";
            navigationPage2.Title = "Store";

            Children.Add(navigationPage1);
            Children.Add(navigationPage2);

        }
    }
}