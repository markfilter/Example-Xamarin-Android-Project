using System;
using System.Collections.Generic;
using Android.OS;
using ExampleDroid.Data;

namespace ExampleDroid.Data
{
    
    public class InnerData
    {
        public string thumbnail { get; set; }
        public string title { get; set; }

        public InnerData(){}

        public InnerData(Bundle bundle) 
        {
            this.thumbnail = bundle.GetString("thumbnail");
            this.title = bundle.GetString("title");
        }

        public Bundle GetBundle() {
            Bundle returnBundle = new Bundle();
            returnBundle.PutString("title", this.title);
            returnBundle.PutString("thumbnail", this.thumbnail);
            return returnBundle;
        }
    }

    public class Child
    {
        public string kind { get; set; }
        public InnerData data { get; set; }
    }

    public class OuterData
    {
        public IList<Child> children { get; set; }
    }

    public class MZFReddit
    {
        public string kind { get; set; }
        public OuterData data { get; set; }
    }


}
