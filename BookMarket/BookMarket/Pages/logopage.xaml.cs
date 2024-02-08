using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class logopage : ContentPage
    {
        public logopage()
        {
            InitializeComponent();
            InitializeNavigation();
        }
        private async void InitializeNavigation()
        {
            // Introduce a 5-second delay
            await Task.Delay(3000);

            // Navigate to another page (replace MainPage with the desired page)
            Application.Current.MainPage = new NavigationPage(new Login_Signup.Login());
        }
    }
}