using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for CoreCalculator.xaml
    /// </summary>
    public partial class CoreCalculator : UserControl
    {
        private static DependencyProperty ClickNumberCommandProperty = DependencyProperty.Register(
            "ClickNumberCommand", typeof(ICommand), typeof(CoreCalculator));

        public ICommand ClickNumberCommand
        {
            get { return (ICommand)GetValue(ClickNumberCommandProperty); }
            set
            {
                SetValue(ClickNumberCommandProperty, value);
            }
        }

        private static DependencyProperty TransformSignCommandProperty = DependencyProperty.Register(
            "TransformSignCommand", typeof(ICommand), typeof(CoreCalculator));

        public ICommand TransformSignCommand
        {
            get { return (ICommand)GetValue(TransformSignCommandProperty); }
            set
            {
                SetValue(TransformSignCommandProperty, value);
            }
        }

        private static DependencyProperty DecimalCommandProperty = DependencyProperty.Register(
            "DecimalCommand", typeof(ICommand), typeof(CoreCalculator));
        
        public ICommand DecimalCommand
        {
            get { return (ICommand)GetValue(DecimalCommandProperty); }
            set
            {
                SetValue(DecimalCommandProperty, value);
            }
        }

        public CoreCalculator()
        {
            InitializeComponent();
        }
    }
}
