using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace nl_site
{
    class CustomBoxView : BoxView
    {
        public static readonly BindableProperty CornerRaidusProperty = BindableProperty.Create<CustomBoxView, float>(x => x.CornerRadius, 0);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRaidusProperty); }
            set { SetValue(CornerRaidusProperty, value); }
        }
    }
}
