using AndroidX.Work;

namespace Net6Notifications
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var request = new OneTimeWorkRequest.Builder(typeof(ReminderWorker))
                .SetInitialDelay(TimeSpan.FromSeconds(5))
                .Build();

            WorkManager.GetInstance(this).Enqueue(request);
            Toast.MakeText(this, "Scheduled notification", ToastLength.Short).Show();
        }
    }
}