using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MyTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_key0.DataSource = Enum.GetNames(typeof(Keys));
            cb_key1.DataSource = Enum.GetNames(typeof(Keys));
            StartCommands();
        }

        private void StartCommands()
        {
            List<ShortcutKey> shortcuts = new List<ShortcutKey>();
            shortcuts = ConfigLoader.LoadConfig();

            //Create new text file document
            ckb_ctrl0.Checked = shortcuts[0].Control;
            ckb_alt0.Checked = shortcuts[0].Alt;
            ckb_shift0.Checked = shortcuts[0].Shift;
            ckb_active0.Checked = shortcuts[0].Active;
            cb_key0.SelectedItem = shortcuts[0].Key.ToString();

            if (shortcuts[0].Active) shortcuts[0] = CreateNewTextFileCommand();
            else shortcuts.Remove(shortcuts[0]);

            //Bota virgula pra mim mini
            ckb_ctrl1.Checked = shortcuts[1].Control;
            ckb_alt1.Checked = shortcuts[1].Alt;
            ckb_shift1.Checked = shortcuts[1].Shift;
            ckb_active1.Checked = shortcuts[1].Active;
            cb_key1.SelectedItem = shortcuts[1].Key.ToString();

            if (shortcuts[1].Active) shortcuts[1] = BotaVirgulaPraMimMiniCommand();
            else shortcuts.Remove(shortcuts[1]);

            KeyboardHook.Start(shortcuts);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.Stop();
        }



        private ShortcutKey CreateNewTextFileCommand()
        {
            return new ShortcutKey
            {
                Key = GetEnumValue<Keys>(cb_key0.Text),
                Control = ckb_ctrl0.Checked,
                Shift = ckb_shift0.Checked,
                Alt = ckb_alt0.Checked,
                EventHandler = (s, e) => { Task.Run(() => CreateNewTextFile.Criar()); },
                Active = ckb_active0.Checked
            };
        }

        private ShortcutKey BotaVirgulaPraMimMiniCommand()
        {
            return new ShortcutKey
            {
                Key = GetEnumValue<Keys>(cb_key1.Text),
                Control = ckb_ctrl1.Checked,
                Shift = ckb_shift1.Checked,
                Alt = ckb_alt1.Checked,
                EventHandler = (s, e) => { BotaVirgulaPraMimMini.executar(); },
                Active = ckb_active1.Checked
            };
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            List<ShortcutKey> shortcuts = new List<ShortcutKey>
            {
                CreateNewTextFileCommand(),
                BotaVirgulaPraMimMiniCommand()
                
            };
            ConfigLoader.SaveConfig(shortcuts);
            KeyboardHook.Stop();
            StartCommands();
        }

        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().ToUpper().Equals(str.ToUpper()))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }
            return val;
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            //Mostra no gerenciador de tarefas novamente
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                ShowInTaskbar = false;
                //Esconde do gerenciador de tarefas quando a aplica��o � minimizada
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void FecharToolStripMenuItem_Click(object sender, EventArgs e) => Close();


    }

}
