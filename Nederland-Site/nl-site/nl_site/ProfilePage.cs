using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "profiel" }
				}
			};
		}
	}
}