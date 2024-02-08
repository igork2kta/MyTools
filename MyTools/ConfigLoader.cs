using System.Text.Json;

namespace MyTools
{
    public static class ConfigLoader
    {
        public static List<ShortcutKey>  LoadConfig()
        {
            string jsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\commands.json");
            
            if (string.IsNullOrEmpty(jsonString)) return new List<ShortcutKey>();
            
            else return JsonSerializer.Deserialize<List<ShortcutKey>>(jsonString);
        }

        public static void SaveConfig(List<ShortcutKey> shortcuts)
        {

            string jsonString = JsonSerializer.Serialize(shortcuts);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\commands.json", jsonString);
            //CarregarComandos();

            //MessageBox.Show("Salvo com sucesso!", "Sucesso!");
        }
    }
}
