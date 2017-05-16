using Newtonsoft.Json;
using nl_site.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace nl_site
{
    public class LoginPage : ContentPage
	{

        private Entry _emailInput;
        private Label _emailText;
        private Entry _passwordInput;
        private Button _loginButton;
        private Label _register;
        private Image _logo;
        private Image _background;
        private CustomBoxView _emailBack;
        private CustomBoxView _passBack;
        private CustomBoxView _emailTextBack1;
        private CustomBoxView _emailTextBack2;

        ICredentialsService storeService;
        bool disable = false;

        public LoginPage()
        {
            storeService = DependencyService.Get<ICredentialsService>();

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

            // email veld aanmaken
            _emailInput = new Entry
             {
                 Placeholder = "Email",
                 TextColor = Color.FromHex("#9e9e9e"),
                 FontSize = 16
             };

            _emailText = new Label
            {
                Text = "@nederland-site.nl",
                TextColor = Color.White,
                FontFamily = Device.OnPlatform(
                    "Verela-Regular",
                    "Verela-Regular.ttf",
                    null
                ),
                WidthRequest = 30
            };

            _emailTextBack1 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 50,
            };

            _emailTextBack2 = new CustomBoxView
            {
                BackgroundColor = Color.FromHex("#eb3e12"),
                CornerRadius = 50,
            };

            _emailBack = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 50,
            };

            // wachtwoord veld aanmaken
            _passwordInput = new Entry
             {
                Placeholder = "Wachtwoord",
                TextColor = Color.FromHex("#9e9e9e"),
                IsPassword = true,
                FontSize = 16
             };

            _passBack = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 50,
            };

            // login knop aanmaken
            _loginButton = new Button
             {
                 Text = "Login",
                 VerticalOptions = LayoutOptions.EndAndExpand,
                 Style = buttonStyle
             };

            _register = new Label
            {
                Text = "Maak een nieuw account aan",
                TextColor = Color.Black
            };

            _loginButton.Clicked += _loginButton_Clicked;

            var layout = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutBounds(_logo, new Rectangle(.5, .03, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_logo, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_background, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(_background, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailInput, new Rectangle(.2, .4, .36, .06));
            AbsoluteLayout.SetLayoutFlags(_emailInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailText, new Rectangle(1.04, .415, .4, .06));
            AbsoluteLayout.SetLayoutFlags(_emailText, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack1, new Rectangle(.885, .4, .35, .075));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack2, new Rectangle(.8753, .402, .335, .065));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailBack, new Rectangle(.15, .4, .45, .075));
            AbsoluteLayout.SetLayoutFlags(_emailBack, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_passwordInput, new Rectangle(.5, .525, .75, .06));
            AbsoluteLayout.SetLayoutFlags(_passwordInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_passBack, new Rectangle(.5, .525, .84, .075));
            AbsoluteLayout.SetLayoutFlags(_passBack, AbsoluteLayoutFlags.All);

            layout.Children.Add(_background);
            layout.Children.Add(_logo);
            layout.Children.Add(_emailBack);
            layout.Children.Add(_emailTextBack1);
            layout.Children.Add(_emailTextBack2);
            layout.Children.Add(_emailText);
            layout.Children.Add(_emailInput);
            layout.Children.Add(_passBack);
            layout.Children.Add(_passwordInput);

            Content = layout;

            var _register_tap = new TapGestureRecognizer();
            _register_tap.Tapped += async (s, e) =>
            {
                if (disable)
                    return;

                disable = true;

                Navigation.InsertPageBefore(new RegisterPage(), this);
                await Navigation.PopAsync();

                disable = false;
            };
            _register.GestureRecognizers.Add(_register_tap);

        }

        string emailRegex = @"^[a-z0-9]+[_a-z0-9\.-]*[a-z0-9]";

        private async void _loginButton_Clicked(object sender, EventArgs e)
        {
            if (disable)
                return;

            disable = true;

            List<string> errorMsg = new List<string>();
            // email adres controle
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
            // wachtwoord controle
            if (!string.IsNullOrEmpty(_passwordInput.Text))
            {
                if (_passwordInput.Text.Trim().Length < 4)
                {
                    errorMsg.Add("Het wachtwoord moet uit minimaal 4 karakters bestaan");
                }
            }
            else
            {
                errorMsg.Add("Vul een wachtwoord in");
            }

            if (errorMsg.Count() == 0)
            {
                // login
                string completeEmail = _emailInput.Text + _emailText.Text;
                ApiClient client = new ApiClient();
                ClientOutput output = await client.loginUserData(completeEmail, _passwordInput.Text);
                if (output.errorCode == 0)
                {
                    UserInfo userInfo = (UserInfo)JsonConvert.DeserializeObject(output.Content, typeof(UserInfo));

                    bool doCredentialsExist = storeService.DoCredentialsExist();
                    if (!doCredentialsExist)
                    {
                        storeService.SaveCredentials(completeEmail, _passwordInput.Text);
                    }

                    Navigation.InsertPageBefore(new HomePage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    disable = false;
                    _passwordInput.Text = string.Empty;
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
                disable = false;
                _passwordInput.Text = string.Empty;
                await DisplayAlert("Let op!", errorString, "OK");
            }
        }
    }
}
