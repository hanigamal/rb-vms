using System.Windows;
using Telerik.Windows.Controls.Charting;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
#if WPF
using ComboBoxSelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#else
using ComboBoxSelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangeEventArgs;
#endif

namespace VMS.Views.Report
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class DriverReport : UserControl
    {
        public DriverReport()
        {
            InitializeComponent();

        }
    }
}
