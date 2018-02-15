
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
    [Activity(Label = "Fragment With Menu Activity")]
    public class FragmentWithMenuActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FragmentWithMenuActivity);

            var fragmentWithMenu = new FragmentWithMenu();
            var supportFragmentManager = SupportFragmentManager.BeginTransaction();
            supportFragmentManager.Add(Resource.Id.fragmentContainer, fragmentWithMenu, FragmentWithMenu.TAG);
            supportFragmentManager.Commit();

        }
    }
}
