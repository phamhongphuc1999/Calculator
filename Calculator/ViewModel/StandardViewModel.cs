using Calculator.CalculateService;
using Calculator.DisplayService;
using System.Windows.Controls;
using System.Windows.Input;
using static Calculator.Constance;

namespace Calculator.ViewModel
{
    public class StandardViewModel : BaseViewModel
    {
        public ICommand DisplayValueCommand { get; set; }
        public ICommand TransformSignCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BasicCalculationCommand { get; set; }
        public ICommand AdvancedCalculationCommand { get; set; }
        public ICommand ResultCommand { get; set; }
        public ICommand DecimalCommand { get; set; }

        public string currentElement;
        public string CurrentElement
        {
            get { return currentElement; }
            set
            {
                currentElement = value;
                OnPropertyChanged();
            }
        }

        private string PreviousElement;
        private string CurrentFunction;

        private string displayText;
        public string DisplayText
        {
            get { return displayText; }
            set
            {
                displayText = value;
                OnPropertyChanged();
            }
        }

        private ButtonStyle previousStyle;
        private bool isResult, isClear;
        private NumberManager numberManager;
        private DisplayManager displayManager;

        public StandardViewModel()
        {
            CurrentElement = "0";
            DisplayText = "";
            CurrentFunction = "";
            isResult = isClear = false;
            previousStyle = ButtonStyle.NONE;
            numberManager = new NumberManager();
            displayManager = new DisplayManager();

            InitializeDisplayValueCommand();
            InitializeTransformSignCommand();
            InitializeDeleteCommand();
            InitializeBasicCalculationCommand();
            InitializeAdvancedCalculationCommand();
            InitializeResultCommand();
            InitializeDecimalCommand();
        }

        private void InitializeDisplayValueCommand()
        {
            DisplayValueCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    string number = sender.Content.ToString();
                    previousStyle = ButtonStyle.NUMBER;
                    if (isClear)
                    {
                        DisplayText = "";
                        CurrentElement = number;
                        isClear = false;
                    }
                    else if (!isResult)
                    {
                        CurrentElement = number;
                        isResult = true;
                    }
                    else CurrentElement += number;
                });
        }

        private void InitializeTransformSignCommand()
        {
            TransformSignCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    char first = CurrentElement[0];
                    if (first == '0' && CurrentElement.Length == 1) return;
                    if (first == '-') CurrentElement = CurrentElement.Substring(1);
                    else CurrentElement = '-' + CurrentElement;
                });
        }

        private void InitializeDeleteCommand()
        {
            DeleteCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        private void InitializeBasicCalculationCommand()
        {
            BasicCalculationCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    string function = sender.Tag.ToString();
                    if (previousStyle == ButtonStyle.FUNCTION)
                    {
                        CurrentFunction = function;
                        DisplayText = displayManager.BasicDisplay(CurrentElement, function);
                        return;
                    }
                    previousStyle = ButtonStyle.FUNCTION;
                    if (CurrentFunction != "")
                    {
                        string result = numberManager.BasicHandler(PreviousElement, CurrentElement, CurrentFunction);
                        CurrentElement = result;
                    }
                    DisplayText = displayManager.BasicDisplay(CurrentElement, function);
                    PreviousElement = CurrentElement;
                    CurrentFunction = function;
                    isResult = false;
                });
        }

        private void InitializeAdvancedCalculationCommand()
        {
            AdvancedCalculationCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        private void InitializeResultCommand()
        {
            ResultCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    DisplayText = displayManager.CalculationDisplay(CurrentElement, PreviousElement, CurrentFunction);
                    string result = numberManager.BasicHandler(CurrentElement, PreviousElement, CurrentFunction);
                    CurrentElement = result;
                    isClear = true;
                });
        }

        private void InitializeDecimalCommand()
        {
            DecimalCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if (CurrentElement.IndexOf('.') < 0) CurrentElement += '.';
                });
        }
    }
}
