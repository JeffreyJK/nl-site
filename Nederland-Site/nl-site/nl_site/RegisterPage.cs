using Newtonsoft.Json;
using nl_site.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace nl_site
{
	public class RegisterPage : ContentPage
	{
        private Entry _emailInput;
        private Label _emailText;
        private Entry _firstInput;
        private Entry _lastInput;
        private Button _registerButton;
        private Label _login;
   
        private CustomBoxView _whiteBack1;
        private CustomBoxView _whiteBack2;
        private CustomBoxView _line;
        private Image _logo;
        private Image _background;
        private Label _titleText;
        private CustomBoxView _emailTextBack1;
        private CustomBoxView _emailTextBack2;
        private Label _back;

        bool disable = false;

        public RegisterPage ()
		{
            //BackgroundColor = Color.FromHex("#eb3e12");

            NavigationPage.SetHasNavigationBar(this, false);

            var buttonStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter {Property = Button.BackgroundColorProperty, Value = Color.FromHex("ffffff")},
                    new Setter {Property = Button.TextColorProperty, Value = Color.FromHex("b7b1b1")},
                    new Setter {Property = Button.BorderRadiusProperty, Value = 10},
                    new Setter {Property = Button.FontSizeProperty, Value = 20}
                }
            };

            _logo = new Image
            {
                Source = "Icon.png",
                WidthRequest = 175,
                HeightRequest = 175,
                MinimumHeightRequest = 175,
                MinimumWidthRequest = 175,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                Aspect = Aspect.AspectFit
            };

            _background = new Image
            {
                Source = "background.png",
                Aspect = Aspect.AspectFill
            };

            _emailInput = new Entry
            {
                Placeholder = "Email",
                TextColor = Color.FromHex("#9e9e9e"),
                FontSize = 15,
                Margin = new Thickness(0, 0, 0, -5)
            };

            _emailText = new Label
            {
                Text = "@nederland-site.nl",
                TextColor = Color.White,
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                ),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };

            _titleText = new Label
            {
                Text = "Nieuw account",
                FontFamily = Device.OnPlatform(
                    "Baloo-Regular",
                    "Baloo-Regular.ttf#Baloo-Regular",
                    null
                ),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.White
            };

            // voornaam veld aanmaken
            _firstInput = new Entry
            {
                Placeholder = "Voornaam",
                TextColor = Color.FromHex("#9e9e9e"),
                FontSize = 15,
                Margin = new Thickness(0, 0, 0, -5),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                )
            };
            
            // email veld aanmaken
            _lastInput = new Entry
            {
                Placeholder = "Achternaam",
                TextColor = Color.FromHex("#9e9e9e"),
                FontSize = 15,
                Margin = new Thickness(0, 0, 0, -5),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                )
            };

            // register knop aanmaken
            _registerButton = new CustomButton
            {
                Text = "Maak nieuw acount aan",
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

            _login = new Label
            {
                Text = "Al een acount? Log dan in",
                TextColor = Color.Black,
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                )
            };

            _whiteBack1 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _line = new CustomBoxView
            {
                BackgroundColor = Color.FromHex("#9e9e9e")
            };

            _whiteBack2 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _emailTextBack1 = new CustomBoxView
            {
                BackgroundColor = Color.FromHex("#eb3e12"),
                CornerRadius = 0
            };


            _emailTextBack2 = new CustomBoxView
            {
                BackgroundColor = Color.FromHex("#eb3e12"),
                CornerRadius = 25,
            };

            _back = new Label
            {
                Text = "Login",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                ),
            };

            _registerButton.Clicked += _registerButton_Clicked;

            var layout = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutBounds(_logo, new Rectangle(.5, .03, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_logo, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_background, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(_background, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_whiteBack1, new Rectangle(.5, .45, .83, .075));
            AbsoluteLayout.SetLayoutFlags(_whiteBack1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_firstInput, new Rectangle(.2, .45, .35, .06));
            AbsoluteLayout.SetLayoutFlags(_firstInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_lastInput, new Rectangle(.8, .45, .35, .06));
            AbsoluteLayout.SetLayoutFlags(_lastInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_line, new Rectangle(.5, .45, .005, .065));
            AbsoluteLayout.SetLayoutFlags(_line, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_whiteBack2, new Rectangle(.5, .565, .83, .075));
            AbsoluteLayout.SetLayoutFlags(_whiteBack2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailInput, new Rectangle(.212, .563, .38, .06));
            AbsoluteLayout.SetLayoutFlags(_emailInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack1, new Rectangle(.58, .565, .1, .0695));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack2, new Rectangle(.86, .565, .35, .0695));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_registerButton, new Rectangle(.5, .7, .83, .07));
            AbsoluteLayout.SetLayoutFlags(_registerButton, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back, new Rectangle(.5, .88, .175, .1));
            AbsoluteLayout.SetLayoutFlags(_back, AbsoluteLayoutFlags.All);

