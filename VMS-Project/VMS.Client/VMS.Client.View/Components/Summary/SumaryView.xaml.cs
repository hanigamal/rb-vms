using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using VMS.Client.View.Component.Library.LayoutToLayout;
using VMS.Client.View.UserControls;

namespace VMS.Client.View.Component.Summary
{
    /// <summary>
    /// Interaction logic for POSContentView.xaml
    /// </summary>
    public partial class SumaryView : UserControl
    {
        #region Constructors

        public SumaryView()
        {
            InitializeComponent();
            this.LoadControl();
        }

        #endregion

        #region Properties

        private ArrayList[] _targetsArr = new ArrayList[_numGroups];
        private ArrayList[] _hostsArr = new ArrayList[_numGroups];
        private const int _numGroups = 1;
        private bool[] _flagArr = new bool[_numGroups];
        private int[] _gridSizeArr = new int[_numGroups];
        private int[] _numItemsArr = { 4 };
        private int _currentIndex = 0;
        private Grid[,] _gridChildrenArr = new Grid[_numGroups, 2];
        private Canvas[] _canvasArr = new Canvas[_numGroups];

        #endregion

        #region Events

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton bt = sender as ToggleButton;
            if (bt.IsChecked == false)
            {
                LarToMed();
                return;
            }

            if (_flagArr[_currentIndex])
                ChangeItem(bt);
            else
                MedToLar(bt);
        }

        #endregion

        #region Methods

        private void LoadControl()
        {
            UserControl[] userCtrls1 = new UserControl[_numItemsArr[0]];
            LoadGroup1(userCtrls1);

            for (int i = 0; i < _numGroups; i++)
            {
                _gridSizeArr[i] = GetGridSize(i);
                InitGrid(i);
                _targetsArr[i] = new ArrayList();
                _hostsArr[i] = new ArrayList();
                _flagArr[i] = false;
            }

            LoadControl(0, userCtrls1);

            for (int i = 0; i < _numGroups; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MainGrid.Children.Add(_gridChildrenArr[i, j]);
                }
                MainGrid.Children.Add(_canvasArr[i]);
            }

