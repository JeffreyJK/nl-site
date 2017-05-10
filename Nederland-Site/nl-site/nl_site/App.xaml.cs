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

        public App ()
		{
			InitializeComponent();

            if (DependencyService.Get<ICredentialsService>().DoCredentialsExist())
            {
                MainPage = new NavigationPage(new HomePage())
                {
                    BarBackgroundColor = Color.FromHex("#ff5300"),
                    BarTextColor = Color.White
                };
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
