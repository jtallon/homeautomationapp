// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Tallon.HomeAutomation.Helpers;

namespace Tallon.HomeAutomation.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string TaskName = "Home Automation - Data Task";
        private const string TaskEntry = "Tallon.HomeAutomation.TileUpdater";

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var data = HomeSensorHelper.GetSensorData();
            TileHelper.UpdateTile(data);
            Temperature.Text = data.Temperature.ToString();
            var result = await BackgroundExecutionManager.RequestAccessAsync();
            if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks.Where(task => task.Value.Name == TaskName))
                {
                    task.Value.Unregister(true);
                }

                RegisterMaintenanceBackgroundTask();
            }

        }


        private static void RegisterMaintenanceBackgroundTask()
        {
            var builder = new BackgroundTaskBuilder {Name = TaskName, TaskEntryPoint = TaskEntry};
            IBackgroundTrigger trigger = new TimeTrigger(15, false);
            builder.SetTrigger(trigger);
            IBackgroundCondition condition =
                new SystemCondition(SystemConditionType.InternetAvailable);
            builder.AddCondition(condition); 
            IBackgroundTaskRegistration task = builder.Register();
        }
    }
}
