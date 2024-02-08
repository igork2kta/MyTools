using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    public static class BotaVirgulaPraMimMini
    {
        public static void executar()
        {
            String[] split = Clipboard.GetText().Split('\n');

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = split[i].Replace("\r", "");


                //Aspas
                if (!string.IsNullOrEmpty(split[i])) split[i] = "'" + split[i] + "'";

                //Vírgula
                if (i != split.Length - 1 && !string.IsNullOrEmpty(split[i + 1]))
                {
                        split[i] += ",\n";
                }
            }

            Clipboard.SetText(string.Join("", split));

            // Criar um objeto NotifyIcon
            NotifyIcon notifyIcon = new NotifyIcon();

            // Definir o ícone e o texto da notificação
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;

            // Exibir a notificação por um período de tempo
            notifyIcon.ShowBalloonTip(3000, "Pronto!", "Texto com vírgula copiado para sua área de transferência!", ToolTipIcon.Info);

            // Esperar um pouco antes de fechar o programa
            System.Threading.Thread.Sleep(5000);

            // Limpar e fechar o objeto NotifyIcon
            notifyIcon.Dispose();

        }
    }
}
