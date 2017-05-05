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
        private Entry _passwordInput;
        private Button _loginButton;

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

            // create email entry for join game menu
            _emailInput = new Entry
             {
                 Placeholder = "Email",
                 TextColor = Color.Black
             };

             // create password entry for join game menu
             _passwordInput = new Entry
             {
                 Placeholder = "Wachtwoord",
                 TextColor = Color.Black,
                 IsPassword = true
             };

             // create join button for join game menu
             _loginButton = new Button
             {
                 Text = "Login",
                 VerticalOptions = LayoutOptions.EndAndExpand,
                 Style = buttonStyle
             };

            _loginButton.Clicked += _loginButton_Clicked;

            loginGrid.Children.Add(_emailInput, 1, 2);
            loginGrid.Children.Add(_passwordInput, 1, 3);
            loginGrid.Children.Add(_loginButton, 1, 5);

            Grid.SetColumnSpan(_emailInput, 5);
            Grid.SetColumnSpan(_passwordInput, 5);
            Grid.SetColumnSpan(_loginButton, 5);

            // place elements on page
            Content = loginGrid;

        }

        string emailRegex = @"^([A-Z|a-z|0-9](\.|_){0,1})+[A-Z|a-z|0-9]\@([A-Z|a-z|0-9])+((\.){0,1}[A-Z|a-z|0-9]){2}\.[a-z]{2,3}$";

        private async void _loginButton_Clicked(object sender, EventArgs e)
        {
            List<string> errorMsg = new List<string>();
            // email adres
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
            // wachtwoord
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
                // Login
                ApiClient client = new ApiClient();
                ClientOutput output = await client.loginUserData(_emailInput.Text, _passwordInput.Text);
                if (output.errorCode == 0)
                {
                    UserInfo userInfo = (UserInfo)JsonConvert.DeserializeObject(output.Content, typeof(UserInfo));
                    
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Let op!", output.Content, "OK");
                }
            }
            else
            {
                // log errors
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
