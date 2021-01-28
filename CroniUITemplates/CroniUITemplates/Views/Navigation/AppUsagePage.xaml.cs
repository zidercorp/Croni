using CroniUITemplates.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CroniUITemplates.Views.Navigation
{
    /// <summary>
    /// Page to display app usage list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUsagePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppUsagePage" /> class.
        /// </summary>
        public AppUsagePage()
        {
            InitializeComponent();
            this.BindingContext = AppUsageDataService.Instance.AppUsageViewModel;
        }
    }
}