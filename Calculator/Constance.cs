using System.Collections.Generic;

namespace Calculator
{
    public static class Constance
    {
        public static readonly string[] MAIN_LIST_TITLE = new string[]
        {
            "Calculator",
            "Standard",
            "Scientific",
            "Graphing",
            "Programmer",
            "Date Calculation",
            "Converter",
            "Currency",
            "Volume",
            "Length",
            "Weight and Mass",
            "Temperature",
            "Energy",
            "Area",
            "Speed",
            "Time",
            "Power",
            "Data",
            "Pressure",
            "Angle"
        };

        public static readonly Dictionary<string, char> BASIC_FUNCTIONS = new Dictionary<string, char>
        {
            { "devision", '÷' },
            {"mutipilation", 'x' },
            {"subtract", '-' },
            {"add", '+' }
        };
    }
}
