using AudioSwitcher.AudioApi.CoreAudio;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;

namespace MyTools.Classes
{
    public class OSwitch
    {
        CoreAudioController controller = new CoreAudioController();
        List<CoreAudioDevice>? selectedDevices;

        public OSwitch()
        {
            var allDevices = controller.GetPlaybackDevices()
                                       .Where(d => d.State == AudioSwitcher.AudioApi.DeviceState.Active)
                                       .ToList();
            var selectedIds = ConfigLoader.LoadSelectedDeviceIds();
            selectedDevices = allDevices.Where(d => selectedIds.Contains(d.Id.ToString())).ToList();
        }
        public void DoSwitch()
        {
            if (!selectedDevices.Any())
            {
                OSwitchPopup.ShowPopup("Nenhum dispositivo selecionado!");
                return;
            }

            // Alterna para o próximo
            var current = controller.DefaultPlaybackDevice;
            int index = selectedDevices.FindIndex(d => d.Id == current.Id);
            int nextIndex = (index + 1) % selectedDevices.Count;
            var next = selectedDevices[nextIndex];
            next.SetAsDefault();
            // Mostra popup com ícone dinâmico
            //Icon icon = GetDeviceIcon(next.FullName);
            Icon icon = null;// não estou usando icone agora
            OSwitchPopup.ShowPopup($"🔊 {next.FullName}", icon);

        }

        static Icon GetDeviceIcon(string deviceName)
        {
            deviceName = deviceName.ToLower();
            if (deviceName.Contains("hdmi"))
                return SystemIcons.Shield;
            else if (deviceName.Contains("fone") || deviceName.Contains("headset") || deviceName.Contains("bluetooth"))
                return SystemIcons.Information;
            else
                return SystemIcons.Application;
        }

        public class Config
        {
            public List<string> SelectedDeviceIds { get; set; }
        }
    }


    public class DeviceSelectorForm : Form
    {
        private CheckedListBox deviceList;
        private Button btnSave;
        private CoreAudioController controller;
        private List<CoreAudioDevice> allDevices;
        private const string ConfigFile = "devices.json";

        public DeviceSelectorForm()
        {
            Text = "OSwitch - Seleção de Dispositivos";
            Size = new Size(400, 400);
            StartPosition = FormStartPosition.CenterScreen;

            controller = new CoreAudioController();

            deviceList = new CheckedListBox()
            {
                Dock = DockStyle.Top,
                Height = 300,
                CheckOnClick = true
            };
            Controls.Add(deviceList);

            btnSave = new Button()
            {
                Text = "Salvar Seleção",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnSave.Click += BtnSave_Click;
            Controls.Add(btnSave);

            LoadDevices();
        }

        private void LoadDevices()
        {
            allDevices = controller.GetPlaybackDevices()
                                   .Where(d => d.State == AudioSwitcher.AudioApi.DeviceState.Active)
                                   .OrderBy(d => d.FullName)
                                   .ToList();

            var selectedIds = ConfigLoader.LoadSelectedDeviceIds();

            foreach (var device in allDevices)
            {
                bool isChecked = selectedIds.Contains(device.Id.ToString());
                deviceList.Items.Add(device.FullName, isChecked);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var selectedDevices = new List<string>();
            for (int i = 0; i < deviceList.Items.Count; i++)
            {
                if (deviceList.GetItemChecked(i))
                    selectedDevices.Add(allDevices[i].Id.ToString());
            }

            var config = new OSwitch.Config { SelectedDeviceIds = selectedDevices };
            ConfigLoader.SaveSelectedDeviceIds(config);
            Close();
        }

    }

    public static class OSwitchPopup
    {

        const int SWP_SHOWWINDOW = 0x0040;
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public static void ShowPopup(string message, Icon icon = null)
        {
            // Garante que seja executado na thread principal
            if (Application.MessageLoop)
            {
                ShowForm(message, icon);
            }
            else
            {
                Application.Run(new RoundedPopupForm(message, icon));
            }
        }

        private static void ShowForm(string message, Icon icon)
        {
            var form = new RoundedPopupForm(message, icon);
            form.TopMost = true; // Fica acima de todas as janelas
            form.ShowInTaskbar = false;
            form.FormBorderStyle = FormBorderStyle.None;

            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(20, 20); // Ajuste a posição na tela
            form.Show(); // Não depende do form principal
            form.BringToFront();
            form.Activate();



            // Opcional: usar Win32 para topo absoluto
            SetWindowPos(form.Handle, HWND_TOPMOST, form.Left, form.Top, form.Width, form.Height, SWP_SHOWWINDOW);


        }
    }

    public class RoundedPopupForm : Form
    {
        public RoundedPopupForm(string message, Icon icon)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.White;
            Size = new Size(320, 60);
            Opacity = 0;
            Location = new Point(20, 20);

            /*
            // PictureBox para ícone
            if (icon != null)
            {
                var pic = new PictureBox()
                {
                    Size = new Size(32, 32),
                    Location = new Point(10, 14),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = icon.ToBitmap()
                };
                Controls.Add(pic);
                pic.BringToFront();
            }
            */
            var label = new Label()
            {
                Text = message,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 0, 10, 0)
                //Padding = new Padding(50, 0, 10, 0) // espaço para ícone
            };
            Controls.Add(label);

            // Fade-in / fade-out
            var fadeInTimer = new Timer { Interval = 30 };
            fadeInTimer.Tick += (s, e) =>
            {
                if (Opacity < 0.9)
                    Opacity += 0.08;
                else
                {
                    fadeInTimer.Stop();
                    Task.Delay(1500).ContinueWith(_ => BeginFadeOut());
                }
            };
            fadeInTimer.Start();
        }

        private void BeginFadeOut()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(BeginFadeOut));
                return;
            }

            var fadeOutTimer = new Timer { Interval = 30 };
            fadeOutTimer.Tick += (s, e) =>
            {
                if (Opacity > 0)
                    Opacity -= 0.08;
                else
                {
                    fadeOutTimer.Stop();
                    Close();
                }
            };
            fadeOutTimer.Start();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
    }

}
