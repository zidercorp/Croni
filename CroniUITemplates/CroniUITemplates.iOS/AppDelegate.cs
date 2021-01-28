using Syncfusion.SfGauge.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.XForms.iOS.PopupLayout;
using Syncfusion.XForms.iOS.ProgressBar;
using Syncfusion.XForms.iOS.ParallaxView;
using Syncfusion.SfMaps.XForms.iOS;
using Syncfusion.SfRotator.XForms.iOS;
using Syncfusion.XForms.iOS.Cards;
using Syncfusion.XForms.iOS.Expander;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.XForms.iOS.TabView;
using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.XForms.iOS.ComboBox;
using  Syncfusion.XForms.iOS.Graphics;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;


namespace CroniUITemplates.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfGaugeRenderer.Init();
            SfChartRenderer.Init();
            SfPopupLayoutRenderer.Init();
            SfLinearProgressBarRenderer.Init();
            SfParallaxViewRenderer.Init();
            SfMapsRenderer.Init();
            SfSegmentedControlRenderer.Init();
            Core.Init();
            SfRotatorRenderer.Init();
            SfCardViewRenderer.Init();
            SfExpanderRenderer.Init();
            SfCheckBoxRenderer.Init();
            SfListViewRenderer.Init();
            SfRatingRenderer.Init();
            SfAvatarViewRenderer.Init();
            SfBadgeViewRenderer.Init();
            SfTabViewRenderer.Init();
            SfComboBoxRenderer.Init();
            SfCalendarRenderer.Init();
            SfGradientViewRenderer.Init();
            SfBorderRenderer.Init();
            SfButtonRenderer.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
