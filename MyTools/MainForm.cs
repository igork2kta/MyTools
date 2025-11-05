using MyTools.Classes;
using System.Reflection;

namespace MyTools
{
    public partial class MainForm : Form
    {
        readonly string TextoCancelamentoChamado = Properties.Settings.Default.PadraoCancelChamado;
        readonly string TextoChamadoSubstituicao = Properties.Settings.Default.PadraoChamadoSubstituicao;
        const int ckb_ctrl_index = 1;
        const int ckb_alt_index = 2;
        const int ckb_shift_index = 3;
        const int cb_tecla_index = 4;
        const int ckb_ativo_index = 5;
        OSwitch OSwitch = new();
        string originalValue;
        bool starting = true;
        public MainForm()
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();

            // Obter a data de criação do arquivo do assembly
            DateTime creationDate = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);

            string helpText = $@"Data de compilação: {creationDate}
Versão {Assembly.GetEntryAssembly().GetName().Version}";

            toolTip.SetToolTip(lbl_help, helpText);

            tb_funcao.ReadOnly = true;

            ToolTip delayTooltip = new ToolTip();
            delayTooltip.SetToolTip(lbl_delay, "Aumente o delay se os dispositivos de audio não estiverem sendo reconhecidos na inicialização!");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            ckb_alwaysPresent.Checked = Properties.Settings.Default.AlwaysPresent;
            ckb_autoStart.Checked = Properties.Settings.Default.AutoStart;
            ckb_startMinimized.Checked = Properties.Settings.Default.StartMinimized;
            tb_delay.Text = Properties.Settings.Default.AutoStartDelay;

            if (Properties.Settings.Default.StartMinimized) WindowState = FormWindowState.Minimized;

            //cb_tecla.DataSource = Enum.GetNames(typeof(Keys));


