using Calculator.CalculateService;
using Calculator.Model;
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
        public ICommand ResultCommand { get; set; }

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

        private string calculationText;
        public string CalculationText
        {
            get { return calculationText; }
            set
            {
                calculationText = value;
                OnPropertyChanged();
            }
        }

        private bool isResult;
        private bool isClear;
        private CalculationManager calculationManager;

        public StandardViewModel()
        {
            CurrentElement = "0";
            CalculationText = "";
            CurrentFunction = "";
            isResult = false;
            isClear = false;
            calculationManager = new CalculationManager();

            InitializeDisplayValueCommand();
            InitializeTransformSignCommand();
            InitializeDeleteCommand();
            InitializeBasicCalculationCommand();
            InitializeResultCommand();
        }

        private void InitializeDisplayValueCommand()
        {
            DisplayValueCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    string number = sender.Content.ToString();
                    if (isClear)
                    {
                        CalculationText = "";
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
                    if (CurrentFunction != "")
                    {
                        CalculationResult result = calculationManager.Handler(PreviousElement, CurrentElement, CurrentFunction, function);
                        CalculationText = result.CalculationText;
                        CurrentElement = result.CurrentText;
                    }
                    else CalculationText = CurrentElement + BASIC_FUNCTIONS[function];
                    PreviousElement = CurrentElement;
                    CurrentFunction = function;
                    isResult = false;
                });
        }

        private void InitializeResultCommand()
        {
            ResultCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    isClear = true;
                    if (CurrentFunction != "")
                    {
                        CalculationResult result = calculationManager.Handler(PreviousElement, CurrentElement, CurrentFunction);
                        CalculationText = result.CalculationText;
                        CurrentElement = result.CurrentText;
                    }
                    else CalculationText = CurrentElement;

                });
        }
    }
}
