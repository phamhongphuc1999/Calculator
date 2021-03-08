using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
    /// <summary>
    /// Interaction logic for SettingButton.xaml
    /// </summary>
    public partial class SettingButton : UserControl
    {
        private static DependencyProperty ClickCommandProperty = DependencyProperty.Register(
            "ClickCommand", typeof(ICommand), typeof(SettingButton));
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set
            {
                SetValue(ClickCommandProperty, value);
            }
        }

        private static DependencyProperty DesignIconProperty = DependencyProperty.Register(
            "DesignIcon", typeof(string), typeof(SettingButton));
        public string DesignIcon
        {
            get { return (string)GetValue(DesignIconProperty); }
            set
            {
                SetValue(DesignIconProperty, value);
            }
        }

        private static DependencyProperty MainTitleProperty = DependencyProperty.Register(
            "MainTitle", typeof(string), typeof(SettingButton));
        public string MainTitle
        {
            get { return (string)GetValue(MainTitleProperty); }
            set
            {
                SetValue(MainTitleProperty, value);
            }
        }

        private static DependencyProperty SubTitleProperty = DependencyProperty.Register(
            "SubTitle", typeof(string), typeof(SettingButton));
        public string SubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set
            {
                SetValue(SubTitleProperty, value);
            }
        }

        public SettingButton()
        {
            InitializeComponent();
        }
    }
}