            _gridChildrenArr[0, 0].Visibility = Visibility.Visible;
            _gridChildrenArr[0, 1].Visibility = Visibility.Visible;
            _canvasArr[0].Visibility = Visibility.Visible;
        }

        private void LoadGroup1(UserControl[] userCtrls)
        {
            userCtrls[0] = new FleetView();
            userCtrls[1] = new DriverView();
            userCtrls[2] = new VehicleView();
            userCtrls[3] = new DetailsView();
            
        }

        private void LoadControl(int numItems, UserControl[] userCtrls)
        {
            for (int i = 0; i < _numItemsArr[numItems]; i++)
            {
                LayoutToLayoutTarget target = new LayoutToLayoutTarget();
                _targetsArr[numItems].Add(target);
                target.Margin = new Thickness(2);
                target.BorderThickness = new Thickness(0);
                Grid.SetRow(target, i / _gridSizeArr[numItems]);
                Grid.SetColumn(target, i % _gridSizeArr[numItems]);
                _gridChildrenArr[numItems, 0].Children.Add(target);

                LayoutToLayoutHost host = new LayoutToLayoutHost();
                _hostsArr[numItems].Add(host);
                host.BorderThickness = new Thickness(0);   
                UserControl userCtrl = new ContainerViewUserControl();
                ((ContainerViewUserControl)userCtrl).grdContent.Children.Add(userCtrls[i]);
                ((ContainerViewUserControl)userCtrl).Minimize.Click += new RoutedEventHandler(Minimize_Click);
                host.Child = userCtrl;
                if (i == 0)
                {
                    ((ContainerViewUserControl)userCtrl).txtName.Text = "Đội Xe";
                }
                else if (i == 1)
                {
                    ((ContainerViewUserControl)userCtrl).txtName.Text = "Tài Xế";
                }
                else if (i == 2)
                {
                    ((ContainerViewUserControl)userCtrl).txtName.Text = "Xe";
                }
                else if (i == 3)
                {
                    ((ContainerViewUserControl)userCtrl).txtName.Text = "Thông tin";
                }
                Canvas.SetLeft(host, 0);
                Canvas.SetRight(host, 0);
                _canvasArr[numItems].Children.Add(host);

                host.BindToTarget(target);
            }
        }

        private int GetGridSize(int numItems)
        {
            int i = 1;
            while (i * i < _numItemsArr[numItems])
            {
                i++;
            }
            return i;
        }

        private void InitGrid(int numItems)
        {
            _gridChildrenArr[numItems, 0] = new Grid();
            _gridChildrenArr[numItems, 0].HorizontalAlignment = HorizontalAlignment.Stretch;
            _gridChildrenArr[numItems, 0].VerticalAlignment = VerticalAlignment.Stretch;

            _gridChildrenArr[numItems, 1] = new Grid();
            _gridChildrenArr[numItems, 1].HorizontalAlignment = HorizontalAlignment.Stretch;
            _gridChildrenArr[numItems, 1].VerticalAlignment = VerticalAlignment.Stretch;

            for (int i = 0; i < _gridSizeArr[numItems]; i++)
            {
                _gridChildrenArr[numItems, 0].ColumnDefinitions.Add(new ColumnDefinition());
                _gridChildrenArr[numItems, 0].RowDefinitions.Add(new RowDefinition());
            }

            ColumnDefinition cd1 = new ColumnDefinition();
            cd1.Width = new GridLength(0.7, GridUnitType.Star);
            _gridChildrenArr[numItems, 1].ColumnDefinitions.Add(cd1);
            ColumnDefinition cd2 = new ColumnDefinition();
            cd2.Width = new GridLength(0.3, GridUnitType.Star);
            _gridChildrenArr[numItems, 1].ColumnDefinitions.Add(cd2);
            for (int i = 0; i < _numItemsArr[numItems] - 1; i++)
            {
                _gridChildrenArr[numItems, 1].RowDefinitions.Add(new RowDefinition());
            }
            _gridChildrenArr[numItems, 0].Visibility = Visibility.Collapsed;
            _gridChildrenArr[numItems, 1].Visibility = Visibility.Collapsed;

            _canvasArr[numItems] = new Canvas();
            _canvasArr[0].Visibility = Visibility.Collapsed;
        }

        private void LarToMed()
        {
            _flagArr[_currentIndex] = false;
            _gridChildrenArr[_currentIndex, 1].Children.Clear();
            for (int i = 0; i < _numItemsArr[_currentIndex]; i++)
            {
                LayoutToLayoutTarget target = (_targetsArr[_currentIndex])[i] as LayoutToLayoutTarget;
                LayoutToLayoutHost host = (_hostsArr[_currentIndex])[i] as LayoutToLayoutHost;
                host.BeginAnimating(false);
                Grid.SetRow(target, i / _gridSizeArr[_currentIndex]);
                Grid.SetColumn(target, i % _gridSizeArr[_currentIndex]);
                Grid.SetRowSpan(target, 1);
                Grid.SetColumnSpan(target, 1);
                _gridChildrenArr[_currentIndex, 0].Children.Add(target);
            }
        }

        private void ChangeItem(ToggleButton bt)
        {
            int count = 0;
            for (int i = 0; i < _numItemsArr[_currentIndex]; i++)
            {
                LayoutToLayoutTarget target = (_targetsArr[_currentIndex])[i] as LayoutToLayoutTarget;
                LayoutToLayoutHost host = (_hostsArr[_currentIndex])[i] as LayoutToLayoutHost;
                host.BeginAnimating(false);
                ContainerViewUserControl hostcv = host.Child as ContainerViewUserControl;
                ToggleButton hostBt = hostcv.Minimize;
                if (hostBt.Equals(bt))
                {
                    Grid.SetRow(target, 0);
                    Grid.SetColumn(target, 0);
                    Grid.SetRowSpan(target, _numItemsArr[_currentIndex] - 1);
                    Grid.SetColumnSpan(target, 1);
                    //hostBt.IsChecked = true;
                }
                else
                {
                    Grid.SetRow(target, count);
                    Grid.SetColumn(target, 1);
                    Grid.SetRowSpan(target, 1);
                    Grid.SetColumnSpan(target, 1);
                    hostBt.IsChecked = false;
                    count++;
                }
            }
        }

        private void MedToLar(ToggleButton bt)
        {
            _flagArr[_currentIndex] = true;
            _gridChildrenArr[_currentIndex, 0].Children.Clear();
            int count = 0;
            for (int i = 0; i < _numItemsArr[_currentIndex]; i++)
            {
                LayoutToLayoutTarget target = (_targetsArr[_currentIndex])[i] as LayoutToLayoutTarget;
                LayoutToLayoutHost host = (_hostsArr[_currentIndex])[i] as LayoutToLayoutHost;
                host.BeginAnimating(false);
                ContainerViewUserControl hostcv = host.Child as ContainerViewUserControl;
                ToggleButton hostBt = hostcv.Minimize;
                if (hostBt.Equals(bt))
                {
                    Grid.SetRow(target, 0);
                    Grid.SetColumn(target, 0);
                    Grid.SetRowSpan(target, _numItemsArr[_currentIndex] - 1);
                    Grid.SetColumnSpan(target, 1);
                }
                else
                {
                    Grid.SetRow(target, count);
                    Grid.SetColumn(target, 1);
                    count++;
                }
                _gridChildrenArr[_currentIndex, 1].Children.Add(target);
            }
        }

        #endregion
    }
}
