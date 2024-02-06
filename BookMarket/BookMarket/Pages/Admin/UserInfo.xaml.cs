using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookMarket.Pages.Admin.People
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserInfo : ContentPage
	{
		public string un {  get; set; }
		public string fn {  get; set; }
		public string em {  get; set; }
		public int gi {  get; set; }
		public int a {  get; set; }
		public bool tu {  get; set; }
		public UserInfo (string Username,string Fullname , string email , int gid,int age,bool ut)
		{
			InitializeComponent ();

			un = Username;
			fn = Fullname;
			em = email;
			gi = gid;
			a = age;
			tu = ut;

			if(gi == 1)
			{
				gen.Text = "Gender: Male";
			}
			else
			{
				gen.Text = "Gender: Female";

			}
			if (tu)
			{
				type.Text = "Permissions: Administrator";
			}
			else
			{
				type.Text = "Permissions: User";

			}
		}
	}
}