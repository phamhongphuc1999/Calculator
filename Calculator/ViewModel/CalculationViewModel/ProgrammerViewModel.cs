using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel.CalculationViewModel
{
  public class ProgrammerViewModel : CalculationViewModel
  {
    public ICommand CCommand { get; set; }

    public ProgrammerViewModel() : base()
    {
      InitializeCCommand();
    }

    private void InitializeCCommand()
    {
      CCommand = new RelayCommand<Button>(
          sender => { return true; }, sender =>
          {

          });
    }
  }
}
