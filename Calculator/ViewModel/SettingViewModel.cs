using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class SettingViewModel: BaseViewModel
    {
        public ICommand ThemeSettingCommand { get; set; }
        public ICommand LanguageSettingCommand { get; set; }

        public SettingViewModel()
        {
            InitializeThemeSettingCommand();
            InitializeLanguageSettingCommand();
        }

        private void InitializeThemeSettingCommand()
        {
            ThemeSettingCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {

                });
        }

        private void InitializeLanguageSettingCommand()
        {
            LanguageSettingCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {

                });
        }
    }
}
