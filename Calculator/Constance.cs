using Calculator.Model;
using System.Collections.Generic;

namespace Calculator
{
    public static class Constance
    {
        public static readonly List<LeftSideBarItem> LEFT_ITEM = new List<LeftSideBarItem>
        {
            new LeftSideBarItem{ItemIcon = "", ItemTitle = "Calculator", Visibility = false},
            new LeftSideBarItem{ItemIcon = "Calculator", ItemTitle = "Standard", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Atom", ItemTitle = "Scientific", Visibility = true},
            new LeftSideBarItem{ItemIcon = "ChartAreaspline", ItemTitle = "Graphing", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Xml", ItemTitle = "Programmer", Visibility = true},
            new LeftSideBarItem{ItemIcon = "CalendarRange", ItemTitle = "Date Calculation", Visibility = true},
            new LeftSideBarItem{ItemIcon = "", ItemTitle = "Converter", Visibility = false},
            new LeftSideBarItem{ItemIcon = "Cash", ItemTitle = "Currency", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Cube", ItemTitle = "Volume", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Ruler", ItemTitle = "Length", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Weight", ItemTitle = "Weight and Mass", Visibility = true},
            new LeftSideBarItem{ItemIcon = "CoolantTemperature", ItemTitle = "Temperature", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Fire", ItemTitle = "Energy", Visibility = true},
            new LeftSideBarItem{ItemIcon = "TextureBox", ItemTitle = "Area", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Run", ItemTitle = "Speed", Visibility = true},
            new LeftSideBarItem{ItemIcon = "ClockTimeThreeOutline", ItemTitle = "Time", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Flash", ItemTitle = "Power", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Database", ItemTitle = "Data", Visibility = true},
            new LeftSideBarItem{ItemIcon = "Speedometer", ItemTitle = "Pressure", Visibility = true},
            new LeftSideBarItem{ItemIcon = "AngleAcute", ItemTitle = "Angle", Visibility = true}
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
