using Calculator.CalculateService;
using Calculator.Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class StandardViewModel : BaseViewModel
    {
        public ICommand DisplayValueCommand { get; set; }
        public ICommand TransformSignCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BasicCalculationCommand { get; set; }
        public ICommand ResultCommand { get; set; }

        private string elementText;
        public string ElementText
        {
            get { return elementText; }
            set
            {
                elementText = value;
                OnPropertyChanged();
            }
        }

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
        private CalculationManager calculationManager;

        public StandardViewModel()
        {
            ElementText = "0";
            CalculationText = "";
            isResult = false;
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
                    if (!isResult)
                    {
                        ElementText = number;
                        isResult = true;
                    }
                    else ElementText += number;
                });
        }

        private void InitializeTransformSignCommand()
        {
            TransformSignCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

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
                    string function = sender.Content.ToString();
                    if (CalculationText != "") 
                    {
                        CalculationResult result = calculationManager.Handler(ElementText, CalculationText, function);
                        CalculationText = result.CalculationText;
                        ElementText = result.ElementText;
                    }
                    else CalculationText = ElementText + function;
                    isResult = false;
                });
        }

        private void InitializeResultCommand()
        {
            ResultCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }
    }
}
