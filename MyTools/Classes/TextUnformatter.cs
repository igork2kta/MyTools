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

            if (string.IsNullOrEmpty(clipboardText)) return "";

            clipboardText = Regex.Replace(clipboardText, @"[\t\r]", "");
            clipboardText = Regex.Replace(clipboardText, @"[\n]", " ");
            try
            {
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
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro", $"Erro ao executar atalho: {ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            
        }

        public static void TextoPadrao(string texto)
        {
            Console.WriteLine("TEXT UNFORMATTER");
            string input = UnformatText(false);

            if (string.IsNullOrEmpty(input)) return;

            long chamado;

            long.TryParse(input, out chamado);

            Clipboard.SetText(String.Format(texto, chamado));
            AtalhoCtrlV.Disparar();
            Thread.Sleep(100);
        }
       
    }
}
