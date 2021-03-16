﻿namespace Calculator.CalculateService
{
    public static class CalculateUtilities
    {
        public static string StandardizedDisplay(string element)
        {
            while (element[0] == '0') element = element.Substring(1);
            int index = element.IndexOf('.');
            int length = element.Length - 1;
            if (index == length) element = element.Substring(0, length);
            else if (index == 0) element = '0' + element;
            else if(index > 0)
            {
                int indexZero = index + 1;
                bool check = false;
                for(int i = index + 1; i <= length; i++)
                {
                    if (element[i] == '0')
                    {
                        indexZero = i;
                        check = true;
                    }
                    else check = false;
                }
                if (check) element = element.Substring(0, indexZero);
            }
            return element;
        }

        public static int ConvertDecimal(ref string dec)
        {
            int length = dec.Length;
            int index = dec.IndexOf('.');
            if (index < 0) return 0;
            string[] temp = dec.Split('.');
            if (temp.Length > 1) dec = temp[0] + temp[1];
            return length - index - 1;
        }
    }
}
