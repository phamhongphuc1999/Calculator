using Calculator.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for MainLeftSideBar.xaml
    /// </summary>
    public partial class MainLeftSideBar : UserControl
    {
        public MainLeftViewModel mainLeftViewModel { get; set; }

        private static DependencyProperty StandardClickProperty = DependencyProperty.Register(
            "StandardClick", typeof(ICommand), typeof(MainLeftSideBar));
        public ICommand StandardClick
        {
            get { return (ICommand)GetValue(StandardClickProperty); }
            set
            {
                SetValue(StandardClickProperty, value);
            }
        }

        public MainLeftSideBar()
        {
            InitializeComponent();
            mainLeftViewModel = new MainLeftViewModel();
            this.DataContext = mainLeftViewModel;
        }
    }
}
