using ImageCircle.Forms.Plugin.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class FirstTimeLoginPage : ContentPage
	{
        private Image _background;
        private Label _title;
        private CustomButton _imageBtn;
        private CircleImage _image;
        private CustomBoxView _back1;
        private Entry _firstName;
        private CustomBoxView _back2;
        private Entry _lastName;
        private CustomBoxView _back3;
        private DatePicker _date;
        private CustomBoxView _back4;
        private Picker _picker;
        private CustomSlider _slider;
        private Label _color;
        private CustomBoxView _back5;
        private Entry _status;
        private CustomBoxView _back6;
        private Picker _picker2;
        private CustomBoxView _back7;
        private CustomBoxView _back8;
        private CustomBoxView _back9;
        private CustomBoxView _back10;
        private CustomBoxView _back11;
        private CustomBoxView _back12;
        private CustomBoxView _back13;
        private Button _editButton;

        ICredentialsService storeService;
        bool disable = false;

        public FirstTimeLoginPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);

            BackgroundImage = "background.png";

            storeService = DependencyService.Get<ICredentialsService>();

            var genderList = new List<string>();
            genderList.Add("Man");
            genderList.Add("Vrouw");
            genderList.Add("Weet het niet niet zeker");

            var jobList = new List<string>();
            jobList.Add("Grafisch vormgever");
            jobList.Add("Frontend developer");
            jobList.Add("Backend developer");
            jobList.Add("Baliemedewerker");
            jobList.Add("Marketing");
            jobList.Add("Afwashulpje");

            #region Design

            /*_background = new Image
            {
                Source = "background.png",
                Aspect = Aspect.AspectFill
            };*/

            _title = new Label
            {
                Text = "Gegevens",
                FontFamily = Device.OnPlatform(
                    "Baloo-Regular",
                    "Baloo-Regular.ttf#Baloo-Regular",
                    null
                ),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.White
            };

            _imageBtn = new CustomButton
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.Transparent,
                TextColor = Color.FromHex("fff"),
                BorderRadius = 25,
                HeightRequest = 110,
                WidthRequest = 110,
            };

            _image = new CircleImage
            {
                Source = "temp.png",
                HeightRequest = 155,
                WidthRequest = 155,
                Aspect = Aspect.AspectFill,
            };

            _back1 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _firstName = new Entry
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

            _back2 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _lastName = new Entry
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

            _back3 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _date = new DatePicker
            {
                Format = "d/M/yyyy",
                TextColor = Color.FromHex("#9e9e9e")
            };

            _back4 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _picker = new Picker
            {
                Title = "Geslacht",
                TextColor = Color.FromHex("#9e9e9e")
            };

            _back5 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _color = new Label
            {
                Text = "Huidskleur",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                )
            };

            _slider = new CustomSlider
            {
                Minimum = 0,
                Maximum = 3,
                StepValue = 1,
                BackgroundColor = Color.FromHex("f9b49d"),
                CornerRadius = 25,
                HeightRequest = 25
            };

            _back6 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _status = new Entry
            {
                Placeholder = "Status",
                TextColor = Color.FromHex("#9e9e9e"),
                FontSize = 15,
                Margin = new Thickness(0, 0, 0, -5),
                FontFamily = Device.OnPlatform(
                    "VarelaRound-Regular",
                    "VarelaRound-Regular.ttf#VarelaRound-Regular",
                    null
                )
            };

            _back7 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _picker2 = new Picker
            {
                Title = "Functie",
                TextColor = Color.FromHex("#9e9e9e")
            };

            _back8 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _back9 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _back10 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _back11 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _back12 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _back13 = new CustomBoxView
            {
                BackgroundColor = Color.White,
                CornerRadius = 25,
            };

            _editButton = new CustomButton
            {
                Text = "Aanpassen",
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

            #endregion

            _picker.ItemsSource = genderList;
            _picker2.ItemsSource = jobList;


            _imageBtn.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                _image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };

            #region Absolute layout
            var layout = new AbsoluteLayout { };

            var layout3 = new AbsoluteLayout { };

            var layout4 = new AbsoluteLayout { };

