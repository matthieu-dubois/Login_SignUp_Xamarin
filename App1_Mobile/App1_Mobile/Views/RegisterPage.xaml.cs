using System;
using System.Windows;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void Button_OnClicked(object sender, EventArgs e)
        {
            //Creation de la base de données SQLite dans Mes documents , connection , création de la table
            

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegisterUser>();


            RegisterUser registerUser = new RegisterUser()

            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            };

             db.Insert(registerUser);

            Device.BeginInvokeOnMainThread(async () =>

            {
                var result = await this.DisplayAlert("Congratulation", "User Register is Successfull", "Yes", "Cancel");

                if (result)
                {
                    await Navigation.PushAsync(new LoginPage());
                }

            } );

           




        }
    }
}