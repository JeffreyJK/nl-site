using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class ChatListPage : ContentPage
	{
		public ChatListPage ()
		{
            Title = "Chat";

            Content = new StackLayout {
				Children = {
					new Label { Text = "Chat lijst" }
				}
			};
		}
	}
}
