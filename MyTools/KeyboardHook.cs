using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace MyTools
{
    public class ShortcutKey
    {
        public Keys Key { get; set; }
        public bool Control { get; set; }
        public bool Alt { get; set; }
        public bool Shift { get; set; }
        [JsonIgnore]
        public EventHandler EventHandler { get; set; }
        public bool Active { get; set; }
    }
    public class KeyboardHook
    {
        // Constantes para identificar o tipo de gancho de teclado e mensagens de teclado (têm significados específicos na API do Windows)
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        // Delegado para a função de callback de baixo nível do teclado
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        // Lista de atalhos de teclado a serem monitorados
        public static List<ShortcutKey> Shortcuts { get; private set; }

        // Método para iniciar o gancho de teclado
        public static void Start(List<ShortcutKey> shortcuts)
        {
            Shortcuts = shortcuts;
            _hookID = SetHook(_proc); // Define o gancho de teclado
        }

        // Método para parar o gancho de teclado
        public static void Stop()
        {
            UnhookWindowsHookEx(_hookID); // Remove o gancho de teclado
        }

        // Delegado que define a assinatura da função de callback de baixo nível do teclado
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Método para configurar o gancho de teclado
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            // Obtém o identificador do módulo do processo atual
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                // Define o gancho de teclado usando a função SetWindowsHookEx
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        // Função de callback que será chamada sempre que uma tecla for pressionada ou liberada
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Verifica se a mensagem é um evento de tecla pressionada ou liberada
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_KEYUP))
            {
                // Obtém o código da tecla pressionada
                int vkCode = Marshal.ReadInt32(lParam);

                // Itera sobre todos os atalhos registrados
                foreach (var shortcut in Shortcuts)
                {
                    // Converte o código da tecla para o tipo Keys
                    Keys key = (Keys)vkCode;

                    // Verifica se a tecla e os modificadores estão corretos
                    bool correctKey = key == shortcut.Key;
                    bool correctModifiers =
                        Control.ModifierKeys.HasFlag(Keys.Control) == shortcut.Control &&
                        Control.ModifierKeys.HasFlag(Keys.Alt) == shortcut.Alt &&
                        Control.ModifierKeys.HasFlag(Keys.Shift) == shortcut.Shift;

                    // Se a tecla e os modificadores estiverem corretos e for uma tecla liberada
                    if (correctKey && correctModifiers && wParam == (IntPtr)WM_KEYUP)
                    {
                        // Chama o manipulador de eventos associado ao atalho
                        shortcut.EventHandler?.Invoke(null, EventArgs.Empty);
                    }
                }
            }
            // Chama a próxima função do gancho de teclado na cadeia
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        // Importações de funções da user32.dll e kernel32.dll para configurar e remover o gancho de teclado
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }

}
