using Calculator.Model;
using Newtonsoft.Json;
using System.IO;

namespace Calculator.DataService
{
  public class StorageManager
  {
    public StorageManager()
    {
      InitializeConfiguration();
    }

    private void InitializeConfiguration()
    {
      using (StreamReader sr = File.OpenText(Constance.CONFIG_URL))
      {
        string data = sr.ReadToEnd();
        ConfigEntity configEntity = JsonConvert.DeserializeObject<ConfigEntity>(data);
        Config.SECTION = configEntity.section;
      }
    }

    public void SaveConfiguration()
    {
      ConfigEntity configEntity = new ConfigEntity
      {
        section = Config.SECTION
      };
      StreamWriter sw = new StreamWriter(Constance.CONFIG_URL);
      string data = JsonConvert.SerializeObject(configEntity);
      sw.WriteLine(data);
      sw.Close();
    }
  }
}
