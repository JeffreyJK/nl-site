using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace nl_site
{
	public class CustomSlider : Slider
	{
        public static readonly BindableProperty CurrentStepValueProperty = BindableProperty.Create<CustomSlider, double>(p => p.StepValue, 1.0f);

        public static readonly BindableProperty CornerRaidusProperty = BindableProperty.Create<CustomSlider, float>(x => x.CornerRadius, 0);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRaidusProperty); }
            set { SetValue(CornerRaidusProperty, value); }
        }

        public double StepValue
        {
            get { return (double)GetValue(CurrentStepValueProperty); }

            set { SetValue(CurrentStepValueProperty, value); }
        }

        public CustomSlider()
        {
            ValueChanged += OnSliderValueChanged;
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);

            Value = newStep * StepValue;

            if (Value >= 0)
            {
                BackgroundColor = Color.FromHex("f9b49d");
            };

            if (Value >= 1) {
                BackgroundColor = Color.FromHex("f2ae5b");
            };

            if (Value >= 2)
            {
                BackgroundColor = Color.FromHex("ac6c3e");
            };

            if (Value >= 3)
            {
                BackgroundColor = Color.FromHex("674021");
            };
        }
    }
}