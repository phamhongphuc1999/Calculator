using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public ICommand StandardClickCommand { get; set; }

        public MainViewModel()
        {
            InitializeStandardClickCommand();
        }

        private void InitializeStandardClickCommand()
        {
            StandardClickCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {
                    MessageBox.Show("111111111111111111111111111111");
                });
        }
    }
}
