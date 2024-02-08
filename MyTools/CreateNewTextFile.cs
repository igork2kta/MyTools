using SHDocVw;
using System.Runtime.InteropServices;
using System.Text;

namespace MyTools
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
            GravaLog.Gravar("Obtendo janela");
            // get the active window
            IntPtr handle = GetForegroundWindow();

            GravaLog.Gravar("Obtendo sei la o que");
            // Required ref: SHDocVw (Microsoft Internet Controls COM Object) - C:\Windows\system32\ShDocVw.dll
            ShellWindows shellWindows = new SHDocVw.ShellWindows();

            // loop through all windows
            foreach (InternetExplorer window in shellWindows)
            {
                // match active window
                if (window.HWND == (int)handle)
                {
                    // Required ref: Shell32 - C:\Windows\system32\Shell32.dll
                    var shellWindow = window.Document as Shell32.IShellFolderViewDual2;

                    // will be null if you are in Internet Explorer for example
                    if (shellWindow != null)
                    {
                        // Item without an index returns the current object
                        var currentFolder = shellWindow.Folder.Items().Item();

                        // special folder - use window title
                        // for some reason on "Desktop" gives null
                        if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                        {
                            // Get window title instead
                            const int nChars = 256;
                            StringBuilder Buff = new StringBuilder(nChars);
                            if (GetWindowText(handle, Buff, nChars) > 0)
                            {
                                return Buff.ToString();
                            }
                        }
                        else
                        {
                            return currentFolder.Path;
                        }
                    }

                    break;
                }
            }

            return null;
        }

        public static void Criar()
        {
            string caminho = GetActiveExplorerPath();
            if (caminho == null)
            {
                GravaLog.Gravar("Erro ao obter caminho");
                return;
            }

            //Console.WriteLine(caminho);


            if (!File.Exists(caminho + "\\Novo Documento de Texto.txt"))
                using (File.Create(caminho + "\\Novo Documento de Texto.txt")) ;

            else
            {
                for (int i = 1; i < 50; i++)
                    if (!File.Exists(caminho + $"\\Novo Documento de Texto ({i}).txt"))
                    {
                        using (File.Create(caminho + $"\\Novo Documento de Texto ({i}).txt"));
                        return;
                    }
            }
        }
    }
}
