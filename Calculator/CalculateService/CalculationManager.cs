using Calculator.Model;
using System;
using static Calculator.Constance;

namespace Calculator.CalculateService
{
    public class CalculationManager
    {
        public CalculationResult Handler(string element1, string element2, string currentFunction, string nextFunction = "")
        {
            string result = "";
            switch (currentFunction)
            {
                case "add":
                    result = BasicService.AddInteger(element1, element2);
                    break;
                case "subtract":
                    result = BasicService.SubtractInteger(element1, element2);
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
