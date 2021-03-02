using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for MainLeftItem.xaml
    /// </summary>
    public partial class MainLeftItem : UserControl
    {
        private static DependencyProperty CustomTitleProperty = DependencyProperty.Register(
            "CustomTitle", typeof(string), typeof(MainLeftItem));
        public string CustomTitle
        {
            get { return (string)GetValue(CustomTitleProperty); }
            set
            {
                SetValue(CustomTitleProperty, value);
            }
        }

        private static DependencyProperty CustomIconProperty = DependencyProperty.Register(
            "CustomIcon", typeof(string), typeof(MainLeftItem));
        public string CustomIcon
        {
            get { return (string)GetValue(CustomIconProperty); }
            set
            {
                SetValue(CustomIconProperty, value);
            }
        }

        private static DependencyProperty CustomWidthProperty = DependencyProperty.Register(
            "CustomWidth", typeof(int), typeof(MainLeftItem));
        public int CustomWidth
        {
            get { return (int)GetValue(CustomWidthProperty); }
            set
            {
                SetValue(CustomWidthProperty, value);
            }
        }

        private static DependencyProperty CustomClickCommandProperty = DependencyProperty.Register(
            "CustomClickCommand", typeof(ICommand), typeof(MainLeftItem));
        public ICommand CustomClickCommand
        {
            get { return (ICommand)GetValue(CustomClickCommandProperty); }
            set
            {
                SetValue(CustomClickCommandProperty, value);
            }
        }

        public MainLeftItem()
        {
            InitializeComponent();
            CustomIcon = "Calculator";
            CustomTitle = "Standard";
            CustomWidth = 165;
        }
    }
}
