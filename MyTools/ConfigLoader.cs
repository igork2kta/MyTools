using System.Text.Json;

namespace MyTools
{
    public static class ConfigLoader
    {
        public static string AppData { get; } = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);
        public static string ConfigPath { get; } = Path.Combine(AppData, Application.ProductName);
        public static string ConfigFileName { get; } = "\\commands.json";
        
        public static List<ShortcutKey> LoadConfig()
        {
            if (File.Exists(ConfigPath + ConfigFileName))
            {
                string jsonString = File.ReadAllText(ConfigPath + ConfigFileName);
                
                if (string.IsNullOrEmpty(jsonString)) return new List<ShortcutKey>();
                
                else return JsonSerializer.Deserialize<List<ShortcutKey>>(jsonString);
            }

            return new List<ShortcutKey>();
        }
               
        public static void SaveConfig(List<ShortcutKey> shortcuts)
        {
            new FileInfo(ConfigPath + ConfigFileName).Directory?.Create();
            try
            {
                File.WriteAllText(ConfigPath + ConfigFileName, JsonSerializer.Serialize(shortcuts));
                MessageBox.Show("Salvo com sucesso!", "Sucesso!");
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.ToString(), "Falha ao salvar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
