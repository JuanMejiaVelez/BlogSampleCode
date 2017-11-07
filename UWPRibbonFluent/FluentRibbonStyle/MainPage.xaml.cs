using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FluentRibbonStyle
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      // Change the colors for the TitleBar
      var titleBar = ApplicationView.GetForCurrentView().TitleBar;
      if (titleBar != null)
      {
        // Get the resoueces values from the current Page Resources
        var bgColor = (Color)Resources["TitleBarBackgroundColor"];
        var fgColor = (Color)Resources["TitleBarForegroundColor"];

        titleBar.BackgroundColor = Colors.Transparent;// bgColor;
        titleBar.InactiveBackgroundColor = Colors.Transparent;
        titleBar.ButtonBackgroundColor = Colors.Transparent;// bgColor;
        titleBar.ForegroundColor = fgColor;
        titleBar.ButtonForegroundColor = fgColor;
      }

      // Extend the application content to cover the TitleBar provided by Windows
      var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
      // Set the TitleBar height
      coreTitleBar.LayoutMetricsChanged += 
        (CoreApplicationViewTitleBar sender, object args) => 
                        TitleBarPanel.Height = sender.Height;

      coreTitleBar.ExtendViewIntoTitleBar = true;
      // Set the area that respond to dragging operations in the window
      Window.Current.SetTitleBar(TitleBarPanel);
    }
  }
}
