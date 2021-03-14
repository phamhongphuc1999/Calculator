using Calculator.View.DateCalculationWindow;
using Calculator.View.GraphingWindow;
using Calculator.View.ProgrammerWindow;
using Calculator.View.ScientificWindow;
using Calculator.View.StandardWindow;
using Calculator.View.CurrencyWindow;
using System.Windows.Controls;
using System;

namespace Calculator
{
    public class EventArgsRoute: EventArgs
    {
        public int index { get; private set; }

        public EventArgsRoute(int index): base()
        {
            this.index = index;
        }
    }

    public class Routes
    {
        private ProgrammerWindow programmerWindow;
        private StandardWindow standardWindow;
        private ScientificWindow scientificWindow;
        private DateCalculationWindow dateCalculationWindow;
        private GraphingWindow graphingWindow;
        private CurrencyWindow currencyWindow;

        private event EventHandler<EventArgsRoute> routeingEvent;
        public event EventHandler<EventArgsRoute> RoutingEvent
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
            currencyWindow = new CurrencyWindow();
        }

        public UserControl Routing(int index)
        {
            EventArgsRoute e = new EventArgsRoute(index);
            switch (index)
            {
                case 1:
                    routeingEvent(standardWindow, e);
                    return standardWindow;
                case 2:
                    routeingEvent(scientificWindow, e);
                    return scientificWindow;
                case 3:
                    routeingEvent(graphingWindow, e);
                    return graphingWindow;
                case 4:
                    routeingEvent(programmerWindow, e);
                    return programmerWindow;
                case 5:
                    routeingEvent(dateCalculationWindow, e);
                    return dateCalculationWindow;
                case 7:
                    routeingEvent(currencyWindow, e);
                    return currencyWindow;
                default:
                    return standardWindow;
            }
        }
    }
}
