
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ExampleDroid
{
    [Activity(Label = "Switches")]
    public class Switches : Activity
    {

        TextView switchTextView;
        float textSize = 14.0f;
        LinearLayout backgroundLayout;
        Switch toggleSwitch1;
        Switch toggleSwitch2;
        Android.Graphics.Color textColorLight = Android.Graphics.Color.ParseColor("#fff2f2f2");
        Android.Graphics.Color textColorDark = Android.Graphics.Color.ParseColor("#ff212121");
        Android.Graphics.Color BackgroundColorDark = Android.Graphics.Color.ParseColor("#ff212121");
        Android.Graphics.Color BackgroundColorLight = Android.Graphics.Color.ParseColor("#fff2f2f2");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Switches" layout resource
            SetContentView(Resource.Layout.Switches);

            backgroundLayout = FindViewById<LinearLayout>(Resource.Id.bgSwitchesBackground);
            switchTextView = FindViewById<TextView>(Resource.Id.tvSwitchesTextView);

            toggleSwitch1 = FindViewById<Switch>(Resource.Id.switchSwitchesTextSize);
            toggleSwitch2 = FindViewById<Switch>(Resource.Id.switchSwitchesNightMode);

            switchTextView.TextSize = textSize;
            switchTextView.SetTextColor(textColorDark);
            toggleSwitch1.SetTextColor(textColorDark);
            toggleSwitch2.SetTextColor(textColorDark);
            backgroundLayout.SetBackgroundColor(BackgroundColorLight);

            toggleSwitch1.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                switchTextView.TextSize = e.IsChecked ? textSize = 24.0f : textSize = 14.0f;
            };

            toggleSwitch2.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                switchTextView.SetTextColor(e.IsChecked ? textColorLight : textColorDark);
                toggleSwitch1.SetTextColor(e.IsChecked ? textColorLight : textColorDark);
                toggleSwitch2.SetTextColor(e.IsChecked ? textColorLight : textColorDark);
                backgroundLayout.SetBackgroundColor(e.IsChecked ? BackgroundColorDark : BackgroundColorLight);
            };

        }
    }
}
