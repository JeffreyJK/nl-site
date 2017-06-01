using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class HomePage : MasterDetailPage
	{
		public HomePage ()
		{
            var menuPage = new MenuPage();
            menuPage.Menu.ItemSelected += (sender, e) => NavigateToPage(e.SelectedItem as MenuItem);
            Master = menuPage;
            Detail = new NavigationPage(new ChatListPage());

        }

        void NavigateToPage(MenuItem menu)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            IsPresented = false;
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ICredentialsService>().DeleteCredentials();
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
