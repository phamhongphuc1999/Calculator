using Calculator.ViewModel;
using System.Windows.Controls;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for CustomControlBar.xaml
    /// </summary>
    public partial class CustomControlBar : UserControl
    {
        private CustomControlBarViewModel customControlBarViewModel;

        public CustomControlBar()
        {
            InitializeComponent();
            customControlBarViewModel = new CustomControlBarViewModel();
            this.DataContext = customControlBarViewModel;
        }
    }
}
