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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzE5ODY0QDMxMzgyZTMyMmUzMFNlVk9iNldyNDM2dEI5MUFqVHBOU1JXUUt6cUNVSTgyVC9CUmxFa2cyZU09");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
