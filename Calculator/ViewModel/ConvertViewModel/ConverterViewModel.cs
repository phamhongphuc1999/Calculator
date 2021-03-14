using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel.ConvertViewModel
{
    public class ConverterViewModel: BaseViewModel
    {
        public ICommand ClickNumberCommand { get; set; }
        public ICommand CECommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DecimalCommand { get; set; }

        public ConverterViewModel()
        {
            InitializeClickNumberCommand();
            InitializeCECommand();
            InitializeDeleteCommand();
            InitializeDecimalCommand();
        }

        protected virtual void InitializeClickNumberCommand()
        {
            ClickNumberCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        protected virtual void InitializeCECommand()
        {
            CECommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        protected virtual void InitializeDeleteCommand()
        {
            DeleteCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        protected virtual void InitializeDecimalCommand()
        {
            DecimalCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }
    }
}
