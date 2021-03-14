using Calculator.View.DateCalculationWindow;
using Calculator.View.GraphingWindow;
using Calculator.View.ProgrammerWindow;
using Calculator.View.ScientificWindow;
using Calculator.View.StandardWindow;
using System.Windows.Controls;
using System;

namespace Calculator
{
    public class Routes
    {
        private ProgrammerWindow programmerWindow;
        private StandardWindow standardWindow;
        private ScientificWindow scientificWindow;
        private DateCalculationWindow dateCalculationWindow;
        private GraphingWindow graphingWindow;

        private event EventHandler routeingEvent;
        public event EventHandler RoutingEvent
        {
            add { routeingEvent += value; }
            remove { routeingEvent -= value; }
        }

        public Routes()
        {
            standardWindow = new StandardWindow();
            scientificWindow = new ScientificWindow();
            programmerWindow = new ProgrammerWindow();
            dateCalculationWindow = new DateCalculationWindow();
            graphingWindow = new GraphingWindow();
        }

        public UserControl Routing(int index)
        {
            switch (index)
            {
                case 1:
                    routeingEvent(standardWindow, new EventArgs());
                    return standardWindow;
                case 2:
                    routeingEvent(scientificWindow, new EventArgs());
                    return scientificWindow;
                case 3:
                    routeingEvent(graphingWindow, new EventArgs());
                    return graphingWindow;
                case 4:
                    routeingEvent(programmerWindow, new EventArgs());
                    return programmerWindow;
                case 5:
                    routeingEvent(dateCalculationWindow, new EventArgs());
                    return dateCalculationWindow;
                default:
                    return standardWindow;
            }
        }
    }
}
