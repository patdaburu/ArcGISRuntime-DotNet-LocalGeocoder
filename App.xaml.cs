using ArcGISRuntime_DotNet_LocalGeocoder.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ArcGISRuntime_DotNet_LocalGeocoder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create the main window.
            var mainWindow = new MainWindow();
            // When the main window loads...
            mainWindow.Loaded += (sender, args) =>
              {
                  // ...update the view model.
                  MapViewModel.Current.MapView = mainWindow.mapView;
              };
            // Let's get started.
            mainWindow.Show();
        }
    }
}
