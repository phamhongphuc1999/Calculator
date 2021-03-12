using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for CoreConverter.xaml
    /// </summary>
    public partial class CoreConverter : UserControl
    {
        private static DependencyProperty ClickNumberCommandProperty = DependencyProperty.Register(
            "ClickNumberCommand", typeof(ICommand), typeof(CoreConverter));

        public ICommand ClickNumberCommand
        {
            get { return (ICommand)GetValue(ClickNumberCommandProperty); }
            set
            {
                SetValue(ClickNumberCommandProperty, value);
            }
        }

        private static DependencyProperty DecimalCommandProperty = DependencyProperty.Register(
            "DecimalCommand", typeof(ICommand), typeof(CoreConverter));

        public ICommand DecimalCommand
        {
            get { return (ICommand)GetValue(DecimalCommandProperty); }
            set
            {
                SetValue(DecimalCommandProperty, value);
            }
        }

        private static DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
            "DeleteCommand", typeof(ICommand), typeof(CoreConverter));

        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set
            {
                SetValue(DeleteCommandProperty, value);
            }
        }

        private static DependencyProperty CECommandProperty = DependencyProperty.Register(
            "CECommand", typeof(ICommand), typeof(CoreConverter));

        public ICommand CECommand
        {
            get { return (ICommand)GetValue(CECommandProperty); }
            set
            {
                SetValue(CECommandProperty, value);
            }
        }

        public CoreConverter()
        {
            InitializeComponent();
        }
    }
}
