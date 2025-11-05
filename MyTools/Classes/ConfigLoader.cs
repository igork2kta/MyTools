using System.Text.Json;
using static MyTools.Classes.OSwitch;

namespace MyTools.Classes
{
    public static class ConfigLoader
    {
        private const string ConfigFileName = "commands.json";
        private const string DevicesFileName = "devices.json";

        private static readonly string ConfigFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Application.ProductName,
            ConfigFileName);

        private static readonly string DevicesFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Application.ProductName,
            DevicesFileName);

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

        public static List<string> LoadSelectedDeviceIds()
        {
            if (!File.Exists(DevicesFilePath)) return new List<string>();
            try
            {
                var json = File.ReadAllText(DevicesFilePath);
                return JsonSerializer.Deserialize<Config>(json)?.SelectedDeviceIds ?? new List<string>();
            }
            catch { return new List<string>(); }
        }

        public static void SaveSelectedDeviceIds(Config devices)
        {
            string directoryPath = Path.GetDirectoryName(DevicesFilePath);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            try
            {
                var options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(devices, options);
                File.WriteAllText(DevicesFilePath, jsonString);

                MessageBox.Show("Salvo com sucesso!", "Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
