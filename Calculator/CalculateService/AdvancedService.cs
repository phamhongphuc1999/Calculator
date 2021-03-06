namespace Calculator.CalculateService
{
    static class AdvancedService
    {
        public static string SquareInteger(string number)
        {
            return BasicService.MutipilationInteger(number, number);
        }

        public static string SquareDecimal(string number)
        {
            return BasicService.MutipilationDecimal(number, number);
        }
    }
}
