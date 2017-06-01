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
        private CustomButton _loginButton;
        private Label _register;
        private Label _forgotPass;
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
            //BackgroundColor = Color.FromHex("#eb3e12");
            NavigationPage.SetHasNavigationBar(this, false);

            storeService = DependencyService.Get<ICredentialsService>();

            #region Design
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
                FontSize = 15,
                Margin = new Thickness(0,0,0,-5),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                )
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

            _emailBack = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            // wachtwoord veld aanmaken
            _passwordInput = new Entry
             {
                Placeholder = "Wachtwoord",
                TextColor = Color.FromHex("#9e9e9e"),
                FontSize = 15,
                Margin = new Thickness(0, 0, 0, -5),
                IsPassword = true,
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                ),
            };

            _passBack = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            // login knop aanmaken
            _loginButton = new CustomButton
             {
                Text = "inloggen",
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

            _register = new Label
            {
                Text = "Nieuw account aanmaken",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                ),
            };

            _forgotPass = new Label
            {
                Text = "Wachtwoord vergeten?",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                ),
            };
            #endregion

            _loginButton.Clicked += _loginButton_Clicked;

            #region Absolute layout
            var layout = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutBounds(_logo, new Rectangle(.5, .03, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_logo, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_background, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(_background, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailInput, new Rectangle(.215, .4, .38, .06));
            AbsoluteLayout.SetLayoutFlags(_emailInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailBack, new Rectangle(.5, .4, .83, .075));
            AbsoluteLayout.SetLayoutFlags(_emailBack, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_passwordInput, new Rectangle(.5, .525, .74, .06));
            AbsoluteLayout.SetLayoutFlags(_passwordInput, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_passBack, new Rectangle(.5, .525, .83, .075));
            AbsoluteLayout.SetLayoutFlags(_passBack, AbsoluteLayoutFlags.All);

#if __IOS__
            AbsoluteLayout.SetLayoutBounds(_loginButton, new Rectangle(.86, .63, .34, .075));
            AbsoluteLayout.SetLayoutFlags(_loginButton, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailText, new Rectangle(.91, .417, .4, .06));
            AbsoluteLayout.SetLayoutFlags(_emailText, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack1, new Rectangle(.58, .4, .1, .0695));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack2, new Rectangle(.86, .4, .35, .0695));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack2, AbsoluteLayoutFlags.All);
#endif
#if __ANDROID__
            AbsoluteLayout.SetLayoutBounds(_loginButton, new Rectangle(.86, .65, .34, .075));
            AbsoluteLayout.SetLayoutFlags(_loginButton, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailText, new Rectangle(.91, .412, .4, .06));
            AbsoluteLayout.SetLayoutFlags(_emailText, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack1, new Rectangle(.58, .4017, .1, .0695));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_emailTextBack2, new Rectangle(.86, .4017, .35, .0695));
            AbsoluteLayout.SetLayoutFlags(_emailTextBack2, AbsoluteLayoutFlags.All);
#endif

            AbsoluteLayout.SetLayoutBounds(_register, new Rectangle(.215, .662, .6, .0325));
            AbsoluteLayout.SetLayoutFlags(_register, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_forgotPass, new Rectangle(.215, .62, .6, .0325));
            AbsoluteLayout.SetLayoutFlags(_forgotPass, AbsoluteLayoutFlags.All);

            layout.Children.Add(_background);
            layout.Children.Add(_logo);
            layout.Children.Add(_emailBack);
            layout.Children.Add(_emailTextBack2);
            layout.Children.Add(_emailTextBack1);
            layout.Children.Add(_emailText);
            layout.Children.Add(_emailInput);
            layout.Children.Add(_passBack);
            layout.Children.Add(_passwordInput);
            layout.Children.Add(_register);
            layout.Children.Add(_forgotPass);
            layout.Children.Add(_loginButton);

            Content = layout;
            #endregion

            #region Tekst klik
            var _register_tap = new TapGestureRecognizer();
            _register_tap.Tapped += async (s, e) =>
            {
                if (disable)
                    return;

                disable = true;

                Navigation.PushModalAsync(new RegisterPage());

                disable = false;
            };

            _register.GestureRecognizers.Add(_register_tap);

            var _forgotPass_tap = new TapGestureRecognizer();
            _forgotPass_tap.Tapped += async (s, e) =>
            {
                if (disable)
                    return;

                disable = true;

                Navigation.PushModalAsync(new ForgotPasswordPage());

                disable = false;
            };
            _forgotPass.GestureRecognizers.Add(_forgotPass_tap);

        }
        #endregion

        string emailRegex = @"^[a-z0-9]+[_a-z0-9\.-]*[a-z0-9]";

        private async void _loginButton_Clicked(object sender, EventArgs e)
        {
            if (disable)
                return;

            disable = true;

            List<string> errorMsg = new List<string>();
            // email adres controle
            if (!string.IsNullOrEmpty(_emailInput.Text.Trim()))
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
                string completeEmail = _emailInput.Text.Trim() + _emailText.Text;
                ApiClient client = new ApiClient();
                ClientOutput output = await client.loginUserData(completeEmail, _passwordInput.Text.Trim());
                if (output.errorCode == 0)
                {
                    UserInfo userInfo = (UserInfo)JsonConvert.DeserializeObject(output.Content, typeof(UserInfo));

                    bool doCredentialsExist = storeService.DoCredentialsExist();
                    if (!doCredentialsExist)
                    {
                        storeService.SaveCredentials(completeEmail, _passwordInput.Text.Trim());
                    }

                    Navigation.PushModalAsync(new HomePage());
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
