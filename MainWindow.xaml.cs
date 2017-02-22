using ArcGISRuntime_DotNet_LocalGeocoder.Commands;
using ArcGISRuntime_DotNet_LocalGeocoder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArcGISRuntime_DotNet_LocalGeocoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the reverse geocode command.
        /// </summary>
        /// <value>
        /// The reverse geocode command.
        /// </value>
        private ReverseGeocodeCommand ReverseGeocodeCommand
        {
            get
            {
                return Application.Current.Resources["ReverseGeocodeCommand"]
                   as ReverseGeocodeCommand;
            }
        }

        private void mapView_GeoViewTapped(object sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            var reverseGeocodeCommand = this.ReverseGeocodeCommand;
            if (reverseGeocodeCommand.CanExecute(MapViewModel.Current))
            {
                reverseGeocodeCommand.Execute(e.Location);
            }
        }
    }
}
