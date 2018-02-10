using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System;
using Android.Views;

namespace ExampleDroid
{
    [Activity(Label = "Menu", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, ListView.IOnItemClickListener
    {
        string[] items;
        ArrayList menuCollection = new ArrayList();
        IListAdapter listAdapter;
        ListView menuListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Populates the menu ListView for App Navigation
            populateMenu();
            items = new string[]{"One", "Two", "Three"};
            menuListView = FindViewById<ListView>(Resource.Id.listViewMenu);
            listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, ((String[])menuCollection.ToArray(typeof(string))));
            menuListView.Adapter = listAdapter;
            menuListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => { 
                String selectedFromList = (string)menuListView.GetItemAtPosition(e.Position); 
                Toast.MakeText(this, selectedFromList, ToastLength.Short).Show();
            };
            //menuListView.SetOnClickListener(this);
            //button.Click += delegate { button.Text = $"{count++} clicks!"; };
        }


        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            string t = (string)menuCollection[position];
            Toast.MakeText(this, t, ToastLength.Short).Show();
        }

        private void populateMenu()
        {
            menuCollection.Add("Toasts");
            menuCollection.Add("Snackbars");
            menuCollection.Add("ListView");
            menuCollection.Add("GridView");
            menuCollection.Add("CardView");
            menuCollection.Add("Picker");
            menuCollection.Add("DatePicker");
            menuCollection.Add("Spinner");
            menuCollection.Add("Switch");
            menuCollection.Add("PagerView");
            menuCollection.Add("WebView");
            menuCollection.Add("Fingerprint Auth");
            menuCollection.Add("Camera");
            menuCollection.Add("Camera & ContentProvider");
            menuCollection.Add("Notifications");
            menuCollection.Add("Basic Fragment");
            menuCollection.Add("Fragment with Menu");
            menuCollection.Add("Fragment with Data");
        }
    }
}

