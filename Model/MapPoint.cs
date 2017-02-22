using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGISRuntime_DotNet_LocalGeocoder.Model
{
    /// <summary>
    /// Contains information pertaining to a location.
    /// </summary>
    /// <remarks>
    /// We use this object to hold information from the ESRI
    /// <see cref="Esri.ArcGISRuntime.Geometry.MapPoint"/> object
    /// to narrow down the information displayed by the <see cref="ObjectNode"/>l
    /// </remarks>
    public class MapPoint
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the srid.
        /// </summary>
        /// <value>
        /// The srid.
        /// </value>
        public int SRID { get; set; }
    }
}
