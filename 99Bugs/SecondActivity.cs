using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace _99Bugs
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : AppCompatActivity
    {
        TextView bugsLeftLabel;
        int bugTotal;
        const string TOTAL_AFTER = "BugCount";
        const string CLICKED = "WhichClicked";
        const string TOTAL_BEFORE = "BugTotal";

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            var patchButton = new Button(this);
            patchButton.SetText(Resource.String.patchButtonText);

            //the number of bugs that were squashed with the click from first activity
            int bugsGone = Intent.Extras.GetInt(CLICKED);
            
            //Total bugs before subtracting the squashed ones
            bugTotal = Intent.Extras.GetInt(TOTAL_BEFORE);
            
            //updated total number bugs
            bugTotal = bugTotal - bugsGone;
            

            bugsLeftLabel = new TextView(this);
            bugsLeftLabel.Text = bugTotal.ToString();

            layout.AddView(patchButton);
            layout.AddView(bugsLeftLabel);

            patchButton.Click += (sender, e) =>
            {
                var myIntent = new Intent(this, typeof(FirstActivity));
                //correct number of bugs left passed to 1st activity
                myIntent.PutExtra(TOTAL_AFTER, bugTotal);
                SetResult(Result.Ok, myIntent);
                Finish();
            };

            SetContentView(layout);
        }
    }
}