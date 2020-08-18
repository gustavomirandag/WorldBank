using System;
using WorldBank.App.Application;
using WorldBank.App.UI.CrossPlatformApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldBank.App.UI.CrossPlatformApp
{
    public partial class App : Xamarin.Forms.Application
    {
        public static ApplicationService AppService { get; set; }

        public App()
        {
            InitializeComponent();

            AppService = new ApplicationService();
            MainPage = new NavigationPage(new SignInPage());
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
