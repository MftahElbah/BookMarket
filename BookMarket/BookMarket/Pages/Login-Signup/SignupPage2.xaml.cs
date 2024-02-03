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
	public partial class SignupPage2 : ContentPage
	{
		public SignupPage2 ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

		private void NextClicked(object sender, EventArgs e)
		{
			bool Emailgood;
            bool Passgood;
            bool ConPassgood;
			string passcheck = PassEntry.Text;

            if (EmailEntry == null) {
			ErorrLbl.Text = "يجب ادخال البريدالألكتروني";
			ErorrLbl.Opacity = 1.0;
			Emailgood=false;
			}
            else
            {
                Emailgood = true;
            }

			if (passcheck == null) {
				Passgood = false;
                ErorrLbl.Text = "يجب ادخال كلمة السر";
                ErorrLbl.Opacity = 1.0;
            }
			else
			if(!string.IsNullOrEmpty(PassEntry.Text) && passcheck.Length < 8)
			{
                Passgood = false;
                ErorrLbl.Text = "يجب ادخال كلمة السر يتكون من 8 أحرف وارقام";
                ErorrLbl.Opacity = 1.0;
            }
			else
			{
                Passgood = true;
			}

			if (passcheck != ConPassEntry.Text)
			{

				ErorrLbl.Text = "كلمة السر غير متوافقة";
				ErorrLbl.Opacity = 1.0;
				ConPassgood = false;
			}
			else
			{
				ConPassgood=true;
			}

			if(Emailgood && Passgood && ConPassgood)
			{
				App.Current.Properties["Email"]=EmailEntry.Text;
				App.Current.Properties["Password"]=passcheck;
                App.Current.MainPage = new NavigationPage(new SignupPage3());

            }

        }

		private void CancelClicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new NavigationPage(new Login());

        }
    }
}
