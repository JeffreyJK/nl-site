using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace nl_site
{
	public class LogoutPage : ContentPage
	{
        private Image _background;
        private Label _titleText;
        private CustomButton _logoutBtn;
        public LogoutPage ()
		{
            _background = new Image
            {
                Source = "background.png",
                Aspect = Aspect.AspectFill
            };

            _titleText = new Label
            {
                Text = "Weet u zeker dat u wilt uitloggen?",
                FontFamily = Device.OnPlatform(
                    "Baloo-Regular",
                    "Baloo-Regular.ttf#Baloo-Regular",
                    null
                ),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.White
            };

            _logoutBtn = new CustomButton
            {
                Text = "Log uit",
                VerticalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.FromHex("00aaff"),
                TextColor = Color.FromHex("fff"),
                BorderRadius = 25,
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                ),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button))
            };

            _logoutBtn.Clicked += _logoutBtn__Clicked;

            var layout = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutBounds(_background, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(_background, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_logoutBtn, new Rectangle(.5, .5, .83, .08));
            AbsoluteLayout.SetLayoutFlags(_logoutBtn, AbsoluteLayoutFlags.All);

#if __IOS__
            AbsoluteLayout.SetLayoutBounds(_titleText, new Rectangle(.5, .3, .75, .1));
            AbsoluteLayout.SetLayoutFlags(_titleText, AbsoluteLayoutFlags.All);
#endif
#if __ANDROID__
            AbsoluteLayout.SetLayoutBounds(_titleText, new Rectangle(.5, .3, .73, .1));
            AbsoluteLayout.SetLayoutFlags(_titleText, AbsoluteLayoutFlags.All);
#endif

            layout.Children.Add(_background);
            layout.Children.Add(_titleText);
            layout.Children.Add(_logoutBtn);

            Content = layout;
        }

        private async void _logoutBtn__Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ICredentialsService>().DeleteCredentials();
            //Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }
    }
}