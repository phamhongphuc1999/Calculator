using System.Windows;
using System.Windows.Controls;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for MainLeftSidebar.xaml
    /// </summary>
    public partial class MainLeftSidebar : UserControl
    {
        private static DependencyProperty PreviewMouseLeftButtonDownCommandProperty = DependencyProperty.Register(
            "PreviewMouseLeftButtonDownCommand", typeof(string), typeof(MainLeftSidebar));
        public string PreviewMouseLeftButtonDownCommand
        {
            get { return (string)GetValue(PreviewMouseLeftButtonDownCommandProperty); }
            set
            {
                SetValue(PreviewMouseLeftButtonDownCommandProperty, value);
            }
        }

        private static DependencyProperty SelectionChangedCommandProperty = DependencyProperty.Register(
            "SelectionChangedCommand", typeof(string), typeof(MainLeftSidebar));
        public string SelectionChangedCommand
        {
            get { return (string)GetValue(SelectionChangedCommandProperty); }
            set
            {
                SetValue(SelectionChangedCommandProperty, value);
            }
        }

        public MainLeftSidebar()
        {
            InitializeComponent();
        }
    }
}
