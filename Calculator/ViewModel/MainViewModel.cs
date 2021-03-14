using Calculator.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand PreviewMouseLeftButtonDownCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand MouseDownWindowCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand AboutCommand { get; set; }

        private Frame mainContentFrame;
        private Routes router;

        private bool isCheck;
        public bool IsCheck
        {
            get { return isCheck; }
            set
            {
                isCheck = value;
                OnPropertyChanged();
            }
        }

        private string selectionWindow;
        public string SelectionWindow
        {
            get { return selectionWindow; }
            set
            {
                selectionWindow = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            IsCheck = false;
            SelectionWindow = "Standard";
            CreateRoute();

            InitializePreviewMouseLeftButtonDownCommand();
            InitializeSelectionChangedCommand();
            InitializeMouseDownWindowCommand();
            InitializeLoadedWindowCommand();
            InitializeSettingCommand();
            InitializeAboutCommand();
        }

        private void CreateRoute()
        {
            router = new Routes();
            router.RoutingEvent += (sender, e) =>
            {
            };
        }

        private void InitializePreviewMouseLeftButtonDownCommand()
        {
            PreviewMouseLeftButtonDownCommand = new RelayCommand<ListView>(
                sender => { return true; }, sender => IsCheck = false);
        }

        private void InitializeSelectionChangedCommand()
        {
            SelectionChangedCommand = new RelayCommand<ListView>(
                sender => { return true; }, sender =>
                {
                    if (sender == null) return;
                    ListViewItem selected = sender.SelectedItem as ListViewItem;
                    if (selected == null) return;
                    int index = sender.SelectedIndex;
                    SelectionWindow = (string)selected.Tag;
                    if (mainContentFrame != null) mainContentFrame.Content = router.Routing(index);
                });
        }

        private void InitializeMouseDownWindowCommand()
        {
            MouseDownWindowCommand = new RelayCommand<object>(
                sender => { return true; }, sender => IsCheck = false);
        }

        private void InitializeLoadedWindowCommand()
        {
            LoadedWindowCommand = new RelayCommand<Frame>(
                sender => { return true; }, sender =>
                {
                    mainContentFrame = sender;
                    mainContentFrame.Content = router.Routing(1);
                });
        }

        private void InitializeSettingCommand()
        {
            SettingCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {
                    SettingWindow settingWindow = new SettingWindow();
                    IsCheck = false;
                    settingWindow.ShowDialog();
                });
        }

        private void InitializeAboutCommand()
        {
            AboutCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {
                    System.Diagnostics.Process.Start(Constance.GITHUB_LINK);
                });
        }
    }
}
