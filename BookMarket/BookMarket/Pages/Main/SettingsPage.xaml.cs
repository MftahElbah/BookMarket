using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is SettingsMenu listItem)
            {

                Navigation.PushAsync((Page)Activator.CreateInstance(listItem.TargetPage));
            }
            ((ListView)sender).SelectedItem = null;
        }

        private void testcLICKE(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EPIPage());
        }

    }
}