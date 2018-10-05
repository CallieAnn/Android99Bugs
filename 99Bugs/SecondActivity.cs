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

namespace _99Bugs
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        TextView bugsLeftLabel;
        int bugTotal;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            var patchButton = new Button(this);
            patchButton.SetText(Resource.String.patchButtonText);

            int bugsGone = Intent.Extras.GetInt("FirstData");
            
            bugTotal = Intent.Extras.GetInt("BugTotal");
            
            
            bugTotal = bugTotal - bugsGone;
            

            bugsLeftLabel = new TextView(this);
            bugsLeftLabel.Text = bugTotal.ToString();

            layout.AddView(patchButton);
            layout.AddView(bugsLeftLabel);

            patchButton.Click += (sender, e) =>
            {
                var myIntent = new Intent(this, typeof(FirstActivity));
                myIntent.PutExtra("BugMessage",  bugTotal + " little bugs left");
                myIntent.PutExtra("BugCount", bugTotal);
                SetResult(Result.Ok, myIntent);
                Finish();
            };

            SetContentView(layout);
        }
    }
}