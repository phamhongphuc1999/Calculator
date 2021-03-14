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
        public ICommand BinaryCalculationCommand { get; set; }
        public ICommand UnaryCalculationCommand { get; set; }
        public ICommand ResultCommand { get; set; }
        public ICommand DecimalCommand { get; set; }
        public ICommand CECommand { get; set; }
        public ICommand CCommand { get; set; }

        public string element1;
        public string Element1
        {
            get { return element1; }
            set
            {
                element1 = value;
                OnPropertyChanged();
            }
        }

        private string Element2;
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
            Element1 = "0";
            DisplayText = "";
            CurrentFunction = "";
            isResult = isClear = false;
            previousStyle = ButtonStyle.NONE;
            numberManager = new NumberManager();
            displayManager = new DisplayManager();

            InitializeDisplayValueCommand();
            InitializeTransformSignCommand();
            InitializeDeleteCommand();
            InitializeBinaryCalculationCommand();
            InitializeUnaryCalculationCommand();
            InitializeResultCommand();
            InitializeDecimalCommand();
            InitializeCECommand();
            InitializeCCommand();
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
                        if (Element1.Length > 0) Element2 = Element1;
                        Element1 = number;
                        isClear = false;
                    }
                    else if (!isResult)
                    {
                        if (Element1.Length > 0) Element2 = Element1;
                        Element1 = number;
                        isResult = true;
                    }
                    else Element1 += number;
                });
        }

        private void InitializeTransformSignCommand()
        {
            TransformSignCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    char first = Element1[0];
                    if (first == '0' && Element1.Length == 1) return;
                    if (first == '-') Element1 = Element1.Substring(1);
                    else Element1 = '-' + Element1;
                });
        }

        private void InitializeDeleteCommand()
        {
            DeleteCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        private void InitializeBinaryCalculationCommand()
        {
            BinaryCalculationCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    string function = sender.Tag.ToString();
                    if (previousStyle == ButtonStyle.BINARY)
                    {
                        CurrentFunction = function;
                        DisplayText = displayManager.BasicDisplay(Element1, function);
                        return;
                    }
                    previousStyle = ButtonStyle.BINARY;
                    if (CurrentFunction != "")
                    {
                        string result = numberManager.BinaryHandler(Element2, Element1, CurrentFunction);
                        Element2 = Element1;
                        Element1 = result;
                    }
                    else Element2 = Element1;
                    DisplayText = displayManager.BasicDisplay(Element1, function);
                    CurrentFunction = function;
                    isResult = false;
                });
        }

        private void InitializeUnaryCalculationCommand()
        {
            UnaryCalculationCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    string function = sender.Tag.ToString();
                    previousStyle = ButtonStyle.UNARY;
                    string result = numberManager.UnaryHandler(Element1, function);
                    Element2 = Element1;
                    Element1 = result;
                    CurrentFunction = function;
                    isResult = false;
                });
        }

        private void InitializeResultCommand()
        {
            ResultCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    DisplayText = displayManager.CalculationDisplay(Element1, Element2, CurrentFunction);
                    string result = numberManager.BinaryHandler(Element1, Element2, CurrentFunction);
                    Element2 = Element1;
                    Element1 = result;
                    isClear = true;
                });
        }

        private void InitializeDecimalCommand()
        {
            DecimalCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if (Element1.IndexOf('.') < 0) Element1 += '.';
                });
        }

        private void InitializeCECommand()
        {
            CECommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        private void InitializeCCommand()
        {
            CCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }
    }
}
