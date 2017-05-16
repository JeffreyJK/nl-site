using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace nl_site
{
    public class CustomCell : ViewCell
    {

        public CustomCell()
        {
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();

            CircleImage groupImage = new CircleImage
            {
                BorderColor = Color.White,
                BorderThickness = 3,
                HeightRequest = 55,
                WidthRequest = 55,
                Aspect = Aspect.AspectFill,
                Margin = 10
            };

            Label title = new Label {
                TextColor = Color.FromHex("#ff5300"),
                FontSize = 16,
                VerticalOptions = LayoutOptions.CenterAndExpand,
              /*  FontFamily = Device.OnPlatform(
                null,
                "Baloo-Regular.ttf#Baloo-Regular", // Android
                null
                )*/
            };

            Label right = new Label {
                TextColor = Color.FromHex("#503026"),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0,0,15,0)
            };

            //set bindings
            groupImage.SetBinding(Image.SourceProperty, "cachedThumbnail");
            title.SetBinding(Label.TextProperty, "title");
            right.SetBinding(Label.TextProperty, "created_at");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;

            //add views to the view hierarchy
            horizontalLayout.Children.Add(groupImage);
            horizontalLayout.Children.Add(title);
            horizontalLayout.Children.Add(right);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
}