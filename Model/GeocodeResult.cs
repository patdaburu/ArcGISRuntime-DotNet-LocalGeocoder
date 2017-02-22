using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGISRuntime_DotNet_LocalGeocoder.Model
{
    /// <summary>
    /// Contains information about a geocode result.
    /// </summary>
    /// <remarks>
    /// We use this object to hold information from the ESRI
    /// <see cref="Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult"/> object
    /// to narrow down the information displayed by the <see cref="ObjectNode"/>l
    /// </remarks>
    public class GeocodeResult
    {




        public GeocodeResult(Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult esriResult)
        {
            this.Label = esriResult.Label;
            this.Score = esriResult.Score;
            this.Attributes = esriResult.Attributes;
            this.DisplayLocation = new Model.MapPoint
            {
                X = esriResult.DisplayLocation.X,
                Y = esriResult.DisplayLocation.Y,
                SRID = esriResult.DisplayLocation.SpatialReference.Wkid
            };
        }



        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        /// <seealso cref="Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult.Label"/>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        /// <seealso cref="Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult.Score"/>
        public double Score { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        /// <seealso cref="Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult.Attributes"/>
        public IReadOnlyDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the display location.
        /// </summary>
        /// <value>
        /// The display location.
        /// </value>
        /// <seealso cref="Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult.DisplayLocation"/>
        public MapPoint DisplayLocation { get; set; }
    }
}
