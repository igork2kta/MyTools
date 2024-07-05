using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace MyTools.Classes
{
    public static class TextUnformatter
    {
        public static void UnformatText()
        {
            //Obtém o texto da área de transferencia
            string clipboardText = Clipboard.GetText();


            clipboardText = Regex.Replace(clipboardText, @"[\t\r]", "");
            clipboardText = Regex.Replace(clipboardText, @"[\n]", " ");

            Clipboard.SetText(clipboardText);
            AtalhoCtrlV.Disparar();
            //Notification.SendNotification("Pronto!", "Texto sem formatação copiado para sua área de transferência!");
        }

        public static class AtalhoCtrlV
        {
            // Estrutura para definir um evento de entrada
            [StructLayout(LayoutKind.Sequential)]
            struct INPUT
            {
                public uint type;
                public InputUnion u;
            }

            // União de entrada de teclas
            [StructLayout(LayoutKind.Explicit)]
            struct InputUnion
            {
                [FieldOffset(0)]
                public MOUSEINPUT mi;
                [FieldOffset(0)]
                public KEYBDINPUT ki;
                [FieldOffset(0)]
                public HARDWAREINPUT hi;
            }

            // Estrutura para definir uma entrada de teclado
            [StructLayout(LayoutKind.Sequential)]
            struct KEYBDINPUT
            {
                public ushort wVk;
                public ushort wScan;
                public uint dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            // Estrutura para definir uma entrada de mouse (não usada aqui)
            [StructLayout(LayoutKind.Sequential)]
            struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public uint mouseData;
                public uint dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            // Estrutura para definir uma entrada de hardware (não usada aqui)
            [StructLayout(LayoutKind.Sequential)]
            struct HARDWAREINPUT
            {
                public uint uMsg;
                public ushort wParamL;
                public ushort wParamH;
            }

            // Declaração da função SendInput da API do Windows
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

            // Constantes para definir tipos de entrada e teclas
            const uint INPUT_KEYBOARD = 1;
            const uint KEYEVENTF_KEYUP = 0x0002;
            const ushort VK_CONTROL = 0x11;
            const ushort VK_V = 0x56;

            public static void Disparar()
            {
                // Cria um array de eventos de entrada
                INPUT[] inputs = new INPUT[]
                {
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion {
                        ki = new KEYBDINPUT {
                            wVk = VK_CONTROL
                        }
                    }
                },
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion {
                        ki = new KEYBDINPUT {
                            wVk = VK_V
                        }
                    }
                },
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion {
                        ki = new KEYBDINPUT {
                            wVk = VK_V,
                            dwFlags = KEYEVENTF_KEYUP
                        }
                    }
                },
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    u = new InputUnion {
                        ki = new KEYBDINPUT {
                            wVk = VK_CONTROL,
                            dwFlags = KEYEVENTF_KEYUP
                        }
                    }
                }
                };

                // Envia os eventos de entrada
                SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
            }
        }
    }
}
