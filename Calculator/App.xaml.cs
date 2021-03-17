using Calculator.DataService;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static StorageManager storageManager;

        public App()
        {
            storageManager = new StorageManager();
        }
    }
}
