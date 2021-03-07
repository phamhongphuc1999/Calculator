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
        public ICommand MouseDownWindowCommand { get; set; }

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
            IsCheck = false;
            SelectionWindow = "Standard";

            InitializePreviewMouseLeftButtonDownCommand();
            InitializeSelectionChangedCommand();
            InitializeMouseDownWindowCommand();
        }

        private void InitializePreviewMouseLeftButtonDownCommand()
        {
            PreviewMouseLeftButtonDownCommand = new RelayCommand<ListView>(
                sender => { return true; }, sender => IsCheck = !IsCheck);
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
                    SelectionWindow = MAIN_LIST_TITLE[index];
                    SelectionItem = selected;
                });
        }

        private void InitializeMouseDownWindowCommand()
        {
            MouseDownWindowCommand = new RelayCommand<object>(
                sender => { return true; }, sender => IsCheck = !IsCheck);
        }
    }
}
