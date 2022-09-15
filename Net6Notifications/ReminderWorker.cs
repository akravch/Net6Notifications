using Android.Content;
using AndroidX.Core.App;
using AndroidX.Work;

namespace Net6Notifications;

public class ReminderWorker : Worker
{
    public ReminderWorker(Context context, WorkerParameters workerParams) : base(context, workerParams)
    {
    }

    public override Result DoWork()
    {
        NotificationManagerCompat.From(ApplicationContext).Notify(1, CreateNotification(ApplicationContext));
        return Result.InvokeSuccess();
    }

    private static Notification CreateNotification(Context context)
    {
        var intent = new Intent(context, typeof(MainActivity)).AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
        var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.Immutable);

        return new NotificationCompat.Builder(context, "test_default_channel")
            .SetContentTitle("Title")
            .SetContentText("Text")
            .SetSmallIcon(Resource.Mipmap.ic_launcher)
            .SetContentIntent(pendingIntent)
            .Build();
    }
}