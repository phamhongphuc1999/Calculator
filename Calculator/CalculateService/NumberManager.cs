using Calculator.Model;
using System;
using static Calculator.Constance;

namespace Calculator.CalculateService
{
    public class NumberManager
    {
        public CalculationResult Handler(string element1, string element2, string currentFunction, string nextFunction = "")
        {
            string result = "";
            switch (currentFunction)
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
            return new CalculationResult
            {
                CurrentText = result,
                CalculationText = String.IsNullOrEmpty(nextFunction) ? result : result + BASIC_FUNCTIONS[nextFunction]
            };
        }
    }
}
