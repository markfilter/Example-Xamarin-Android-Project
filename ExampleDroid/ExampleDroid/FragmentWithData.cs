
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ExampleDroid
{
    public class FragmentWithData : Android.Support.V4.App.Fragment
    {

        public static string TAG = "FragmentWithData.TAG";
        Context context;
        TextView tvFragmentWithDataTextView;
        ArrayList stringArray;


        public FragmentWithData() {}

        public FragmentWithData(Context context, ArrayList stringArray) 
        {
            this.context = context;
            this.stringArray = stringArray;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            if (View != null) 
            {
                tvFragmentWithDataTextView = View.FindViewById<TextView>(Resource.Id.tvFragmentWithDataTextView);

                tvFragmentWithDataTextView.Text += ": ";

                for (int i = 0; i < stringArray.Count; i++) 
                {
                    if (i != stringArray.Count-1) 
                    {
                        tvFragmentWithDataTextView.Text += stringArray[i] + ", ";
                    }
                    else 
                    {
                        tvFragmentWithDataTextView.Text += stringArray[i];
                    }

                }
                    

            }

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return inflater.Inflate(Resource.Layout.FragmentWithData, container, false);
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
        }


    }
}
