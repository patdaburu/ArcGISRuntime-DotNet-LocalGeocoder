using System;
using System.Collections.Generic;
using System.Dynamic;
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



        /// <summary>
        /// Initializes a new instance of the <see cref="GeocodeResult"/> class.
        /// </summary>
        /// <param name="esriResult">The ESRI geocode result.</param>
        public GeocodeResult(Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult esriResult)
        {
            this.Label = esriResult.Label;
            this.Score = esriResult.Score;

            // Construct an object containing the attributes that can be
            // used by the ObjectNode class.
            dynamic expando = new ExpandoObject();
            var attributes = expando as IDictionary<string, object>;
            foreach(string key in esriResult.Attributes.Keys)
            {
                attributes[key] = esriResult.Attributes[key];
            }
            this.Attributes = expando;

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

        ///// <summary>
        ///// Gets or sets the attributes.
        ///// </summary>
        ///// <value>
        ///// The attributes.
        ///// </value>
        ///// <seealso cref="Esri.ArcGISRuntime.Tasks.Geocoding.GeocodeResult.Attributes"/>
        //public IReadOnlyDictionary<string, object> Attributes { get; set; }

            public ExpandoObject Attributes { get; set; }

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
