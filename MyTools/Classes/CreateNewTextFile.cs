using SHDocVw;
using System.Runtime.InteropServices;
using System.Text;

namespace MyTools.Classes
{
    public class CreateNewTextFile
    {
        // COM Imports
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        static string GetActiveExplorerPath()
        {
            // get the active window
            IntPtr handle = GetForegroundWindow();

            // Required ref: SHDocVw (Microsoft Internet Controls COM Object) - C:\Windows\system32\ShDocVw.dll
            ShellWindows shellWindows = new();

            // loop through all windows
            foreach (InternetExplorer window in shellWindows)
            {
                // match active window
                if (window.HWND == (int)handle)
                {
                    // Required ref: Shell32 - C:\Windows\system32\Shell32.dll
                    // Shell32.IShellFolderViewDual2? shellWindow = window.Document as Shell32.IShellFolderViewDual2;

                    // will be null if you are in Internet Explorer for example
                    if (window.Document is Shell32.IShellFolderViewDual2 shellWindow)
                    {
                        // Item without an index returns the current object
                        Shell32.FolderItem currentFolder = shellWindow.Folder.Items().Item();

                        // special folder - use window title
                        // for some reason on "Desktop" gives null
                        if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                        {
                            // Get window title instead
                            const int nChars = 256;
                            StringBuilder Buff = new(nChars);
                            if (GetWindowText(handle, Buff, nChars) > 0)
                                return Buff.ToString();

                        }
                        else
                            return currentFolder.Path;
                    }
                    break;
                }
            }
            return "";
        }

        public static void Criar()
        {
            string caminho = GetActiveExplorerPath();

            if (string.IsNullOrEmpty(caminho))
                return;

            string nomeArquivo = "Novo Documento de Texto.txt";

            // Verifica se o arquivo base já existe
            string caminhoCompleto = Path.Combine(caminho, nomeArquivo);
            if (!File.Exists(caminhoCompleto))
            {
                File.Create(caminhoCompleto).Close();
                return;
            }


            // Procura um nome alternativo
            for (int i = 1; i < 50; i++)
            {
                string caminhoAlternativo = Path.Combine(caminho, $"Novo Documento de Texto ({i}).txt");
                if (!File.Exists(caminhoAlternativo))
                {
                    File.Create(caminhoAlternativo).Close();
                    return;
                }
            }
        }
    }
}
