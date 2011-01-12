using System;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls.Map;
using System.Collections.Generic;

namespace VMS.Views.Map_Control
{
    /// <summary>
    /// Interaction logic for MapsView.xaml
    /// </summary>
    public partial class MapsView : UserControl
    {
        DispatcherTimer zoomOutTimer = new DispatcherTimer();
        DispatcherTimer zoomInTimer = new DispatcherTimer();
        DispatcherTimer moveTimer = new DispatcherTimer();

        private bool providerChanged = false;
        private const int minZoomLevel = 3;
        private const int maxZoomLevel = 7;

        public MapsView()
        {
            InitializeComponent();
            LocationBox.SelectedIndex = 0;
            ProviderBox.SelectedIndex = 0;
            this.SetProvider();
            RadMap1.Center = (Location)LocationBox.SelectedItem;
            zoomOutTimer.Interval = TimeSpan.FromMilliseconds(150);
            zoomInTimer.Interval = TimeSpan.FromMilliseconds(150);
            moveTimer.Interval = TimeSpan.FromMilliseconds(800);
            zoomInTimer.Tick += new EventHandler(zoomInTimer_Tick);
            zoomOutTimer.Tick += new EventHandler(zoomOutTimer_Tick);
            moveTimer.Tick += new EventHandler(moveTimer_Tick);            
        }

        void moveTimer_Tick(object sender, EventArgs e)
        {
            this.moveTimer.Stop();
            this.ZoomIn();
        }

        void zoomInTimer_Tick(object sender, EventArgs e)
        {
            if (this.RadMap1.ZoomLevel < maxZoomLevel)
                this.RadMap1.ZoomLevel++;
            else
                this.zoomInTimer.Stop();
        }

        void zoomOutTimer_Tick(object sender, EventArgs e)
        {
            if (this.RadMap1.ZoomLevel > minZoomLevel)
                this.RadMap1.ZoomLevel--;
            else
            {
                this.zoomOutTimer.Stop();
                this.ZoomOutFinished();
            }
        }

        void ZoomOutFinished()
        {
            RadMap1.Center = (Location)LocationBox.SelectedItem;
            this.SetProvider();
            this.moveTimer.Start();
        }

        private void SetProvider()
        {
            if (providerChanged)
            {
                string providerName = (ProviderBox.SelectedItem as ListBoxItem).Content.ToString();
                
                MapMode providerMode = MapMode.Road;
                bool isLabelVisible = true;
                if (RadMap1.Provider != null)
                {
                    providerMode = RadMap1.Provider.Mode;
                    isLabelVisible = RadMap1.Provider.IsLabelVisible;
                }

                MapProviderBase provider;

                switch (providerName)
                {
                    case "OpenStreetMapProvider":
                        provider = new OpenStreetMapProvider(providerMode, isLabelVisible);
                        break;
                    default:
                        {
                            if (string.IsNullOrEmpty(BingMapHelper.VEKey))
                                return;

                            provider = new BingMapProvider(providerMode, isLabelVisible, BingMapHelper.VEKey);
                            break;
                        }
                }

				provider.IsTileCachingEnabled = true;
                this.RadMap1.Provider = provider;

                this.providerChanged = false;
            }
        }

        private void ZoomOut()
        {
            if (this.zoomOutTimer.IsEnabled || this.zoomInTimer.IsEnabled)
                return;

            this.zoomOutTimer.Start();
        }

        private void ZoomIn()
        {
            if (this.zoomOutTimer.IsEnabled || this.zoomInTimer.IsEnabled)
                return;

            this.zoomInTimer.Start();
        }

        private void LocationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ZoomOut();
        }

        private void ProviderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.providerChanged = true;
            this.ZoomOut();           
        }
    }
}
