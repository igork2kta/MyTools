using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyTools.Classes
{
    public  class AlwaysPresent
    {
        static System.Windows.Forms.Timer mouseMoveTimer;


        // Importação de função nativa para impedir que o computador entre em estado de suspensão
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        // Enumeração para definir o estado de execução do thread
        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Adicione outros estados, se necessário
        }



        public void Start()
        {
            // Inicializa o Timer para mover o mouse a cada 5 minutos
            mouseMoveTimer = new System.Windows.Forms.Timer();
            mouseMoveTimer.Interval = 2 * 60 * 1000; // 5 minutos em milissegundos
            mouseMoveTimer.Tick += MouseMoveTimer_Tick;
            mouseMoveTimer.Start();

            using NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
            // Impedir que o computador entre em estado de suspensão ou desligamento do monitor
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);


            notifyIcon.ShowBalloonTip(3000, "Pronto!", "Sempre ativo em execução, vá fazer o que precisa!", ToolTipIcon.Info);


        }

        public void Stop()
        {
            // Restaurar o comportamento padrão de suspensão e desligamento do monitor
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
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
