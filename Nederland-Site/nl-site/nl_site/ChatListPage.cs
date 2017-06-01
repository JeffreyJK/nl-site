using Newtonsoft.Json;
using nl_site.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class ChatListPage : ContentPage
	{
        ICredentialsService storeService;
        private Group _groupInfo;
        public ListView listView;

        public ChatListPage()
        {
            Title = "Chat";

            

            getGroup();
        }

        private async void getGroup()
        {
            storeService = DependencyService.Get<ICredentialsService>();
            string savedEmail = storeService.UserName;

            ApiClient client = new ApiClient();
            App.Clijst = await client.getGroup(savedEmail);

            List<GroupList> d = JsonConvert.DeserializeObject<List<GroupList>>(App.Clijst);

            var listView = new ListView {
                HasUnevenRows = true,
                RowHeight = 75,
                IsPullToRefreshEnabled = true,
            };

            listView.Refreshing += OnRefresh;

            listView.ItemTemplate = new DataTemplate(typeof(CustomCell));

            listView.ItemsSource = d;
            
            Title = "Chat";
            Content = listView;
        }

        private async void OnRefresh(object sender, EventArgs e)
        {
            storeService = DependencyService.Get<ICredentialsService>();
            string savedEmail = storeService.UserName;

            ApiClient client = new ApiClient();
            App.Clijst = await client.getGroup(savedEmail);

            List<GroupList> d = JsonConvert.DeserializeObject<List<GroupList>>(App.Clijst);

            //make sure to end the refresh state
            listView.IsRefreshing = false;
        }
    }
}
