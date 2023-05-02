using static Calculator.Constance;

namespace Calculator.DisplayService
{
  public class DisplayManager
  {
    private string currentDisplayText;
    public DisplayManager()
    {
      currentDisplayText = "";
    }

    public string BasicDisplay(string currentElement, string function)
    {
      currentDisplayText = currentElement + BASIC_FUNCTIONS[function];
      return currentDisplayText;
    }

    public string CalculationDisplay(string currentElement, string previousElement, string function)
    {
      currentDisplayText = previousElement + BASIC_FUNCTIONS[function] + currentElement + BASIC_FUNCTIONS["calculation"];
      return currentDisplayText;

    }
  }
}
