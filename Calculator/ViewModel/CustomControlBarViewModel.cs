using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class CustomControlBarViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseLeftButtonDownCommand { get; set; }

        private string maximizeIcon;
        public string MaximizeIcon
        {
            get { return maximizeIcon; }
            set
            {
                maximizeIcon = value;
                OnPropertyChanged();
            }
        }

        public CustomControlBarViewModel()
        {
            MaximizeIcon = "WindowMaximize";

            InitializeCloseWindowCommand();
            InitializeMaximizeWindowCommand();
            InitializeMinimizeWindowCommand();
            InitializeMouseLeftButtonDownCommand();
        }

        private FrameworkElement GetRootParent(UserControl control)
        {
            FrameworkElement parent = control;
            while (parent.Parent != null)
                parent = parent.Parent as FrameworkElement;
            return parent;
        }

        private void InitializeCloseWindowCommand()
        {
            CloseWindowCommand = new RelayCommand<UserControl>(
                sender =>
                {
                    return sender != null;
                }, sender =>
                {
                    FrameworkElement parent = GetRootParent(sender);
                    Window rootWindow = parent as Window;
                    if (rootWindow != null)
                    {
                        App.storageManager.SaveConfiguration();
                        rootWindow.Close();
                    }
                });
        }

        private void InitializeMaximizeWindowCommand()
        {
            MaximizeWindowCommand = new RelayCommand<UserControl>(
                sender =>
                {
                    return sender != null;
                }, sender =>
                {
                    MaximizeIcon = maximizeIcon == "WindowMaximize" ? "WindowRestore" : "WindowMaximize";
                    FrameworkElement root = GetRootParent(sender);
                    Window window = root as Window;
                    if (window != null)
                    {
                        if (window.WindowState != WindowState.Maximized) window.WindowState = WindowState.Maximized;
                        else window.WindowState = WindowState.Normal;
                    }
                });
        }

        private void InitializeMinimizeWindowCommand()
        {
            MinimizeWindowCommand = new RelayCommand<UserControl>(
                sender =>
                {
                    return sender == null ? false : true;
                },
                sender =>
                {
                    FrameworkElement root = GetRootParent(sender);
                    Window window = root as Window;
                    if (window != null) window.WindowState = WindowState.Minimized;
                });
        }

        private void InitializeMouseLeftButtonDownCommand()
        {
            MouseLeftButtonDownCommand = new RelayCommand<UserControl>(
                sender =>
                {
                    return sender == null ? false : true;
                },
                sender =>
                {
                    FrameworkElement root = GetRootParent(sender);
                    Window window = root as Window;
                    if (window != null) window.DragMove();
                });
        }
    }
}
