using Calculator.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Calculator.Constance;

namespace Calculator.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand PreviewMouseLeftButtonDownCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }

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

        private ListViewItem selectionItem;
        public ListViewItem SelectionItem
        {
            get { return selectionItem; }
            set
            {
                if (selectionItem != null) selectionItem.BorderThickness = new Thickness(0);
                selectionItem = value;
                selectionItem.BorderThickness = new Thickness(5, 0, 0, 0);
            }
        }

        public MainViewModel()
        {
            IsCheck = true;
            SelectionWindow = "Standard";

            InitializePreviewMouseLeftButtonDownCommand();
            InitializeSelectionChangedCommand();
        }

        private void InitializePreviewMouseLeftButtonDownCommand()
        {
            PreviewMouseLeftButtonDownCommand = new RelayCommand<MainWindow>(
                sender => { return true; }, sender => IsCheck = !IsCheck);
        }

        private void InitializeSelectionChangedCommand()
        {
            SelectionChangedCommand = new RelayCommand<MainWindow>(
                sender => { return true; }, sender =>
                {
                    if (sender == null) return;
                    ListViewItem selected = sender.mainLeftSidebar.SelectedItem as ListViewItem;
                    if (selected == null) return;
                    int index = sender.mainLeftSidebar.SelectedIndex;
                    SelectionWindow = MAIN_LIST_TITLE[index];
                    SelectionItem = selected;
                });
        }
    }
}
