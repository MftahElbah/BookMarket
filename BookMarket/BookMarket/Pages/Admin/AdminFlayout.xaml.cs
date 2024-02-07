using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminFlayout : FlyoutPage
	{
		public AdminFlayout ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
			flyout.fl.ItemSelected += OnSelectedItem;
		}
		private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e) { 
		var item = e.SelectedItem as FlyoutItems;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
				flyout.fl.SelectedItem = null;
				IsPresented = false;
			}
		}

    }
}