using System.Text;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace MyTools.Classes
{
    public static class BotaVirgulaPraMimMini
    {
        public static void Executar()
        {
            //Obtém o texto da área de transferencia
            string clipboardText = Clipboard.GetText();
            
            if (string.IsNullOrEmpty(clipboardText))
                return;
            
            string[] split = clipboardText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < split.Length; i++)
            {
                resultBuilder.Append($"'{split[i]}'");
                //insere virgula menos no ultimo
                if (i < split.Length - 1)
                    resultBuilder.Append(",\n");
            }

            Clipboard.SetText(resultBuilder.ToString());

            using NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };

            notifyIcon.ShowBalloonTip(3000, "Pronto!", "Texto com vírgula copiado para sua área de transferência!", ToolTipIcon.Info);

        }
    }
}
