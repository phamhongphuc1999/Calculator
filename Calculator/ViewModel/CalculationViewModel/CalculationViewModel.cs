using Calculator.CalculateService;
using Calculator.DisplayService;
using System.Windows.Controls;
using System.Windows.Input;
using static Calculator.Constance;

namespace Calculator.ViewModel.CalculationViewModel
{
    public class CalculationViewModel: BaseViewModel
    {
        public ICommand DisplayValueCommand { get; set; }
        public ICommand TransformSignCommand { get; set; }
        public ICommand UnaryCalculationCommand { get; set; }
        public ICommand BinaryCalculationCommand { get; set; }
        public ICommand DecimalCommand { get; set; }

        protected string element1;
        public string Element1
        {
            get { return element1; }
            set
            {
                element1 = value;
                OnPropertyChanged();
            }
        }

        protected string Element2;
        protected string CurrentFunction;

        protected string displayText;
        public string DisplayText
        {
            get { return displayText; }
            set
            {
                displayText = value;
                OnPropertyChanged();
            }
        }

        protected ButtonStyle previousStyle;
        protected bool isResult, isClear;
        protected NumberManager numberManager;
        protected DisplayManager displayManager;

        public CalculationViewModel()
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
            InitializeUnaryCalculationCommand();
            InitializeBinaryCalculationCommand();
            InitializeDecimalCommand();
        }

        protected virtual void InitializeDisplayValueCommand()
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
                    else if (!isResult || Element1 == "0")
                    {
                        if (Element1.Length > 0) Element2 = Element1;
                        Element1 = number;
                        isResult = true;
                    }
                    else Element1 += number;
                });
        }

        protected virtual void InitializeTransformSignCommand()
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

        protected virtual void InitializeUnaryCalculationCommand()
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

        protected virtual void InitializeBinaryCalculationCommand()
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

        protected virtual void InitializeDecimalCommand()
        {
            DecimalCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if (Element1.IndexOf('.') < 0) Element1 += '.';
                });
        }
    }
}
