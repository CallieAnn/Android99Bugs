using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace _99Bugs
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class FirstActivity : AppCompatActivity
    {
        TextView bugLabel;
        int bugTotal = 99;
        const string MESSAGE_EXTRA = "BugMessage";
        const string TOTAL_AFTER = "BugCount";
        const string CLICKED = "WhichClicked";
        const string TOTAL_BEFORE = "BugTotal";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            var takeAwayButton = new Button(this);
            takeAwayButton.SetText(Resource.String.takeAwayButtonText);

            var takeAwayTwoButton = new Button(this);
            takeAwayTwoButton.SetText(Resource.String.takeAwayTwoButtonText);

            bugLabel = new TextView(this);
            bugLabel.Text = "Squash the bugs!";
            
            layout.AddView(takeAwayButton);
            layout.AddView(takeAwayTwoButton);
            layout.AddView(bugLabel);
            SetContentView(layout);

            //user clicks take one down
            takeAwayButton.Click += (sender, e) =>
            {
                MakeClickIntent(1, 0);
            };

            //user clicks take 2 down
            takeAwayTwoButton.Click += (sender, e) =>
            {
                MakeClickIntent(2, 1);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(resultCode == Result.Ok)
            {
                //get the updated total number of bugs left and display them
                //bugLabel.Text = data.GetStringExtra(MESSAGE_EXTRA);
                bugTotal = data.GetIntExtra(TOTAL_AFTER, -1);
                bugLabel.Text = bugTotal + " little bugs left";
            }
        }

        //number that was clicked is passed to second activity
        protected void MakeClickIntent(int numberClicked, int activityIndex)
        {
            var second = new Intent(this, typeof(SecondActivity));
            second.PutExtra(CLICKED, numberClicked);
           
            //total remaining bugs is passed to second activity
            second.PutExtra(TOTAL_BEFORE, bugTotal);

            StartActivityForResult(second, activityIndex);
        }


       
    }
}