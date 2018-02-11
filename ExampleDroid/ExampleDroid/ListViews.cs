
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
    [Activity(Label = "ListViews")]
    public class ListViews : Activity
    {

        ListView listView;
        ArrayList dataSource;
        IListAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "ListViews" layout resource
            SetContentView(Resource.Layout.ListViews);

            dataSource = new ArrayList();
            listView = FindViewById<ListView>(Resource.Id.lvListViewsListView);

            SetupListView();


            FindViewById(Resource.Id.buttonListViewsAdd).Click += (object sender, EventArgs e) => {
                if (dataSource.Count < 21) {
                    dataSource.Add( String.Concat((20 - dataSource.Count + 1)) + " Clicks Remaining");
                    // I am recreating the ListAdapter and assigning it to the listView because
                    // Xamarin evidently doesn't know how to make NotifyDataSetChanged easily 
                    // located and certainly doesn't follow Android Native Development practices.
                    SetupListView();
                    Toast.MakeText(this, "Add", ToastLength.Short).Show();
                }
                else {
                    Toast.MakeText(this, "Warning! Cannot exceed 20 clicks!", ToastLength.Short).Show();
                }

            };

            FindViewById(Resource.Id.buttonListViewsDelete).Click += (object sender, EventArgs e) => {
                if (dataSource.Count > 0)
                {
                    dataSource.Remove(dataSource[dataSource.Count - 1]);
                    // I am recreating the ListAdapter and assigning it to the listView because
                    // Xamarin evidently doesn't know how to make NotifyDataSetChanged easily 
                    // located and certainly doesn't follow Android Native Development practices.
                    SetupListView();
                    Toast.MakeText(this, "Delete", ToastLength.Short).Show();
                }
                else {
                    Toast.MakeText(this, "Warning! Zero is the lowest you can go!", ToastLength.Short).Show();
                }
            };

        }

        private void SetupListView()
        {
            listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, ((String[])dataSource.ToArray(typeof(string))));
            listView.Adapter = listAdapter;
            listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
                String selectedFromList = (string)listView.GetItemAtPosition(e.Position);
                Toast.MakeText(this, selectedFromList, ToastLength.Short).Show();
            };
        }
    }
}
