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

            Notification.SendNotification("Pronto!", "Texto sem formatação copiado para sua área de transferência!");
        }
    }
}