#if __IOS__
            AbsoluteLayout.SetLayoutBounds(_title, new Rectangle(.5, .05, .23, .2));
            AbsoluteLayout.SetLayoutFlags(_title, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_imageBtn, new Rectangle(.5, -0.08, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_imageBtn, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_image, new Rectangle(.5, .08, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_image, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back1, new Rectangle(.5, .4, .83, .08));
            AbsoluteLayout.SetLayoutFlags(_back1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_firstName, new Rectangle(.5, .4, .75, .06));
            AbsoluteLayout.SetLayoutFlags(_firstName, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back2, new Rectangle(.5, .5, .83, .08));
            AbsoluteLayout.SetLayoutFlags(_back2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_lastName, new Rectangle(.5, .5, .75, .06));
            AbsoluteLayout.SetLayoutFlags(_lastName, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back3, new Rectangle(.5, .6, .83, .08));
            AbsoluteLayout.SetLayoutFlags(_back3, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_date, new Rectangle(.5, .6, .75, .075));
            AbsoluteLayout.SetLayoutFlags(_date, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back4, new Rectangle(.5, .6, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back4, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_picker, new Rectangle(.5, .61, .75, .075));
            AbsoluteLayout.SetLayoutFlags(_picker, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back5, new Rectangle(.5, .71, .83, .04));
            AbsoluteLayout.SetLayoutFlags(_back5, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_color, new Rectangle(.11, .665, .2, .04));
            AbsoluteLayout.SetLayoutFlags(_color, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_slider, new Rectangle(.5, .71, .77, .04));
            AbsoluteLayout.SetLayoutFlags(_slider, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back6, new Rectangle(.5, .81, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back6, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_status, new Rectangle(.3, .81, .6, .064));
            AbsoluteLayout.SetLayoutFlags(_status, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back7, new Rectangle(.5, .89, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back7, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_picker2, new Rectangle(.5, .9, .75, .075));
            AbsoluteLayout.SetLayoutFlags(_picker2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back8, new Rectangle(.5, 1, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back8, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back9, new Rectangle(.5, .0, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back9, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back10, new Rectangle(.5, .3, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back10, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back11, new Rectangle(.5, .6, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back11, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back12, new Rectangle(.5, 1, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back12, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back13, new Rectangle(.5, 0, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back13, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_editButton, new Rectangle(.5, .5, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_editButton, AbsoluteLayoutFlags.All);
#endif
#if __ANDROID__
            AbsoluteLayout.SetLayoutBounds(_title, new Rectangle(.5, .05, .23, .2));
            AbsoluteLayout.SetLayoutFlags(_title, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_imageBtn, new Rectangle(.5, -0.08, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_imageBtn, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_image, new Rectangle(.5, .08, .3, .3));
            AbsoluteLayout.SetLayoutFlags(_image, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back1, new Rectangle(.5, .36, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back1, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_firstName, new Rectangle(.5, .36, .75, .06));
            AbsoluteLayout.SetLayoutFlags(_firstName, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back2, new Rectangle(.5, .44, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_lastName, new Rectangle(.5, .44, .75, .06));
            AbsoluteLayout.SetLayoutFlags(_lastName, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back3, new Rectangle(.5, .52, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back3, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_date, new Rectangle(.5, .53, .75, .075));
            AbsoluteLayout.SetLayoutFlags(_date, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back4, new Rectangle(.5, .6, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back4, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_picker, new Rectangle(.5, .61, .75, .075));
            AbsoluteLayout.SetLayoutFlags(_picker, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back5, new Rectangle(.5, .71, .83, .04));
            AbsoluteLayout.SetLayoutFlags(_back5, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_color, new Rectangle(.11, .665, .2, .04));
            AbsoluteLayout.SetLayoutFlags(_color, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_slider, new Rectangle(.5, .71, .77, .04));
            AbsoluteLayout.SetLayoutFlags(_slider, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back6, new Rectangle(.5, .81, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back6, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_status, new Rectangle(.3, .81, .6, .064));
            AbsoluteLayout.SetLayoutFlags(_status, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back7, new Rectangle(.5, .89, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back7, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_picker2, new Rectangle(.5, .9, .75, .075));
            AbsoluteLayout.SetLayoutFlags(_picker2, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back8, new Rectangle(.5, 1, .83, .065));
            AbsoluteLayout.SetLayoutFlags(_back8, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back9, new Rectangle(.5, .0, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back9, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back10, new Rectangle(.5, .3, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back10, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back11, new Rectangle(.5, .6, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back11, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back12, new Rectangle(.5, 1, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back12, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_back13, new Rectangle(.5, 0, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_back13, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(_editButton, new Rectangle(.5, .5, .83, .2));
            AbsoluteLayout.SetLayoutFlags(_editButton, AbsoluteLayoutFlags.All);
#endif
            layout.Children.Add(_title);
            layout.Children.Add(_image);
            layout.Children.Add(_imageBtn);
            layout.Children.Add(_back1);
            layout.Children.Add(_firstName);
            layout.Children.Add(_back2);
            layout.Children.Add(_lastName);
            layout.Children.Add(_back3);
            layout.Children.Add(_date);
            /*layout.Children.Add(_back4);
            layout.Children.Add(_picker);
            layout.Children.Add(_back5);
            layout.Children.Add(_color);
            layout.Children.Add(_slider);
            layout.Children.Add(_back6);
            layout.Children.Add(_status);
            layout.Children.Add(_back7);
            layout.Children.Add(_picker2);
            layout.Children.Add(_back8);
            layout3.Children.Add(_back9);
            layout3.Children.Add(_back10);
            layout3.Children.Add(_back11);
            layout3.Children.Add(_back12);
            layout4.Children.Add(_back13);
            layout4.Children.Add(_editButton);*/

            StackLayout layout2 = new StackLayout()
            {
               // HeightRequest = 1000,
                Children = {
                    layout,
                    layout3,
                    layout4
                }
            };

            Content = new ScrollView { Content = layout2 };
         
            #endregion
        }

    }
}
