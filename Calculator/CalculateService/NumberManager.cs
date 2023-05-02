using System;

namespace Calculator.CalculateService
{
  public class NumberManager
  {
    public string BinaryHandler(string element1, string element2, string function)
    {
      element1 = CalculateUtilities.StandardizedDisplay(element1);
      element2 = CalculateUtilities.StandardizedDisplay(element2);
      switch (function)
      {
        case "add":
          return BinaryOperatorService.AddDecimal(element1, element2);
        case "subtract":
          return BinaryOperatorService.SubtractDecimal(element1, element2);
        case "mutipilation":
          return BinaryOperatorService.MutipilationDecimal(element1, element2);
        case "devision":
          return BinaryOperatorService.DivisionDecimal(element1, element2, 20);
        default:
          throw new Exception();
      }
    }

    public string UnaryHandler(string element, string function)
    {
      element = CalculateUtilities.StandardizedDisplay(element);
      if (function.Contains("precent"))
        return UnaryOperatorService.Devision10(element, 2);
      else if (function.Contains("inverse"))
        return UnaryOperatorService.InverseNumber(element);
      else if (function.Contains("exponential"))
        return UnaryOperatorService.ExponentialDecimal(element, function[function.Length - 1] - '0');
      else if (function.Contains("square"))
        return UnaryOperatorService.SquareDecimal(element, function[function.Length - 1] - '0', 10);
      else throw new Exception();
    }
  }
}
