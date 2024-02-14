using System;
using System.Windows.Forms;

namespace MyTools.Classes
{
    public  class AlwaysPresent
    {
        static System.Windows.Forms.Timer mouseMoveTimer;
        public void Start()
        {
            // Inicializa o Timer para mover o mouse a cada 5 minutos
            mouseMoveTimer = new System.Windows.Forms.Timer();
            mouseMoveTimer.Interval = 5 * 60 * 1000; // 5 minutos em milissegundos
            mouseMoveTimer.Tick += MouseMoveTimer_Tick;
            mouseMoveTimer.Start();

            using NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };

            notifyIcon.ShowBalloonTip(3000, "Pronto!", "Sempre ativo em execução, vá fazer o que precisa!", ToolTipIcon.Info);


        }

        public void Stop()
        {
            StopMouseMove();
        }

        static void MouseMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveMouse();
        }

        static void MoveMouse()
        {
            // Define as coordenadas para onde o mouse será movido
            int newX = Cursor.Position.X + 1; // Exemplo de movimento horizontal
            int newY = Cursor.Position.Y + 1; // Exemplo de movimento vertical

            // Move o mouse para as novas coordenadas
            Cursor.Position = new System.Drawing.Point(newX, newY);
        }

        static void StopMouseMove()
        {
            // Para o Timer
            if(mouseMoveTimer != null)
            {
                mouseMoveTimer.Stop();
                mouseMoveTimer.Dispose();

                using NotifyIcon notifyIcon = new NotifyIcon
                {
                    Icon = SystemIcons.Information,
                    Visible = true
                };

                notifyIcon.ShowBalloonTip(3000, "Pronto!", "Desativado com sucesso!", ToolTipIcon.Info);

            }

        }
    }
}
