using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.CustomControl
{
  /// <summary>
  /// Interaction logic for SettingElement.xaml
  /// </summary>
  public partial class SettingElement : UserControl
  {
    private static DependencyProperty MouseDownWindowCommandProperty = DependencyProperty.Register(
        "MouseDownWindowCommand", typeof(ICommand), typeof(SettingElement));
    public ICommand MouseDownWindowCommand
    {
      get { return (ICommand)GetValue(MouseDownWindowCommandProperty); }
      set
      {
        SetValue(MouseDownWindowCommandProperty, value);
      }
    }

    private static DependencyProperty DesignIconProperty = DependencyProperty.Register(
        "DesignIcon", typeof(string), typeof(SettingElement));
    public string DesignIcon
    {
      get { return (string)GetValue(DesignIconProperty); }
      set
      {
        SetValue(DesignIconProperty, value);
      }
    }

    private static DependencyProperty MainTitleProperty = DependencyProperty.Register(
        "MainTitle", typeof(string), typeof(SettingElement));
    public string MainTitle
    {
      get { return (string)GetValue(MainTitleProperty); }
      set
      {
        SetValue(MainTitleProperty, value);
      }
    }

    private static DependencyProperty SubTitleProperty = DependencyProperty.Register(
        "SubTitle", typeof(string), typeof(SettingElement));
    public string SubTitle
    {
      get { return (string)GetValue(SubTitleProperty); }
      set
      {
        SetValue(SubTitleProperty, value);
      }
    }

    public SettingElement()
    {
      InitializeComponent();
    }
  }
}
