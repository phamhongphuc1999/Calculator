using Calculator.CustomControl;
using Calculator.Model;
using Calculator.View;
using System.Windows;
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
        public ICommand HistoryCommand { get; set; }

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

        private Visibility historyVisibility;
        public Visibility HistoryVisibility
        {
            get { return historyVisibility; }
            set
            {
                historyVisibility = value;
                OnPropertyChanged();
            }
        }

        private Thickness historyBorderThickness;
        public Thickness HistoryBorderThickness
        {
            get { return historyBorderThickness; }
            set
            {
                historyBorderThickness = value;
                OnPropertyChanged();
            }
        }

        private Thickness memoryBorderThickness;
        public Thickness MemoryBorderThickness
        {
            get { return memoryBorderThickness; }
            set
            {
                memoryBorderThickness = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            IsCheck = false;
            SelectionWindow = "Standard";
            HistoryVisibility = Visibility.Visible;
            HistoryBorderThickness = new Thickness(0, 0, 0, 5);
            MemoryBorderThickness = new Thickness(0);
            CreateRoute();

            InitializePreviewMouseLeftButtonDownCommand();
            InitializeSelectionChangedCommand();
            InitializeMouseDownWindowCommand();
            InitializeLoadedWindowCommand();
            InitializeSettingCommand();
            InitializeAboutCommand();
            InitializeHistoryCommand();
        }

        private void CreateRoute()
        {
            router = new Routes();
            router.RoutingEvent += (object sender, EventArgsRoute e) =>
            {
                int index = e.index;
                bool check = index == 1 || index == 2 || index == 4 || index == 5;
                HistoryVisibility = check ? Visibility.Visible : Visibility.Hidden;
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
            LoadedWindowCommand = new RelayCommand<MainLoadedParameters>(
                sender => { return true; }, sender =>
                {
                    if(sender != null)
                    {
                        mainContentFrame = sender.frame;
                        mainContentFrame.Content = router.Routing(1);
                        MainLeftSidebar leftSide = sender.leftSidebar;
                        leftSide.mainLeftSidebar.SelectedIndex = 1;
                    }
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

        private void InitializeHistoryCommand()
        {
            HistoryCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if(sender.Name == "historyButton")
                    {
                        HistoryBorderThickness = new Thickness(0, 0, 0, 5);
                        MemoryBorderThickness = new Thickness(0);
                    }
                    else
                    {
                        HistoryBorderThickness = new Thickness(0);
                        MemoryBorderThickness = new Thickness(0, 0, 0, 5);
                    }
                });
        }
    }
}
