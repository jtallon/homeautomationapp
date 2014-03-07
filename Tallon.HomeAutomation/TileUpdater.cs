using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using Tallon.HomeAutomation.Helpers;

namespace Tallon.HomeAutomation
{
    public sealed class TileUpdater : IBackgroundTask 
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Canceled += OnCanceled;
            var defferal = taskInstance.GetDeferral();
            TileHelper.UpdateTile(HomeSensorHelper.GetSensorData());
            defferal.Complete(); 
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            //Do some logic when the task is cancelled....
        }
    }
}
