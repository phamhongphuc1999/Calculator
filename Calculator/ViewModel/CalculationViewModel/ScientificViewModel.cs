using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel.CalculationViewModel
{
    public class ScientificViewModel: CalculationViewModel
    {
        public ICommand MouseDownWindowCommand { get; set; }
        public ICommand TrigonometryButtonCommand { get; set; }
        public ICommand FunctionButtonCommand { get; set; }

        private Visibility trigonometryVisibility;
        public Visibility TrigonometryVisibility
        {
            get { return trigonometryVisibility; }
            set
            {
                trigonometryVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility functionVisibility;
        public Visibility FunctionVisibility
        {
            get { return functionVisibility; }
            set
            {
                functionVisibility = value;
                OnPropertyChanged();
            }
        }

        public ScientificViewModel(): base()
        {
            TrigonometryVisibility = Visibility.Hidden;
            FunctionVisibility = Visibility.Hidden;

            InitializeMouseDownWindowCommand();
            InitializeTrigonometryButtonCommand();
            InitializeFunctionButtonCommand();
        }

        private void InitializeMouseDownWindowCommand()
        {
            MouseDownWindowCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {
                    TrigonometryVisibility = Visibility.Hidden;
                    FunctionVisibility = Visibility.Hidden;
                });
        }

        private void InitializeTrigonometryButtonCommand()
        {
            TrigonometryButtonCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if (TrigonometryVisibility == Visibility.Visible) TrigonometryVisibility = Visibility.Hidden;
                    else TrigonometryVisibility = Visibility.Visible;
                });
        }

        private void InitializeFunctionButtonCommand()
        {
            FunctionButtonCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if (FunctionVisibility == Visibility.Visible) FunctionVisibility = Visibility.Hidden;
                    else FunctionVisibility = Visibility.Visible;
                });
        }
    }
}
