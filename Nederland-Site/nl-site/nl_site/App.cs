using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
    public partial class App : Application
    {
        public static string AppName { get { return "Nederland-Site"; } }

        internal static string Clijst;

        public App()
        {
            //InitializeComponent();

            MainPage = new FirstTimeLoginPage();
            /*
            if (DependencyService.Get<ICredentialsService>().DoCredentialsExist())
            {
                MainPage = new HomePage();
            }
            else
            {
                MainPage = new RegisterPage();
            }*/
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
