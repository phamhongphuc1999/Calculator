using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class SettingViewModel: BaseViewModel
    {
        public ICommand ThemeSettingCommand { get; set; }

        public SettingViewModel()
        {
            InitializeThemeSettingCommand();
        }

        private void InitializeThemeSettingCommand()
        {
            ThemeSettingCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {

                });
        }
    }
}
