using System;
using WorldBank.App.Application;
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

            MainPage = new MainPage();
            AppService = new ApplicationService();
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
