using System.Text.Json;

namespace MyTools.Classes
{
    public static class ConfigLoader
    {
        private const string ConfigFileName = "commands.json";
        private static readonly string ConfigFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Application.ProductName,
            ConfigFileName);

        public static List<ShortcutKey> LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                string jsonString = File.ReadAllText(ConfigFilePath);
                if (string.IsNullOrEmpty(jsonString))
                    return new List<ShortcutKey>();

                return JsonSerializer.Deserialize<List<ShortcutKey>>(jsonString);
            }
            return new List<ShortcutKey>();
        }

        public static void SaveConfig(List<ShortcutKey> shortcuts)
        {
            string directoryPath = Path.GetDirectoryName(ConfigFilePath);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            try
            {
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(shortcuts, options);
                File.WriteAllText(ConfigFilePath, jsonString);

                MessageBox.Show("Salvo com sucesso!", "Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
