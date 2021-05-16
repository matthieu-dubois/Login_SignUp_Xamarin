using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Mobile.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //SignUP button
         async void Button_OnClicked(object sender, EventArgs e)
         {
             await Navigation.PushAsync(new RegisterPage());
         }

         //Button login 
         async void Button_OnClicked1(object sender, EventArgs e)
         {
             var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
             var db = new SQLiteConnection(dbpath);

             var query = db.Table<RegisterUser>()
                 .Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text))
                 .FirstOrDefault();

             if (query != null)
             {
                 App.Current.MainPage = new NavigationPage(new HomePage());
             }
             else
             {
                 Device.BeginInvokeOnMainThread(async () =>

                 {
                     var result = await this.DisplayAlert("Error", "User Register is KO", "Yes", "Cancel");

                     if (result)
                     {
                         await Navigation.PushAsync(new LoginPage());
                     }
                     else
                     {
                         await Navigation.PushAsync(new LoginPage());
                     }

                 });
            }

         }
    }
}