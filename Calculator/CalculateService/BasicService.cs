using System;
using System.Numerics;

namespace Calculator.CalculateService
{
    class BasicService
    {
        public static string AddInteger(string number1, string number2)
        {
            try
            {
                BigInteger element1 = BigInteger.Parse(number1);
                BigInteger element2 = BigInteger.Parse(number2);
                return BigInteger.Add(element1, element2).ToString();
            }
            catch
            {
                throw new Exception("This number format wrong");
            }
        }

        public static string SubtractInteger(string number1, string number2)
        {
            try
            {
                BigInteger element1 = BigInteger.Parse(number1);
                BigInteger element2 = BigInteger.Parse(number2);
                return BigInteger.Subtract(element1, element2).ToString();
            }
            catch
            {
                throw new Exception("This number format wrong");
            }
        }

        public static string MutipilationInteger(string number1, string number2)
        {
            try
            {
                BigInteger element1 = BigInteger.Parse(number1);
                BigInteger element2 = BigInteger.Parse(number2);
                return BigInteger.Multiply(element1, element2).ToString();
            }
            catch
            {
                throw new Exception("This number format wrong");
            }
        }

        public static string DivisionInteger(string number1, string number2)
        {
            try
            {
                BigInteger element1 = BigInteger.Parse(number1);
                BigInteger element2 = BigInteger.Parse(number2);
                return BigInteger.Divide(element1, element2).ToString();
            }
            catch
            {
                throw new Exception("This number format wrong");
            }
        }

        public static string DivisionInteger(string number1, string number2, out string remainder)
        {
            try
            {
                BigInteger element1 = BigInteger.Parse(number1);
                BigInteger element2 = BigInteger.Parse(number2);
                BigInteger bRemainder = new BigInteger();
                BigInteger result = BigInteger.DivRem(element1, element2, out bRemainder);
                remainder = bRemainder.ToString();
                return result.ToString();
            }
            catch
            {
                throw new Exception("This number format wrong");
            }
        }

        private static int ConvertDecimal(ref string dec)
        {
            int length = dec.Length;
            int index = dec.IndexOf('.');
            string[] temp = dec.Split('.');
            if(temp.Length > 1) dec = temp[0] + temp[1];
            if (index >= 0) return length - index - 1;
            else return 0;
        }

        public static string AddDecimal(string decimal1, string decimal2)
        {
            int need1 = ConvertDecimal(ref decimal1);
            int need2 = ConvertDecimal(ref decimal2);
            int need = 0;
            if(need1 > need2)
            {
                need = need1;
                int temp = need1 - need2;
                for (int i = 0; i < temp; i++) decimal2 += '0';
            }
            else
            {
                need = need2;
                int temp = need2 - need1;
                for (int i = 0; i < temp; i++) decimal1 += '0';
            }
            string result = AddInteger(decimal1, decimal2);
            if (need == 0) return result;
            return result.Insert(result.Length - need, ".");
        }

        public static string SubtractDecimal(string decimal1, string decimal2)
        {
            int need1 = ConvertDecimal(ref decimal1);
            int need2 = ConvertDecimal(ref decimal2);
            int need = 0;
            if (need1 > need2)
            {
                need = need1;
                int temp = need1 - need2;
                for (int i = 0; i < temp; i++) decimal2 += '0';
            }
            else
            {
                need = need2;
                int temp = need2 - need1;
                for (int i = 0; i < temp; i++) decimal1 += '0';
            }
            string result = SubtractInteger(decimal1, decimal2);
            if (need == 0) return result;
            return result.Insert(result.Length - need, ".");
        }

        public static string MutipilationDecimal(string decimal1, string decimal2)
        {
            int need1 = ConvertDecimal(ref decimal1);
            int need2 = ConvertDecimal(ref decimal2);
            int need = need1 + need2;
            string result = MutipilationInteger(decimal1, decimal2);
            if (need == 0) return result;
            return result.Insert(result.Length - need, ".");
        }

        public static string DivisionDecimal(string decimal1, string decimal2, int accuracy)
        {
            int need1 = ConvertDecimal(ref decimal1);
            int need2 = ConvertDecimal(ref decimal2);
            if (need1 > need2)
            {
                int temp = need1 - need2;
                for (int i = 0; i < temp; i++) decimal2 += '0';
            }
            else
            {
                int temp = need2 - need1;
                for (int i = 0; i < temp; i++) decimal1 += '0';
            }
            string remainder = "";
            string result = DivisionInteger(decimal1, decimal2, out remainder);
            if (accuracy == 0 || remainder == "0") return result;
            for (int i = 0; i < accuracy; i++) remainder += '0';
            string sTemp = DivisionInteger(remainder, decimal2);
            while (sTemp.Length < accuracy) sTemp = '0' + sTemp;
            return result + '.' + sTemp;
        }
    }
}
