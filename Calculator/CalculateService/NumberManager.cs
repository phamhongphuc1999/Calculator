using System;

namespace Calculator.CalculateService
{
    public class NumberManager
    {
        public string BinaryHandler(string element1, string element2, string function)
        {
            Utilities.StandardizedDisplay(ref element1);
            Utilities.StandardizedDisplay(ref element2);
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
            Utilities.StandardizedDisplay(ref element);
            switch (function)
            {
                case "percent":
                    return UnaryOperatorService.PercentNumber(element);
                case "inverse":
                    return UnaryOperatorService.InverseNumber(element);
                case "exponential":
                    return UnaryOperatorService.ExponentialDecimal(element, 2);
                default:
                    throw new Exception();
            }
        }
    }
}
