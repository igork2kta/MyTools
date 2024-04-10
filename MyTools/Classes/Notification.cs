namespace MyTools.Classes
{
    public static class Notification
    {
        private static NotifyIcon notifyIcon = new NotifyIcon
        {
            Icon = SystemIcons.Information,
            Visible = true
        };
        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
        {
            Interval = 3000
        };

        public static void SendNotification(string title, string text)
        {
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000, title, text, ToolTipIcon.Info);

            //Necessário um timer pois sem ele a notificação fica com um título estranho
            timer.Tick += (sender, e) =>
            {
                notifyIcon.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }
    }
}
