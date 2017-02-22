using ArcGISRuntime_DotNet_LocalGeocoder.Model;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArcGISRuntime_DotNet_LocalGeocoder.ViewModel
{
    /// <summary>
    /// Properties pertaining to the current map.
    /// </summary>
    public class MapViewModel
    {

        #region Static Instance

        /// <summary>
        /// Gets the current <see cref="MapViewModel"/>.
        /// </summary>
        /// <value>
        /// The current <see cref="MapViewModel"/>.
        /// </value>
        public static MapViewModel Current
        {
            get
            {
                return Application.Current.Resources["MapViewModel"]
                    as MapViewModel;
            }
        }

        #endregion

        /// <summary>
        /// The current set of reverse geocode results.
        /// </summary>
        private ObservableCollection<ObjectNode> reverseGeocodeResults =
            new ObservableCollection<ObjectNode>();

        /// <summary>
        /// Gets the latest reverse geocode results.
        /// </summary>
        /// <value>
        /// The reverse geocode results.
        /// </value>
        public ObservableCollection<ObjectNode> ReverseGeocodeResults
        {
            get
            {
                return this.reverseGeocodeResults;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="MapView"/>.
        /// </summary>
        /// <value>
        /// The <see cref="MapView"/>.
        /// </value>
        public MapView MapView { get; set; }


        /// <summary>
        /// Gets or sets the loaded mobile map package.
        /// </summary>
        /// <value>
        /// The mobile map package.
        /// </value>
        public MobileMapPackage MobileMapPackage { get; set; }

        ///// <summary>
        ///// Gets or sets the ERSI <see cref="Locator"/> from the loaded
        ///// <see cref="MobileMapPackage"/>
        ///// </summary>
        ///// <value>
        ///// The current locator.
        ///// </value>
        ///// <seealso cref="MobileMapPackage"/>
        //public LocatorTask Locator
        //{
        //    get
        //    {
        //        return this.MobileMapPackage?.LocatorTask;
        //    }
        //}
    }
}
