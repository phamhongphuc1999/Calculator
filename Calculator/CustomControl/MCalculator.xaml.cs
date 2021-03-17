using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for MCalculator.xaml
    /// </summary>
    public partial class MCalculator : UserControl
    {
        private static DependencyProperty MCCommandProperty = DependencyProperty.Register(
            "MCCommand", typeof(ICommand), typeof(MCalculator));

        public ICommand MCCommand
        {
            get { return (ICommand)GetValue(MCCommandProperty); }
            set
            {
                SetValue(MCCommandProperty, value);
            }
        }

        private static DependencyProperty MRCommandProperty = DependencyProperty.Register(
            "MRCommand", typeof(ICommand), typeof(MCalculator));

        public ICommand MRCommand
        {
            get { return (ICommand)GetValue(MRCommandProperty); }
            set
            {
                SetValue(MRCommandProperty, value);
            }
        }

        private static DependencyProperty MPlusCommandProperty = DependencyProperty.Register(
            "MPlusCommand", typeof(ICommand), typeof(MCalculator));

        public ICommand MPlusCommand
        {
            get { return (ICommand)GetValue(MPlusCommandProperty); }
            set
            {
                SetValue(MPlusCommandProperty, value);
            }
        }

        private static DependencyProperty MSubtractCommandProperty = DependencyProperty.Register(
            "MSubtractCommand", typeof(ICommand), typeof(MCalculator));

        public ICommand MSubtractCommand
        {
            get { return (ICommand)GetValue(MSubtractCommandProperty); }
            set
            {
                SetValue(MSubtractCommandProperty, value);
            }
        }

        private static DependencyProperty MSCommandProperty = DependencyProperty.Register(
            "MSCommand", typeof(ICommand), typeof(MCalculator));

        public ICommand MSCommand
        {
            get { return (ICommand)GetValue(MSCommandProperty); }
            set
            {
                SetValue(MSCommandProperty, value);
            }
        }

        public MCalculator()
        {
            InitializeComponent();
        }
    }
}
