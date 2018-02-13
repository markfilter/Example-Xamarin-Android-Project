
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
using Android.Support.V7.App;

namespace ExampleDroid
{
    [Activity(Label = "Spinners")]
    public class Spinners : AppCompatActivity
    {
        TextView outputTextView;
        string cryptoCurrencySelection;
        string market;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Toasts" layout resource
            SetContentView(Resource.Layout.Spinners);

            // Initialize Output TextView
            outputTextView = FindViewById<TextView>(Resource.Id.tvSpinnersOutput);

            // Setup Spinner: hardcoded from CS file
            SetupSpinnerFromCSFile();

            // Setup Spinner: hardcoded from Resource file
            SetupSpinnerFromResourceFile();
        }

        /// <summary>
        /// Setups the spinner from resource file.
        /// </summary>
        private void SetupSpinnerFromResourceFile()
        {
            Spinner spinnerHardcodedResource = FindViewById<Spinner>(Resource.Id.spSpinnersHardcodedResource);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.spinners_currency, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerHardcodedResource.Adapter = adapter;

            spinnerHardcodedResource.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                string[] options = Resources.GetStringArray(Resource.Array.spinners_currency);
                market = options[e.Id];
                ProcessOutput();
            };

        }

        /// <summary>
        /// Setups the spinner from CS File.
        /// </summary>
        private void SetupSpinnerFromCSFile()
        {
            Spinner spinnerHardcodedCS = FindViewById<Spinner>(Resource.Id.spSpinnersHardcodedCS);
            string[] options = { "Bitcoin", "Bitcoin Cash", "Ethereum", "Litecoin", "Dogecoin" };
            ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.TextViewForSpinner, options);
            spinnerHardcodedCS.Adapter = adapter;
            spinnerHardcodedCS.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                cryptoCurrencySelection = options[e.Id];
                ProcessOutput();
            };
        }

        /// <summary>
        /// Processes the output after checking to ensure that both variables, cryptoCurrencySelection and market, are not null.
        /// </summary>
        private void ProcessOutput()
        {
            if (cryptoCurrencySelection != null && market != null) {
                switch (market)
                {
                    case "USD":
                        outputTextView.Text = "USD 8,675,309";
                        break;
                    case "EUR":
                        outputTextView.Text = "EUR 6,940,247.20";
                        break;
                    case "GBP":
                        outputTextView.Text = "GBP 6,246,222.48";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
