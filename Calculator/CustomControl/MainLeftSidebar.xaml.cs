using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for MainLeftSidebar.xaml
    /// </summary>
    public partial class MainLeftSidebar : UserControl
    {
        private static DependencyProperty PreviewMouseLeftButtonDownCommandProperty = DependencyProperty.Register(
            "PreviewMouseLeftButtonDownCommand", typeof(ICommand), typeof(MainLeftSidebar));
        public ICommand PreviewMouseLeftButtonDownCommand
        {
            get { return (ICommand)GetValue(PreviewMouseLeftButtonDownCommandProperty); }
            set
            {
                SetValue(PreviewMouseLeftButtonDownCommandProperty, value);
            }
        }

        private static DependencyProperty SelectionChangedCommandProperty = DependencyProperty.Register(
            "SelectionChangedCommand", typeof(ICommand), typeof(MainLeftSidebar));
        public ICommand SelectionChangedCommand
        {
            get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
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
