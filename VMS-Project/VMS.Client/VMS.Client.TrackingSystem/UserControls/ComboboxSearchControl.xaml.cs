using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VMS.Client.TrackingSystem.UserControls
{
	/// <summary>
	/// Interaction logic for ComboboxSearchControl.xaml
	/// </summary>
	public partial class ComboboxSearchControl
	{
		public ComboboxSearchControl()
		{
			this.InitializeComponent();
		}

        private void ComboBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ComboBox cbx = ((ComboBox)sender);

            if ((bool)e.NewValue && cbx.Text == (string)cbx.ToolTip)
            {
                cbx.Text = "";
                cbx.Foreground = Brushes.Black;
            }
            else if (cbx.Text == "")
            {
                cbx.Text = (string)cbx.ToolTip;
                cbx.Foreground = Brushes.LightGray;
            }
        }
        
	}
}