using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;

namespace MyTools.Classes
{
    public static class AutoStartManager
    {
        
        private static readonly RegistryKey? Reg = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        

        private const string TaskName = "MyTools_AutoStart"; // Nome da tarefa no Agendador

        public static bool SetAutoStart(bool option, int delay)
        {
            if(delay > 0)
            {
                if (!IsRunningAsAdministrator())
                {
                    MessageBox.Show("Para configurar/remover inicialização com delay, é necessária permissão de administrador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (option)
                    return CreateScheduledTask(delay);
                else
                    return DeleteScheduledTask();

            }
            else
            {
                if (option) {
                    Reg?.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
                    return true;
                }
                else
                {
                    if (TaskExists()) 
                    {
                        if(IsRunningAsAdministrator()) 
                            DeleteScheduledTask();
                        else
                        {
                            MessageBox.Show("Existe uma task de inicialização com delay configurada, para remover é necessária permissão de administrador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                        }
                    } 

                    Reg?.DeleteValue(Application.ProductName);
                }
                    

                return true;
            }

            
        }

        private static bool CreateScheduledTask(int delay)
        {
            try
            {
                //Apaga o registro se existir
                Reg?.DeleteValue(Application.ProductName);

                string exePath = Application.ExecutablePath;
                string arguments = $@"/Create /F /RL HIGHEST /SC ONLOGON /TN ""{TaskName}"" /TR ""\""{exePath}\"""" /DELAY 0000:{delay}";

                ProcessStartInfo psi = new ProcessStartInfo("schtasks", arguments)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Verb = "runas" // executa como administrador
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        MessageBox.Show($"Erro: {error}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    else
                    {
                        MessageBox.Show($"Inicialização automatica registrada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool DeleteScheduledTask()
        {
            try
            {
                Reg?.DeleteValue(Application.ProductName);

                string arguments = $@"/Delete /F /TN ""{TaskName}""";
                ProcessStartInfo psi = new ProcessStartInfo("schtasks", arguments)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Verb = "runas"
                };

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        MessageBox.Show($"Erro: {error}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    else
                    {
                        MessageBox.Show($"Inicialização automatica CANCELADA com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover tarefa agendada: {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool TaskExists()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("schtasks", $"/Query /TN \"{TaskName}\"")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // Se a saída contém o nome da tarefa, ela existe
                    return output.Contains(TaskName, StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsRunningAsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

    }
}
