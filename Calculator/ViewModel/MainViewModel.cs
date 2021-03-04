using Calculator.View;
using System;
using System.Windows;
using System.Windows.Input;
using static Calculator.Constance;

namespace Calculator.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
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

        public MainViewModel()
        {
            IsCheck = true;
            SelectionWindow = "Standard";

            InitializeSelectionChangedCommand();
        }

        private void InitializeSelectionChangedCommand()
        {
            SelectionChangedCommand = new RelayCommand<MainWindow>(
                sender => { return true; }, sender =>
                {
                    if (sender == null) return;
                    int index = sender.mainLeftSidebar.SelectedIndex;
                    IsCheck = !IsCheck;
                    SelectionWindow = MAIN_LIST_TITLE[index];
                    sender.TrainsitionigContentSlide.OnApplyTemplate();
                    sender.GridCursor.Margin = new Thickness(0, 40 * index, 0, 0);
                });
        }
    }
}
