using Calculator.CustomControl;
using Calculator.Model;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Calculator.CustomConverter
{
  public class MainLoadedConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      MainLoadedParameters parameters = new MainLoadedParameters();
      parameters.frame = (Frame)values[0];
      parameters.leftSidebar = (MainLeftSidebar)values[1];
      return parameters;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
