using ArcGISRuntime_DotNet_LocalGeocoder.ViewModel;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArcGISRuntime_DotNet_LocalGeocoder.Commands
{
    /// <summary>
    /// Load map data.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class LoadMapCommand : ICommand
    {

        

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // This command can execute so long as we haven't yet populated
            // the mobile map package in the view model.
            return MapViewModel.Current.MobileMapPackage == null;
        }

        public void Execute(object parameter)
        {
            // We expect the parameter to be an ESRI MapView.
            var mapView = parameter as MapView;

            // Let the user find a mobile map package file.
            var ofd = new OpenFileDialog();
            ofd.Filter = "Mobile map package files (*.mmpk)|*.mmpk|All files (*.*)|*.*";
            // If the user opens the 
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    // Load the mobile map package.
                    var mobileMapPackage = Task.Run(async () =>
                    {
                        return await this.LoadMapAsync(ofd.FileName);
                    }).Result;
                    #region If there are no maps in the map package...
                    if (mobileMapPackage.Maps.Count == 0)
                    {
                        MessageBox.Show(
                            "The map package contains no maps.",
                            "No Maps",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }
                    #endregion

                    // If that worked, we can update the map view model with
                    // the new mobile map package.
                    MapViewModel.Current.MobileMapPackage = mobileMapPackage;

                    // Update the map view with the first map in the mobile map
                    // package.
                    var map = mobileMapPackage.Maps[0];
                    MapViewModel.Current.MapView.Map = map;

                    #region The tool doesn't need to execute again.
                    if (this.CanExecuteChanged != null)
                    {
                        this.CanExecuteChanged(this, new EventArgs());
                    }
                    #endregion
                    #region Report the success.
                    MessageBox.Show(
                        "The map is loaded.\r\nClick to perform reverse geocodes.",
                        "Good to Go",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                    #endregion
                    
                }
                catch (Exception ex)
                {
                    #region Let's tell the user what happened...
                    MessageBox.Show(
                        string.Format("Can't open '{0}': {1}", ofd.FileName, ex.Message),
                        ex.GetType().Name,
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    throw;
                    #endregion
                }
            }
            
        }

        private async Task<MobileMapPackage> LoadMapAsync(string pathToMmpk)
        {
            //Create the object into which we'll load the data.
            var mobileMapPackage = await MobileMapPackage.OpenAsync(pathToMmpk);
            return mobileMapPackage;
        }
    }
}
