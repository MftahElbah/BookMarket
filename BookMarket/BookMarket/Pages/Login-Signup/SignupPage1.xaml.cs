using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Login_Signup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignupPage1 : ContentPage
	{
		public SignupPage1 ()
		{
			InitializeComponent ();
		}

        private void NextClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new StorePage());
        }

        private void CancelClicked(object sender, EventArgs e)
		{
			App.Current.MainPage= new NavigationPage (new Login());
		}
	}
}