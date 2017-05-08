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

        bool disable = false;

        public LoginPage()
        {
            var buttonStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter {Property = Button.BackgroundColorProperty, Value = Color.FromHex("ffffff")},
                    new Setter {Property = Button.TextColorProperty, Value = Color.FromHex("b7b1b1")},
                    new Setter {Property = Button.BorderRadiusProperty, Value = 10},
                    new Setter {Property = Button.FontSizeProperty, Value = 20}
                }
            };

            // grid aanmaken
            var loginGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };

            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            loginGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            loginGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // email veld aanmaken
            _emailInput = new Entry
             {
                 Placeholder = "Email",
                 TextColor = Color.Black
             };

            _emailText = new Label
            {
                Text = "@nederland-site.nl",
                TextColor = Color.Black
            };

            // wachtwoord veld aanmaken
            _passwordInput = new Entry
             {
                 Placeholder = "Wachtwoord",
                 TextColor = Color.Black,
                 IsPassword = true
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

            loginGrid.Children.Add(_emailInput, 1, 2);
            loginGrid.Children.Add(_emailText, 4, 2);
            loginGrid.Children.Add(_passwordInput, 1, 3);
            loginGrid.Children.Add(_loginButton, 1, 5);
            loginGrid.Children.Add(_register, 1, 6);

            Grid.SetColumnSpan(_emailInput, 3);
            Grid.SetColumnSpan(_emailText, 3);
            Grid.SetColumnSpan(_passwordInput, 5);
            Grid.SetColumnSpan(_loginButton, 5);
            Grid.SetColumnSpan(_register, 5);

            // plaats content op de pagina
            Content = loginGrid;

            var _register_tap = new TapGestureRecognizer();
            _register_tap.Tapped += async (s, e) =>
            {
                if (disable)
                    return;

                disable = true;

                await Navigation.PushModalAsync(new RegisterPage());

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
                    
                    await Navigation.PushModalAsync(new MainPage());
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
