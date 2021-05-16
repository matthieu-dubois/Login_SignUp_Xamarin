using System;
using App1_Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
