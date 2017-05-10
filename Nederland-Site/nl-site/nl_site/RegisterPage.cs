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

        bool disable = false;

        public RegisterPage ()
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
            var registerGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };

            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            registerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            registerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // email veld aanmaken
            _emailInput = new Entry
            {
                Placeholder = "Email",
                TextColor = Color.Black
            };

            _emailText = new Label
            {
                Text = "@nederland-site.nl",
            };

            // voornaam veld aanmaken
            _firstInput = new Entry
            {
                Placeholder = "Voornaam",
                TextColor = Color.Black
            };
            
            // email veld aanmaken
            _lastInput = new Entry
            {
                Placeholder = "Achternaam",
                TextColor = Color.Black
            };

            // register knop aanmaken
            _registerButton = new Button
            {
                Text = "Maak aan",
                VerticalOptions = LayoutOptions.EndAndExpand,
                Style = buttonStyle
            };

            _login = new Label
            {
                Text = "Al een acount? Log dan in",
                TextColor = Color.Black
            };

            _registerButton.Clicked += _registerButton_Clicked;

            registerGrid.Children.Add(_emailInput, 1, 2);
            registerGrid.Children.Add(_emailText, 4, 2);
            registerGrid.Children.Add(_firstInput, 1, 3);
            registerGrid.Children.Add(_lastInput, 4, 3);
            registerGrid.Children.Add(_registerButton, 1, 5);
            registerGrid.Children.Add(_login, 1, 6);

            Grid.SetColumnSpan(_emailInput, 3);
            Grid.SetColumnSpan(_emailText, 3);
            Grid.SetColumnSpan(_firstInput, 2);
            Grid.SetColumnSpan(_lastInput, 2);
            Grid.SetColumnSpan(_registerButton, 5);
            Grid.SetColumnSpan(_login, 5);

            // elementen plaatsen on de pagina
            Content = registerGrid;

            var _login_tap = new TapGestureRecognizer();
            _login_tap.Tapped += async (s, e) =>
            {
                if (disable)
                    return;

                disable = true;

                Navigation.InsertPageBefore(new LoginPage(), this);
                await Navigation.PopAsync();

                disable = false;
            };
            _login.GestureRecognizers.Add(_login_tap);
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
                string completeEmail = _emailInput.Text + _emailText.Text;
                ApiClient client = new ApiClient();
                ClientOutput output = await client.registerData(completeEmail, _firstInput.Text, _lastInput.Text);
                if (output.errorCode == 0)
                {
                    Navigation.InsertPageBefore(new LoginPage(), this);
                    await Navigation.PopAsync();
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
