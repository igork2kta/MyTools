using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools.Classes
{
    public static class WhereMount
    {
        public static void Executar()
        {
            //Obtém o texto da área de transferencia
            string clipboardText = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboardText))
                return;

            string[] split = clipboardText.Split(',', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < split.Length; i++)
            {
                resultBuilder.Append($"{split[i]}");
                //insere virgula menos no ultimo
                if (i < split.Length - 1)
                    resultBuilder.Append($" = :{split[i]} AND");
                else
                    resultBuilder.Append($" = :{split[i]}");
            }

            Clipboard.SetText(resultBuilder.ToString());
            AtalhoCtrlV.Disparar();

            //Notification.SendNotification("Pronto!", "Texto com vírgula copiado para sua área de transferência!");

        }
    }
}
