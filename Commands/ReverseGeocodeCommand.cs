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
    /// <summary>
    /// Performs a reverse geocode.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class ReverseGeocodeCommand : ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            // We can execute so long as there's a mobile map package loaded.
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

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
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

            // We'll need access to the map view model.
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
