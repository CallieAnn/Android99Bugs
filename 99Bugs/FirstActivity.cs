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

            takeAwayButton.Click += (sender, e) =>
            {
                MakeClickIntent(1, 0);
            };

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
                bugLabel.Text = data.GetStringExtra("BugMessage");
                bugTotal = data.GetIntExtra("BugCount", -1);
            }
        }

        protected void MakeClickIntent(int numberClicked, int activityIndex)
        {
            var second = new Intent(this, typeof(SecondActivity));
            second.PutExtra("FirstData", numberClicked);
            if (bugTotal != -1)
            {
                second.PutExtra("BugTotal", bugTotal);
            }

            StartActivityForResult(second, activityIndex);
        }


       
    }
}