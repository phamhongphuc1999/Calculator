using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for MainLeftListView.xaml
    /// </summary>
    public partial class MainLeftListView : UserControl
    {
        private static DependencyProperty PreviewMouseLeftButtonDownCommandProperty = DependencyProperty.Register(
            "PreviewMouseLeftButtonDownCommand", typeof(ICommand), typeof(MainLeftListView));

        public ICommand PreviewMouseLeftButtonDownCommand
        {
            get { return (ICommand)GetValue(PreviewMouseLeftButtonDownCommandProperty); }
            set
            {
                SetValue(PreviewMouseLeftButtonDownCommandProperty, value);
            }
        }

        private static DependencyProperty SelectionChangedCommandProperty = DependencyProperty.Register(
            "SelectionChangedCommand", typeof(ICommand), typeof(MainLeftListView));

        public ICommand SelectionChangedCommand
        {
            get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
            set
            {
                SetValue(SelectionChangedCommandProperty, value);
            }
        }

        public MainLeftListView()
        {
            InitializeComponent();
        }
    }
}
