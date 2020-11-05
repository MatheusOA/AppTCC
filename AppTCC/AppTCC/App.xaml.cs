using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTCC.Services;
using AppTCC.Views;

namespace AppTCC
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ1NTY5QDMxMzgyZTMyMmUzMGRzOFo5c3lSdWJROHRIenhNYzRvZ2N5OUR3dkRFREpzUEp2T0FtcXFGb289");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new LoginPage();
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
