using System.Numerics;

namespace Calculator.CalculateService
{
    static class AdvancedService
    {
        public static string SquareInteger(string number, int exponent)
        {
            BigInteger element = BigInteger.Parse(number);
            return BigInteger.Pow(element, exponent).ToString();
        }

        public static string SquareDecimal(string number, int exponent)
        {
            if (exponent == 1) return number;
            else if(exponent % 2 == 0)
            {
                string result = SquareDecimal(number, exponent / 2);
                return BasicService.MutipilationDecimal(result, result);
            }
            else
            {
                string result = SquareDecimal(number, exponent / 2);
                result = BasicService.MutipilationDecimal(result, result);
                return BasicService.MutipilationDecimal(result, number);
            }
        }
    }
}
