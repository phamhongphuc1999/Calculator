namespace Calculator
{
    public static class Utilities
    {
        public static void StandardizedDisplay(ref string element)
        {
            if (element[0] == '.') element = '0' + element;
            int length = element.Length - 1;
            if (element[length] == '.') element = element.Substring(0, length);
        }
    }
}
