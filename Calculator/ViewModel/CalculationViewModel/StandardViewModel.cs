using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel.CalculationViewModel
{
    public class StandardViewModel : CalculationViewModel
    {
        public ICommand DeleteCommand { get; set; }
        public ICommand ResultCommand { get; set; }
        public ICommand CECommand { get; set; }
        public ICommand CCommand { get; set; }

        public StandardViewModel(): base()
        {
            InitializeDeleteCommand();
            InitializeResultCommand();
            InitializeCECommand();
            InitializeCCommand();
        }

        private void InitializeDeleteCommand()
        {
            DeleteCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
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
