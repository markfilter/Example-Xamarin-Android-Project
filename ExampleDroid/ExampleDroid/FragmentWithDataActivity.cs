
using System;
using System.Collections;
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
    [Activity(Label = "Fragment With Data Activity")]
    public class FragmentWithDataActivity : Android.Support.V7.App.AppCompatActivity
    {

        ArrayList dataSet = new ArrayList();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FragmentWithDataActivity);

            dataSet.Add("One");
            dataSet.Add("Two");
            dataSet.Add("Three");
            dataSet.Add("Four");
            dataSet.Add("Five");


            var fragmentWithData = new FragmentWithData(this, dataSet);
            var supportFragmentManager = SupportFragmentManager.BeginTransaction();
            supportFragmentManager.Add(Resource.Id.fragmentContainer, fragmentWithData, FragmentWithData.TAG);
            supportFragmentManager.Commit();

        }
    }
}
