namespace Calculator.CalculateService
{
    class BasicService
    {
        public static string AddInteger(string number1, string number2)
        {
            bool sign1 = number1[0] == '-';
            bool sign2 = number2[0] == '-';
            if (sign1 && sign2) return '-' + AddInteger(number1.Substring(1), number2.Substring(1));
            else if (sign1 && !sign2) return SubtractInteger(number2, number1.Substring(1));
            else if (!sign1 && sign2) return SubtractInteger(number1, number2.Substring(1));
            string result = "";
            int rememmber = 0;
            int index1 = number1.Length - 1;
            int index2 = number2.Length - 1;
            while (index1 >= 0 && index2 >= 0)
            {
                int num1 = number1[index1] - '0';
                int num2 = number2[index2] - '0';
                int sum = num1 + num2 + rememmber;
                result = (char)(sum % 10 + '0') + result;
                rememmber = sum / 10;
                index1--; index2--;
            }
            while (index1 >= 0)
            {
                int sum = number1[index1] - '0' + rememmber;
                result = (char)(sum % 10 + '0') + result;
                rememmber = sum / 10;
                index1--;
            }
            while (index2 >= 0)
            {
                int sum = number2[index2] - '0' + rememmber;
                result = (char)(sum % 10 + '0') + result;
                rememmber = sum / 10;
                index2--;
            }
            if (rememmber == 1) return '1' + result;
            return result;
        }

        private static bool IsSmaller(string number1, string number2)
        {
            int index1 = number1.Length - 1;
            int index2 = number2.Length - 1;
            if (index1 < index2) return true;
            else if (index1 == index2)
            {
                int temp = index1;
                while (temp >= 0)
                    if (number1[temp] == number2[temp]) temp--;
                    else
                    {
                        if (number1[temp] < number2[temp]) return true;
                        break;
                    }
            }
            return false;
        }

        public static string SubtractInteger(string number1, string number2)
        {
            bool sign1 = number1[0] == '-';
            bool sign2 = number2[0] == '-';
            if (sign1 && sign2) return SubtractInteger(number2, number1);
            else if (sign1 && !sign2) return '-' + AddInteger(number1.Substring(1), number2);
            else if (!sign1 && sign2) return AddInteger(number1, number2.Substring(1));
            bool isSign = IsSmaller(number1, number2);
            int rememmber = 0;
            string result = "";
            string element1 = number1, element2 = number2;
            if (isSign)
            {
                element1 = number2;
                element2 = number1;
            }
            int index1 = element1.Length - 1;
            int index2 = element2.Length - 1;
            while (index1 >= 0 && index2 >= 0)
            {
                int num1 = element1[index1] - '0';
                int num2 = element2[index2] - '0';
                int subtract = num1 - num2 - rememmber;
                if (subtract < 0)
                {
                    subtract = 10 + subtract;
                    rememmber = 1;
                }
                else rememmber = 0;
                result = (char)(subtract + '0') + result;
                index1--; index2--;
            }
            while (index1 >= 0)
            {
                int subtract = element1[index1] - '0' - rememmber;
                if (subtract < 0)
                {
                    subtract = 10 + subtract;
                    rememmber = 1;
                }
                else rememmber = 0;
                result = (char)(subtract + '0') + result;
                index1--;
            }
            if (isSign) return '-' + result;
            return result;
        }

        //public static string AddReal(string number1, string number2)
        //{
        //    string[] element1 = number1.Split('.');
        //}

        //public static string SubtractReal(string number1, string number2)
        //{

        //}
    }
}