#if __IOS__
            AbsoluteLayout.SetLayoutBounds(_titleText, new Rectangle(.5, .35, .28, .1));
            AbsoluteLayout.SetLayoutFlags(_titleText, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailText, new Rectangle(.91, .58, .4, .06));
            AbsoluteLayout.SetLayoutFlags(_emailText, AbsoluteLayoutFlags.All);
#endif
#if __ANDROID__
            AbsoluteLayout.SetLayoutBounds(_titleText, new Rectangle(.5, .35, .35, .1));
            AbsoluteLayout.SetLayoutFlags(_titleText, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailText, new Rectangle(.91, .575, .4, .06));
            AbsoluteLayout.SetLayoutFlags(_emailText, AbsoluteLayoutFlags.All);
#endif

            layout.Children.Add(_background);
            layout.Children.Add(_logo);
            layout.Children.Add(_titleText);
            layout.Children.Add(_whiteBack1);
            layout.Children.Add(_firstInput);
            layout.Children.Add(_lastInput);
            layout.Children.Add(_line);
            layout.Children.Add(_whiteBack2);
            layout.Children.Add(_emailInput);
            layout.Children.Add(_emailTextBack1);
            layout.Children.Add(_emailTextBack2);
            layout.Children.Add(_emailText);
            layout.Children.Add(_registerButton);
            layout.Children.Add(_back);

            Content = layout;

            var _back_tap = new TapGestureRecognizer();
            _back_tap.Tapped += async (s, e) =>
            {
                if (disable)
                    return;

                disable = true;

                Navigation.PushModalAsync(new LoginPage());

                disable = false;
            };
            _back.GestureRecognizers.Add(_back_tap);
        }

        string emailRegex = @"^[a-z0-9]+[_a-z0-9\.-]*[a-z0-9]";

        private async void _registerButton_Clicked(object sender, EventArgs e)
        {
            List<string> errorMsg = new List<string>();
            // email controle
            if (!string.IsNullOrEmpty(_emailInput.Text))
            {
                Match result = Regex.Match(_emailInput.Text.Trim(), emailRegex);
                if (!(result.Success))
                {
                    errorMsg.Add("Voer een geldig email adres in");
                }
            }
            else
            {
                errorMsg.Add("Vul een email in");
            }

            // voornaam controle
            if (string.IsNullOrEmpty(_firstInput.Text))
            {
                errorMsg.Add("Vul een voornaam in");
            }

            if (string.IsNullOrEmpty(_lastInput.Text))
            {
                errorMsg.Add("Vul een achternaam in");
            }

            if (errorMsg.Count() == 0)
            {
                // register
                string completeEmail = _emailInput.Text.Trim() + _emailText.Text;
                ApiClient client = new ApiClient();
                ClientOutput output = await client.registerData(completeEmail, _firstInput.Text.Trim(), _lastInput.Text.Trim());
                if (output.errorCode == 0)
                {
                    Navigation.PushModalAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Let op!", output.Content, "OK");
                }
            }
            else
            {
                // log errors en laten weergeven
                string errorString = "";
                foreach (string value in errorMsg)
                {
                    errorString += value + "\n";
                }
                await DisplayAlert("Let op!", errorString, "OK");
            }
        }
    }
}
