
using System;
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
    public class FragmentWithMenu : Android.Support.V4.App.Fragment
    {

        public static string TAG = "FragmentWithMenu.TAG";
        TextView fragmentTextView;



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            HasOptionsMenu = true;
           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return inflater.Inflate(Resource.Layout.FragmentWithMenu, container, false);
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
        }


        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.fragment_menu, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (View != null) 
            {
                fragmentTextView = View.FindViewById<TextView>(Resource.Id.tvFragmentWithMenuTextView);
            }

        }




        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            int itemId = item.ItemId;
            switch (itemId)
            {
                case Resource.Id.action_matches:
                    fragmentTextView.Text = "Matches was selected";
                    break;
                case Resource.Id.action_messages:
                    fragmentTextView.Text = "Messages was selected";
                    break;
                case Resource.Id.action_notifications:
                    fragmentTextView.Text = "Notifications was selected";
                    break;
                case Resource.Id.action_profile:
                    fragmentTextView.Text = "Profile was selected";
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}
