using ArcGISRuntime_DotNet_LocalGeocoder.Model;
using ArcGISRuntime_DotNet_LocalGeocoder.ViewModel;
using Esri.ArcGISRuntime.Geometry;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArcGISRuntime_DotNet_LocalGeocoder.Commands
{
    public class ReverseGeocodeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var mainViewModel = parameter as MapViewModel;
            if(mainViewModel == null)
            {
                return false;
            }
            else
            {
                return mainViewModel.MobileMapPackage != null;
            }
        }

        public void Execute(object parameter)
        {
            // The parameter should be an ESRI MapPoint.
            var location = parameter as Esri.ArcGISRuntime.Geometry.MapPoint;
            #region Sanity Check
            if(location == null)
            {
                MessageBox.Show(
                    "A reverse geocode requires a location.",
                    "No Location",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            #endregion

            var mapViewModel = MapViewModel.Current;

            // Clear the list of reverse geocodes.
            mapViewModel.ReverseGeocodeResults.Clear();

            // We need the ESRI locator.
            var locatorTask = MapViewModel.Current.MobileMapPackage.LocatorTask;

            // let's try a reverse geocode...
            var results = Task.Run(async () =>
            {
                return await locatorTask.ReverseGeocodeAsync(location);
            }).Result;

            // Examine each of the results.
            foreach(var result in results)
            {

                /**
                 * To those who want to troubleshoot... place a breakpoint
                 * here to examine the result returned by the LocatorTask.
                 */
                Console.WriteLine($"Label={result.Label}");
                Console.WriteLine($"Score={result.Score}");

                // Construct a label.
                string label = string.IsNullOrWhiteSpace(result.Label) ?
                    "The label came back as an empty string.  Why is that?" : result.Label;
                // Create an instance of our own GeocodeResult to hold the
                // values from ESRI's GeocodeResult.
                Model.GeocodeResult resultNode = new Model.GeocodeResult(result);
                // Place the reverse geocode results into the collection so
                // they may be viewed.
                mapViewModel.ReverseGeocodeResults.Add(
                    new ObjectNode($"Label={label}", resultNode));
            }


            

        }
    }
}
