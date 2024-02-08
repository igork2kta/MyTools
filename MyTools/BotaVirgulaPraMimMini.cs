namespace MyTools
{
    public static class BotaVirgulaPraMimMini
    {
        public static void Executar()
        {
            //Obtém o texto da área de transferencia
            string[] split = Clipboard.GetText().Split('\n');

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = split[i].Replace("\r", "");

                //Aspas
                if (!string.IsNullOrEmpty(split[i])) split[i] = "'" + split[i] + "'";

                //Vírgula
                //Não coloca vírgula no ultimo
                if (i != split.Length - 1 && !string.IsNullOrEmpty(split[i + 1]))
                     split[i] += ",\n";
                
            }

            Clipboard.SetText(string.Join("", split));

            NotifyIcon notifyIcon = new () 
            { 
                Icon = SystemIcons.Information, 
                Visible = true 
            };

            notifyIcon.ShowBalloonTip(3000, "Pronto!", "Texto com vírgula copiado para sua área de transferência!", ToolTipIcon.Info);

            // Esperar um pouco antes de fechar o programa
            //System.Threading.Thread.Sleep(5000);

            // Limpar e fechar o objeto NotifyIcon
            notifyIcon.Dispose();

        }
    }
}
