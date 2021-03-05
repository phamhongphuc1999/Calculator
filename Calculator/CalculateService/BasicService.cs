namespace Calculator.CalculateService
{
    class BasicService
    {
        public static string Add(string number1, string number2)
        {
            string result = "";
            int rememmber = 0;
            int index1 = number1.Length - 1;
            int index2 = number2.Length - 1;
            while (index1 >= 0 && index2 >= 0)
            {
                int num1 = number1[index1] - '0';
                int num2 = number2[index2] - '0';
                int sum = num1 + num2 + rememmber;
                result = (sum / 10 + '0') + result;
                rememmber = sum % 10;
                index1--; index2--;
            }
            while(index1 >= 0)
            {
                int sum = number1[index1] + rememmber;
                result = (sum / 10 + '0') + result;
                rememmber = sum % 10;
                index1--;
            }
            while (index2 >= 0)
            {
                int sum = number2[index2] + rememmber;
                result = (sum / 10 + '0') + result;
                rememmber = sum % 10;
                index2--;
            }
            return result;
        }
    }
}
