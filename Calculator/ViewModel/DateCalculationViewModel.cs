using Calculator.CalculateService;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator.ViewModel
{
    public class DateCalculationViewModel: BaseViewModel
    {
        public ICommand MouseDownWindowCommand { get; set; }
        public ICommand BaseSwitchFunctionCommand { get; set; }
        public ICommand SwitchFunctionCommand { get; set; }
        public ICommand ToDateSelectedDateChangedCommand { get; set; }
        public ICommand FromDateSelectedDateChangedCommand { get; set; }
        public ICommand YearSelectionChangedCommand { get; set; }
        public ICommand MonthSelectionChangedCommand { get; set; }
        public ICommand DaySelectionChangedCommand { get; set; }
        public ICommand RadioChooseCommand { get; set; }

        private DateTime fromDate, toDate;
        private int years, months, days;
        private Button currentFunctionButton;

        public ObservableCollection<int> CbContent { get; private set; }

        private Visibility switchVisibilityGrid;
        public Visibility SwitchVisibilityGrid
        {
            get { return switchVisibilityGrid; }
            set 
            { 
                switchVisibilityGrid = value;
                OnPropertyChanged();
            }
        }

        private Visibility diffirenceVisibilityStack;
        public Visibility DiffirenceVisibilityStack
        {
            get { return diffirenceVisibilityStack; }
            set
            {
                diffirenceVisibilityStack = value;
                OnPropertyChanged();
            }
        }

        private Visibility addOrSubtractVisibilityStack;
        public Visibility AddOrSubtractVisibilityStack
        {
            get { return addOrSubtractVisibilityStack; }
            set
            {
                addOrSubtractVisibilityStack = value;
                OnPropertyChanged();
            }
        }

        private string currentFunctionText;
        public string CurrentFunctionText
        {
            get { return currentFunctionText; }
            set
            {
                currentFunctionText = value;
                OnPropertyChanged();
            }
        }

        private string resultDiffirenceText;
        public string ResultDiffirenceText
        {
            get { return resultDiffirenceText; }
            set
            {
                resultDiffirenceText = value;
                OnPropertyChanged();
            }
        }

        private string resultCalculationText;
        public string ResultCalculationText
        {
            get { return resultCalculationText; }
            set
            {
                resultCalculationText = value;
                OnPropertyChanged();
            }
        }

        private bool isAddChoose;
        public bool IsAddChoose
        {
            get { return isAddChoose; }
            set
            {
                isAddChoose = value;
                OnPropertyChanged();
            }
        }

        private Thickness gridMargin;
        public Thickness GridMargin
        {
            get { return gridMargin; }
            set
            {
                gridMargin = value;
                OnPropertyChanged();
            }
        }

        public DateCalculationViewModel()
        {
            SwitchVisibilityGrid = Visibility.Hidden;
            DiffirenceVisibilityStack = Visibility.Visible;
            AddOrSubtractVisibilityStack = Visibility.Hidden;
            ResultDiffirenceText = "Same day";
            ResultCalculationText = DateTime.Now.ToString("D");
            fromDate = toDate = DateTime.Now;
            years = months = days = 0;
            IsAddChoose = true;
            GridMargin = new Thickness(0, 35, 0, 0);

            int[] sequence = Enumerable.Range(0, 999).ToArray();
            CbContent = new ObservableCollection<int>(sequence);

            InitializeMouseDownWindowCommand();
            InitializeBaseSwitchFunctionCommand();
            InitializeSwitchFunctionCommand();
            InitializeToDateSelectedDateChangedCommand();
            InitializeFromDateSelectedDateChangedCommand();
            InitializeYearSelectionChangedCommand();
            InitializeMonthSelectionChangedCommand();
            InitializeDaySelectionChangedCommand();
            InitializeRadioChooseCommand();
        }

        private void HanddlerSubtractDate(DateTime fromDate, DateTime toDate)
        {
            string result = DateService.DiffirenceDates(fromDate, toDate);
            if (result == "0") ResultDiffirenceText = "Same day";
            else if (result == "1") ResultDiffirenceText = "1 days";
            else ResultDiffirenceText = $"{result} days";
        }

        private void InitializeMouseDownWindowCommand()
        {
            MouseDownWindowCommand = new RelayCommand<object>(
                sender => { return true; }, sender =>
                {
                    SwitchVisibilityGrid = Visibility.Hidden;
                });
        }

        private void InitializeBaseSwitchFunctionCommand()
        {
            BaseSwitchFunctionCommand = new RelayCommand<Grid>(
                sender => { return true; }, sender =>
                {
                    SwitchVisibilityGrid = Visibility.Visible;
                });
        }

        private void InitializeSwitchFunctionCommand()
        {
            SwitchFunctionCommand = new RelayCommand<Button>(
                sender => { return true; }, sender =>
                {
                    if(currentFunctionButton != null) currentFunctionButton.Background = Brushes.Transparent;
                    currentFunctionButton = sender;
                    currentFunctionButton.Background = Brushes.Purple;
                    CurrentFunctionText = (string)sender.Content;
                    SwitchVisibilityGrid = Visibility.Hidden;
                    string index = (string)sender.Tag;
                    if(index.Equals("0"))
                    {
                        DiffirenceVisibilityStack = Visibility.Visible;
                        AddOrSubtractVisibilityStack = Visibility.Hidden;
                        GridMargin = new Thickness(0, 35, 0, 0);
                    }
                    else
                    {
                        DiffirenceVisibilityStack = Visibility.Hidden;
                        AddOrSubtractVisibilityStack = Visibility.Visible;
                        GridMargin = new Thickness(0, -35, 0, 0);
                    }
                });
        }

        private void InitializeFromDateSelectedDateChangedCommand()
        {
            FromDateSelectedDateChangedCommand = new RelayCommand<DatePicker>(
                sender => { return true; }, sender =>
                {
                    fromDate = sender.SelectedDate ?? fromDate;
                    if (DiffirenceVisibilityStack == Visibility.Visible) HanddlerSubtractDate(fromDate, toDate);
                    else if (IsAddChoose) ResultCalculationText = DateService.AddDates(fromDate, years, months, days);
                    else ResultCalculationText = DateService.SubtractDates(fromDate, years, months, days);
                });
        }

        private void InitializeToDateSelectedDateChangedCommand()
        {
            ToDateSelectedDateChangedCommand = new RelayCommand<DatePicker>(
                sender => { return true; }, sender =>
                {
                    toDate = sender.SelectedDate ?? toDate;
                    HanddlerSubtractDate(fromDate, toDate);
                });
        }

        private void InitializeYearSelectionChangedCommand()
        {
            YearSelectionChangedCommand = new RelayCommand<ComboBox>(
                sender => { return true; }, sender =>
                {
                    years = (int)sender.SelectedItem;
                    if (IsAddChoose) ResultCalculationText = DateService.AddDates(fromDate, years, months, days);
                    else ResultCalculationText = DateService.SubtractDates(fromDate, years, months, days);
                });
        }

        private void InitializeMonthSelectionChangedCommand()
        {
            MonthSelectionChangedCommand = new RelayCommand<ComboBox>(
                sender => { return true; }, sender =>
                {
                    months = (int)sender.SelectedItem;
                    if (IsAddChoose) ResultCalculationText = DateService.AddDates(fromDate, years, months, days);
                    else ResultCalculationText = DateService.SubtractDates(fromDate, years, months, days);
                });
        }

        private void InitializeDaySelectionChangedCommand()
        {
            DaySelectionChangedCommand = new RelayCommand<ComboBox>(
                sender => { return true; }, sender =>
                {
                    days = (int)sender.SelectedItem;
                    if (IsAddChoose) ResultCalculationText = DateService.AddDates(fromDate, years, months, days);
                    else ResultCalculationText = DateService.SubtractDates(fromDate, years, months, days);
                });
        }

        private void InitializeRadioChooseCommand()
        {
            RadioChooseCommand = new RelayCommand<RadioButton>(
                sender => { return true; }, sender =>
                {
                    if (sender.Name.Equals("addRadio"))
                    {
                        IsAddChoose = true;
                        ResultCalculationText = DateService.AddDates(fromDate, years, months, days);
                    }
                    else
                    {
                        IsAddChoose = false;
                        ResultCalculationText = DateService.SubtractDates(fromDate, years, months, days);
                    }
                });
        }
    }
}
