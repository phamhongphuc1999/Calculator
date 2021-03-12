using System;

namespace Calculator.CalculateService
{
    public class NumberManager
    {
        public string BasicHandler(string element1, string element2, string function)
        {
            string result = "";
            switch (function)
            {
                case "add":
                    result = BasicService.AddDecimal(element1, element2);
                    break;
                case "subtract":
                    result = BasicService.SubtractDecimal(element1, element2);
                    break;
                case "mutipilation":
                    result = BasicService.MutipilationDecimal(element1, element2);
                    break;
                case "devision":
                    result = BasicService.DivisionDecimal(element1, element2, 20);
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}
