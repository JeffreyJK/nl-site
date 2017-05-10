using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class CalendarPage : ContentPage
	{
		public CalendarPage ()
		{
            Title = "Kalender";

            Content = new StackLayout {
				Children = {
					new Label { Text = "Coming Soon...", HorizontalOptions=LayoutOptions.CenterAndExpand, VerticalOptions=LayoutOptions.CenterAndExpand }
				}
			};
		}
	}
}
