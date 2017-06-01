using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace nl_site
{
    class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

            ItemTemplate = cell;
            //SelectedItem = data[0];
        }

        public class MenuListData : List<MenuItem>
        {
            public MenuListData()
            {
                this.Add(new MenuItem()
                {
                    Title = "Profiel",
                    TargetType = typeof(ProfilePage)
                });

                this.Add(new MenuItem()
                {
                    Title = "Chat",
                    TargetType = typeof(ChatListPage)
                });

                this.Add(new MenuItem()
                {
                    Title = "Log uit",
                    TargetType = typeof(LogoutPage)
                });
            }
        }

    }
}