            StartCommands();
            starting = false;

        }

        private void StartCommands()
        {

            dataGridView.Rows.Clear();
            if (ckb_alwaysPresent.Checked) AlwaysPresent.Start();
            else AlwaysPresent.Stop();

            List<ShortcutKey> shortcuts = new List<ShortcutKey>();
            shortcuts = ConfigLoader.LoadConfig();

            //Popular com o padrão
            if (shortcuts.Count == 0) ValoresPadrao(ref shortcuts);

            foreach (ShortcutKey shortcut in shortcuts)
            {
                dataGridView.Rows.Add(shortcut.Name, shortcut.Control, shortcut.Alt, shortcut.Shift, shortcut.Key.ToString(), shortcut.Active);
            }

            if (shortcuts[5].Active) shortcuts[5] = DispararOSwitch();
            else shortcuts.Remove(shortcuts[5]);

            if (shortcuts[4].Active) shortcuts[4] = TextoPadraoSubstituicaoChamado();
            else shortcuts.Remove(shortcuts[4]);

            if (shortcuts[3].Active) shortcuts[3] = TextoPadraoCancelamentoChamado();
            else shortcuts.Remove(shortcuts[3]);

            if (shortcuts[2].Active) shortcuts[2] = TextUnformatterCommand();
            else shortcuts.Remove(shortcuts[2]);

            if (shortcuts[1].Active) shortcuts[1] = BotaVirgulaPraMimMiniCommand();
            else shortcuts.Remove(shortcuts[1]);

            if (shortcuts[0].Active) shortcuts[0] = CreateNewTextFileCommand();
            else shortcuts.Remove(shortcuts[0]);


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
                Name = "Criar novo documento de texto",
                Key = GetEnumValue<Keys>(dataGridView.Rows[0].Cells[cb_tecla_index].Value.ToString()),
                Control = (bool)dataGridView.Rows[0].Cells[ckb_ctrl_index].Value,
                Shift = (bool)dataGridView.Rows[0].Cells[ckb_shift_index].Value,
                Alt = (bool)dataGridView.Rows[0].Cells[ckb_alt_index].Value,
                EventHandler = (s, e) => { Task.Run(() => CreateNewTextFile.Criar()); },
                Active = (bool)dataGridView.Rows[0].Cells[ckb_ativo_index].Value
            };
        }

        private ShortcutKey BotaVirgulaPraMimMiniCommand()
        {
            return new ShortcutKey
            {
                Name = "Bota virgula pra mim mini",
                Key = GetEnumValue<Keys>(dataGridView.Rows[1].Cells[cb_tecla_index].Value.ToString()),
                Control = (bool)dataGridView.Rows[1].Cells[ckb_ctrl_index].Value,
                Shift = (bool)dataGridView.Rows[1].Cells[ckb_shift_index].Value,
                Alt = (bool)dataGridView.Rows[1].Cells[ckb_alt_index].Value,
                EventHandler = (s, e) => { BotaVirgulaPraMimMini.Executar(); },
                Active = (bool)dataGridView.Rows[1].Cells[ckb_ativo_index].Value
            };
        }


        private ShortcutKey TextUnformatterCommand()
        {
            return new ShortcutKey
            {
                Name = "Desformatador de texto",
                Key = GetEnumValue<Keys>(dataGridView.Rows[2].Cells[cb_tecla_index].Value.ToString()),
                Control = (bool)dataGridView.Rows[2].Cells[ckb_ctrl_index].Value,
                Shift = (bool)dataGridView.Rows[2].Cells[ckb_shift_index].Value,
                Alt = (bool)dataGridView.Rows[2].Cells[ckb_alt_index].Value,
                EventHandler = (s, e) => { TextUnformatter.UnformatText(); },
                Active = (bool)dataGridView.Rows[2].Cells[ckb_ativo_index].Value
            };
        }

        private ShortcutKey TextoPadraoCancelamentoChamado()
        {
            return new ShortcutKey
            {
                Name = "Texto padrão cancelamento chamado",
                Key = GetEnumValue<Keys>(dataGridView.Rows[3].Cells[cb_tecla_index].Value.ToString()),
                Control = (bool)dataGridView.Rows[3].Cells[ckb_ctrl_index].Value,
                Shift = (bool)dataGridView.Rows[3].Cells[ckb_shift_index].Value,
                Alt = (bool)dataGridView.Rows[3].Cells[ckb_alt_index].Value,
                EventHandler = (s, e) => { TextoPadrao("CANCELAMENTO"); },
                Active = (bool)dataGridView.Rows[3].Cells[ckb_ativo_index].Value
            };
        }

        private ShortcutKey TextoPadraoSubstituicaoChamado()
        {
            return new ShortcutKey
            {
                Name = "Texto padrão chamado substituição",
                Key = GetEnumValue<Keys>(dataGridView.Rows[4].Cells[cb_tecla_index].Value.ToString()),
                Control = (bool)dataGridView.Rows[4].Cells[ckb_ctrl_index].Value,
                Shift = (bool)dataGridView.Rows[4].Cells[ckb_shift_index].Value,
                Alt = (bool)dataGridView.Rows[4].Cells[ckb_alt_index].Value,
                EventHandler = (s, e) => { TextoPadrao("SUBSTITUICAO"); },
                Active = (bool)dataGridView.Rows[4].Cells[ckb_ativo_index].Value
            };
        }

        private ShortcutKey DispararOSwitch()
        {

            return new ShortcutKey
            {
                Name = "Alternar dispositivos de audio",
                Key = GetEnumValue<Keys>(dataGridView.Rows[5].Cells[cb_tecla_index].Value.ToString()),
                Control = (bool)dataGridView.Rows[5].Cells[ckb_ctrl_index].Value,
                Shift = (bool)dataGridView.Rows[5].Cells[ckb_shift_index].Value,
                Alt = (bool)dataGridView.Rows[5].Cells[ckb_alt_index].Value,
                EventHandler = (s, e) => { Task.Run(() => OSwitch.DoSwitch()); },
                Active = (bool)dataGridView.Rows[5].Cells[ckb_ativo_index].Value
            };
        }
        private void TextoPadrao(string tipo)
        {
            if (tipo == "CANCELAMENTO")
            {
                TextUnformatter.TextoPadrao(TextoCancelamentoChamado);
            }
            else if (tipo == "SUBSTITUICAO")
            {
                TextUnformatter.TextoPadrao(TextoChamadoSubstituicao);
            }
        }

        private void ValoresPadrao(ref List<ShortcutKey> shortcuts)
        {
            shortcuts.Add(new ShortcutKey
            {
                Name = "Criar novo documento de texto",
                Key = GetEnumValue<Keys>("M"),
                Control = true,
                Shift = true,
                Alt = false,
                EventHandler = (s, e) => { Task.Run(() => CreateNewTextFile.Criar()); },
                Active = false
            });

            shortcuts.Add(new ShortcutKey
            {
                Name = "Bota virgula pra mim mini",
                Key = GetEnumValue<Keys>("B"),
                Control = true,
                Shift = true,
                Alt = false,
                EventHandler = (s, e) => { BotaVirgulaPraMimMini.Executar(); },
                Active = false
            });

            shortcuts.Add(new ShortcutKey
            {
                Name = "Desformatador de texto",
                Key = GetEnumValue<Keys>("V"),
                Control = true,
                Shift = true,
                Alt = false,
                EventHandler = (s, e) => { TextUnformatter.UnformatText(); },
                Active = false
            });

            shortcuts.Add(new ShortcutKey
            {
                Name = "Texto padrão cancelamento chamado",
                Key = GetEnumValue<Keys>("D1"),
                Control = true,
                Shift = true,
                Alt = false,
                EventHandler = (s, e) => { TextoPadrao("CANCELAMENTO"); },
                Active = false
            });

            shortcuts.Add(new ShortcutKey
            {
                Name = "Texto padrão chamado substituição",
                Key = GetEnumValue<Keys>("D1"),
                Control = true,
                Shift = true,
                Alt = false,
                EventHandler = (s, e) => { TextoPadrao("SUBSTITUICAO"); },
                Active = false
            });



            shortcuts.Add(new ShortcutKey
            {
                Name = "Texto padrão chamado substituição",
                Key = GetEnumValue<Keys>("Oem3"),
                Control = true,
                Shift = false,
                Alt = false,
                EventHandler = (s, e) => { DispararOSwitch(); },
                Active = true
            });
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            List<ShortcutKey> shortcuts = new List<ShortcutKey>
            {
                CreateNewTextFileCommand(),
                BotaVirgulaPraMimMiniCommand(),
                TextUnformatterCommand(),
                TextoPadraoCancelamentoChamado(),
                TextoPadraoSubstituicaoChamado(),
                DispararOSwitch()
            };
            ConfigLoader.SaveConfig(shortcuts);
            KeyboardHook.Stop();
            StartCommands();
        }

        public static T GetEnumValue<T>(string str) where T : struct, Enum
        {
            if (!Enum.TryParse<T>(str, true, out var result))
                return default; // retorna Keys.None no caso de Keys
            return result;
        }


        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            //Mostra no gerenciador de tarefas novamente
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                ShowInTaskbar = false;
                //Esconde do gerenciador de tarefas quando a aplicação é minimizada
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
        }

        private void ckb_autoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (starting) return;
            bool result = AutoStartManager.SetAutoStart(ckb_autoStart.Checked, Convert.ToInt32(tb_delay.Value));

            starting = true;
            //Não conseguiu agendar a tarefa
            if (ckb_autoStart.Checked && !result) ckb_autoStart.Checked = false;
            //Não conseguiu remover a tarefa
            if (!ckb_autoStart.Checked && !result) ckb_autoStart.Checked = true;
            starting = false;

            Properties.Settings.Default.AutoStart = ckb_autoStart.Checked;
            Properties.Settings.Default.Save();
        }
        private void ckb_startMinimized_CheckedChanged(object sender, EventArgs e)
        {
            if (starting) return;
            Properties.Settings.Default.StartMinimized = ckb_startMinimized.Checked;
            Properties.Settings.Default.Save();
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void FecharToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void ckb_alwaysPresent_CheckedChanged(object sender, EventArgs e)
        {
            if (starting) return;
            Properties.Settings.Default.AlwaysPresent = ckb_alwaysPresent.Checked;
            Properties.Settings.Default.Save();

            if (ckb_alwaysPresent.Checked) AlwaysPresent.Start();
            else AlwaysPresent.Stop();

        }

        private void bt_audio_devices_Click(object sender, EventArgs e)
        {
            var deviceSelect = new DeviceSelectorForm();
            deviceSelect.ShowDialog();
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se clicou na coluna desejada (índice 5)
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                dataGridView.BeginEdit(true);
            }
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex == 4)
            {
                if (e.Control is TextBox tb)
                {
                    // Remove eventos antigos para não duplicar
                    tb.KeyDown -= dataGridView_KeyDown;
                    tb.KeyDown += dataGridView_KeyDown;

                    //Salva o valor original
                    originalValue = tb.Text;
                    tb.Text = "Pressione uma tecla...";
                }
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox tb)
            {
                Keys selectedKey = e.KeyCode;
                tb.Text = selectedKey.ToString();
                e.SuppressKeyPress = true; // Evita que a tecla seja inserida
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                var cell = dataGridView[e.ColumnIndex, e.RowIndex];
                if (cell.Value?.ToString() == "Pressione uma tecla..." || string.IsNullOrEmpty(cell.Value?.ToString()))
                {
                    cell.Value = originalValue; // Restaura valor original
                    originalValue = "";
                }
            }
        }

        private void tb_delay_ValueChanged(object sender, EventArgs e)
        {
            if (starting) return;

            Properties.Settings.Default.AutoStartDelay = tb_delay.ToString();
            Properties.Settings.Default.Save();

            if (ckb_autoStart.Checked)
            {
                AutoStartManager.SetAutoStart(true, Convert.ToInt32(tb_delay.Value));
            }
        }
    }

}
