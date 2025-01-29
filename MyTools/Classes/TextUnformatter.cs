using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace MyTools.Classes
{
    public static class TextUnformatter
    {
        public static string UnformatText(bool disparaAtalho = true)
        {
            //Obtém o texto da área de transferencia
            string clipboardText = Clipboard.GetText();


            clipboardText = Regex.Replace(clipboardText, @"[\t\r]", "");
            clipboardText = Regex.Replace(clipboardText, @"[\n]", " ");

            if (disparaAtalho)
            {
                Clipboard.SetText(clipboardText);
                AtalhoCtrlV.Disparar();
                return string.Empty;
            }
            else
            {
                return clipboardText;
            }

            //Notification.SendNotification("Pronto!", "Texto sem formatação copiado para sua área de transferência!");
        }

        public static void TextoPadrao(string texto)
        {

            string input = UnformatText(false);

            long chamado;

            long.TryParse(input, out chamado);

            Clipboard.SetText(String.Format(texto, chamado));
            AtalhoCtrlV.Disparar();

        }
       
    }
}
