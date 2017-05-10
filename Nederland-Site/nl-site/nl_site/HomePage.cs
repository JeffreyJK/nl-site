using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class HomePage : TabbedPage
	{
		public HomePage ()
		{
            var toolbarItem = new ToolbarItem
            {
                Text = "Logout"
            };

            toolbarItem.Clicked += OnLogoutButtonClicked;
            ToolbarItems.Add(toolbarItem);

            Title = "Nederland-Site";
            
            var navigationPage = new NavigationPage();

            Children.Add(new ChatListPage());
            Children.Add(new CalendarPage());
            Children.Add(new TimelinePage());
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ICredentialsService>().DeleteCredentials();
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
