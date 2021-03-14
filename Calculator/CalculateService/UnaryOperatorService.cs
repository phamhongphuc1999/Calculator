using System;
using System.Numerics;

namespace Calculator.CalculateService
{
    static class UnaryOperatorService
    {
        public static string PercentNumber(string number)
        {
            return BinaryOperatorService.DivisionDecimal(number, "100", 20);
        }

        public static string InverseNumber(string number)
        {
            return BinaryOperatorService.DivisionDecimal("1", number, 20);
        }

        public static string ExponentialInteger(string number, int exponent)
        {
            BigInteger element = BigInteger.Parse(number);
            return BigInteger.Pow(element, exponent).ToString();
        }

        public static string ExponentialDecimal(string number, int exponent)
        {
            if (exponent == 1) return number;
            else if(exponent % 2 == 0)
            {
                string result = ExponentialDecimal(number, exponent / 2);
                return BinaryOperatorService.MutipilationDecimal(result, result);
            }
            else
            {
                string result = ExponentialDecimal(number, exponent / 2);
                result = BinaryOperatorService.MutipilationDecimal(result, result);
                return BinaryOperatorService.MutipilationDecimal(result, number);
            }
        }

        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);
                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }
                return root;
            }
            throw new ArithmeticException("NaN");
        }

        private static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);
            return (n >= lowerBound && n < upperBound);
        }
    }
}
