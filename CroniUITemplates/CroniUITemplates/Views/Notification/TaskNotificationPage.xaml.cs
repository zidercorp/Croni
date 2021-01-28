using CroniUITemplates.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CroniUITemplates.Views.Notification
{
    /// <summary>
    /// Page to display Task Notifications list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskNotificationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskNotificationPage" /> class.
        /// </summary>
        public TaskNotificationPage()
        {
            InitializeComponent();
            this.BindingContext = TaskNotificationDataService.Instance.TaskNotificationViewModel;
        }

    }
}