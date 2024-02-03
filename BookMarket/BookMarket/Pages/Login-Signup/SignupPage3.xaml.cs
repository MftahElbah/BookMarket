using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookMarket.Tables;
using System.IO;

namespace BookMarket.Pages.Login_Signup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignupPage3 : ContentPage
	{
		public SignupPage3 ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
		
		private void RegCLicked(object sender, EventArgs e)
		{
            int gender=0;
            int age = 0;
            int selcetedItem = 0;
			string ans;

            if (!string.IsNullOrEmpty(AgeEntry.Text))
			{
				age = int.Parse(AgeEntry.Text);
				if(age < 18)
				{
                    ErorrLbl.Text = "لا زلت صغير للدخول الى التطبيق";
                    ErorrLbl.Opacity = 1;

                }
				else
				if(age > 100)
				{
                    ErorrLbl.Text = "يجب ادخال العمر بشكل صحيح";
					ErorrLbl.Opacity = 1;

                }
				else
				{
                    if (MaleRad.IsChecked || FeMaleRad.IsChecked)
                    {


                        if (MaleRad.IsChecked)
                        {
                            gender = 1;
                        }

                        else
                        {
                            gender = 2;
                        }

                        if (QuesPicker.SelectedItem != null)
                        {
                            selcetedItem = QuesPicker.SelectedIndex;


                            if (!string.IsNullOrEmpty(AsrEntry.Text))
                            {

                                if (!TAcept.IsChecked)
                                {
                                    ErorrLbl.Text = "يجب الموافقة على الشروط للتسجيل على البرنامج";
                                    ErorrLbl.Opacity = 1;
                                    TAcept.Color = Color.Red;

                                    
                                }
                                else
                                {
                                    var un = App.Current.Properties["UserName"];
                                    var fn = App.Current.Properties["FullName"];
                                    var em = App.Current.Properties["Email"];
                                    var ps = App.Current.Properties["Password"];
                                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UsersDB.db");
                                    var db = new SQLiteConnection(dbPath);
                                    db.CreateTable<UsersTable>();
                                    var item = new UsersTable()
                                    {
                                        UserName = un.ToString(),
                                        Fullname = fn.ToString(),
                                        Emails = em.ToString(),
                                        Pass = ps.ToString(),
                                        Age = age,
                                        GenderId = gender,
                                        QuesID = selcetedItem,
                                        QuesAns = AsrEntry.Text.ToString(),
                                        UserType = false,
                                        Active = true,
                                        secQues = false

                                    };
                                    db.Insert(item);
                                    App.Current.MainPage = new NavigationPage(new Login());
                                }
                                
                            }
                            else
                            {
                                ErorrLbl.Text = "يجب كتابة الاجابة";
                                ErorrLbl.Opacity = 1;

                            }


                            

                        }
                        else
                        {
                            ErorrLbl.Text = "أختيار سؤال الامان امر ضروري";
                            ErorrLbl.Opacity = 1;
                        }

                    }
                    else
                    {
                        ErorrLbl.Text = "يجب اختيار الجنس";
                        ErorrLbl.Opacity = 1;
                    }
                }
				
			}
			else
			{
				ErorrLbl.Text = "يجب ادخال العمر";
			
				ErorrLbl.Opacity = 1;
			}
        }

		private void CancelCLicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new NavigationPage(new Login());
		}
		
    }
}