using Calculator.Model;

namespace Calculator.CalculateService
{
    public class CalculationManager
    {
        public CalculationResult Handler(string elementText, string calculationText, string nextSign)
        {
            int index = calculationText.Length - 1;
            char sign = calculationText[index];
            string calculator = calculationText.Substring(0, index);
            string result = "";
            if (sign == '+') result = BasicService.Add(calculator, elementText);
            return new CalculationResult
            {
                ElementText = result,
                CalculationText = result + nextSign
            };
        }
    }
}
