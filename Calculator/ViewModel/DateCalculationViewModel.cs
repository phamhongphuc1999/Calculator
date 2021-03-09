using Calculator.CalculateService;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class DateCalculationViewModel: BaseViewModel
    {
        private DateService dateService;
        public ICommand MouseDownWindowCommand { get; set; }
        public ICommand BaseSwitchFunctionCommand { get; set; }
        public ICommand SwitchFunctionCommand { get; set; }

        private Visibility switchVisibilityGrid;
        public Visibility SwitchVisibilityGrid
        {
            get { return switchVisibilityGrid; }
            set 
            { 
                switchVisibilityGrid = value;
                OnPropertyChanged();
            }
        }

        private string currentFunctionText;
        public string CurrentFunctionText
        {
            get { return currentFunctionText; }
            set
            {
                currentFunctionText = value;
                OnPropertyChanged();
            }
        }

        private string resultText;
        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                OnPropertyChanged();
            }
        }

        public DateCalculationViewModel()
        {
            dateService = new DateService();
            SwitchVisibilityGrid = Visibility.Hidden;
            ResultText = "same day";

            InitializeMouseDownWindowCommand();
            InitializeBaseSwitchFunctionCommand();
            InitializeSwitchFunctionCommand();
        }

        private void InitializeMouseDownWindowCommand()
        {
            MouseDownWindowCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {
                    SwitchVisibilityGrid = Visibility.Hidden;
                });
        }

        private void InitializeBaseSwitchFunctionCommand()
        {
            BaseSwitchFunctionCommand = new RelayCommand<Grid>(
                sender => { return true; }, sender =>
                {
                    SwitchVisibilityGrid = Visibility.Visible;
                });
        }

        private void InitializeSwitchFunctionCommand()
        {
            SwitchFunctionCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    CurrentFunctionText = sender.Content as string;
                    SwitchVisibilityGrid = Visibility.Hidden;
                });
        }
    }
}
