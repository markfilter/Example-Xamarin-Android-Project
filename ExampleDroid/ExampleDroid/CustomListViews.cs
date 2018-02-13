
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
using Android.Support.V7.App;

namespace ExampleDroid
{
    [Activity(Label = "CustomListViews")]
    public class CustomListViews : AppCompatActivity
    {
        //ObservableCollection<String> observableDataSource = new ObservableCollection<String>();
        ListView listView;
        ArrayList dataSource;
        ArrayAdapter listAdapter;
        Toast toast;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Custom ListViews" layout resource
            SetContentView(Resource.Layout.DynamicListViews);

            dataSource = new ArrayList();
            listView = FindViewById<ListView>(Resource.Id.lvCustomListViewsListView);

            SetupListView();


            FindViewById(Resource.Id.buttonCustomListViewsAdd).Click += (object sender, EventArgs e) => {
                if (dataSource.Count < 21)
                {
                    dataSource.Add(String.Concat((20 - dataSource.Count)) + " Clicks Remaining");
                    // I am recreating the ListAdapter and assigning it to the listView because
                    // Xamarin evidently doesn't know how to make NotifyDataSetChanged easily 
                    // located and certainly doesn't follow Android Native Development practices.
                    //observableDataSource.Add(String.Concat((20 - dataSource.Count)) + " Clicks Remaining"); // Doesn't actually work
                    listAdapter.NotifyDataSetChanged(); // Doesn't actually work
                    SetupListView(); // Does work

                    if (toast != null)
                    {
                        toast.Cancel();
                    }
                    toast = Toast.MakeText(this, "Add", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    Toast.MakeText(this, "Warning! Cannot exceed 20 clicks!", ToastLength.Short).Show();
                }

            };




            FindViewById(Resource.Id.buttonCustomListViewsDelete).Click += (object sender, EventArgs e) => {
                if (dataSource.Count > 0)
                {
                    //observableDataSource.Remove((string)dataSource[dataSource.Count - 1]);
                    dataSource.Remove(dataSource[dataSource.Count - 1]);
                    // I am recreating the ListAdapter and assigning it to the listView because
                    // Xamarin evidently doesn't know how to make NotifyDataSetChanged easily 
                    // located and certainly doesn't follow Android Native Development practices.
                    listAdapter.NotifyDataSetChanged(); // Doesn't actually work
                    SetupListView(); // Does work

                    if (toast != null)
                    {
                        toast.Cancel();
                    }
                    toast = Toast.MakeText(this, "Delete", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    Toast.MakeText(this, "Warning! Zero is the lowest you can go!", ToastLength.Short).Show();
                }
            };

        }




        private void SetupListView()
        {
            listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, ((String[])dataSource.ToArray(typeof(string))));
            //listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, observableDataSource);
            listAdapter.SetNotifyOnChange(true);
            listView.Adapter = listAdapter;
            listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
                String selectedFromList = (string)listView.GetItemAtPosition(e.Position);
                Toast.MakeText(this, selectedFromList, ToastLength.Short).Show();
            };
        }
    }
}
