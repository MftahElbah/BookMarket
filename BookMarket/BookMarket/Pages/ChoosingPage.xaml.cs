﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChoosingPage : ContentPage
	{
		public ChoosingPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            
		}
	}
}