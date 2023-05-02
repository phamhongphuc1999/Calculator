using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.ViewModel.CalculationViewModel
{
  public class StandardViewModel : CalculationViewModel
  {
    public ICommand CECommand { get; set; }
    public ICommand CCommand { get; set; }

    public StandardViewModel() : base()
    {
      InitializeCECommand();
      InitializeCCommand();
    }

    private void InitializeCECommand()
    {
      CECommand = new RelayCommand<Button>(
          sender => { return true; }, sender =>
          {

          });
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
