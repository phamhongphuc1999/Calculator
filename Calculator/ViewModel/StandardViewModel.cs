using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class StandardViewModel: BaseViewModel
    {
        public ICommand ClickNumberCommand { get; set; }
        public ICommand TransformSignCommand { get; set; }
        public ICommand DecimalCommand { get; set; }

        public StandardViewModel()
        {
            InitializeClickNumberCommand();
            InitializeTransformSignCommand();
            InitializeDecimalCommand();
        }

        private void InitializeClickNumberCommand()
        {
            ClickNumberCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    MessageBox.Show(sender.Content.ToString());
                });
        }

        private void InitializeTransformSignCommand()
        {
            TransformSignCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }

        private void InitializeDecimalCommand()
        {
            DecimalCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {

                });
        }
    }
}
