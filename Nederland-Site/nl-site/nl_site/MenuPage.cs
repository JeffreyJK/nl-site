using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class MenuPage : ContentPage
	{
        bool disable = false;

        public ListView Menu { get; set; }

        public MenuPage ()
		{
            Icon = "settings.png";
            Title = "Menu"; // The Title property must be set.
            BackgroundColor = Color.FromHex("333333");
            WidthRequest = 100;
            Menu = new MenuListView();
            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            layout.Children.Add(Menu);
            Content = layout;
        }
	}
}