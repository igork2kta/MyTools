namespace MyTools
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            bt_save = new Button();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            abrirToolStripMenuItem = new ToolStripMenuItem();
            fecharToolStripMenuItem = new ToolStripMenuItem();
            ckb_autoStart = new CheckBox();
            ckb_startMinimized = new CheckBox();
            label3 = new Label();
            ckb_alwaysPresent = new CheckBox();
            lbl_help = new Label();
            dataGridView = new DataGridView();
            tb_funcao = new DataGridViewTextBoxColumn();
            ckb_ctrl = new DataGridViewCheckBoxColumn();
            ckb_alt = new DataGridViewCheckBoxColumn();
            ckb_shift = new DataGridViewCheckBoxColumn();
            cb_tecla = new DataGridViewComboBoxColumn();
            ckb_ativo = new DataGridViewCheckBoxColumn();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // bt_save
            // 
            bt_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_save.BackColor = Color.Transparent;
            bt_save.FlatAppearance.BorderSize = 0;
            bt_save.FlatStyle = FlatStyle.Flat;
            bt_save.ForeColor = Color.Transparent;
            bt_save.Image = (Image)resources.GetObject("bt_save.Image");
            bt_save.Location = new Point(646, 292);
            bt_save.Name = "bt_save";
            bt_save.Size = new Size(32, 32);
            bt_save.TabIndex = 7;
            bt_save.UseVisualStyleBackColor = false;
            bt_save.Click += bt_save_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "My Tools";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { abrirToolStripMenuItem, fecharToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(110, 48);
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(109, 22);
            abrirToolStripMenuItem.Text = "Abrir";
            abrirToolStripMenuItem.Click += AbrirToolStripMenuItem_Click;
            // 
            // fecharToolStripMenuItem
            // 
            fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            fecharToolStripMenuItem.Size = new Size(109, 22);
            fecharToolStripMenuItem.Text = "Fechar";
            fecharToolStripMenuItem.Click += FecharToolStripMenuItem_Click;
            // 
            // ckb_autoStart
            // 
            ckb_autoStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ckb_autoStart.AutoSize = true;
            ckb_autoStart.ForeColor = SystemColors.ButtonHighlight;
            ckb_autoStart.Location = new Point(11, 300);
            ckb_autoStart.Name = "ckb_autoStart";
            ckb_autoStart.Size = new Size(147, 19);
            ckb_autoStart.TabIndex = 14;
            ckb_autoStart.Text = "Iniciar com o Windows";
            ckb_autoStart.UseVisualStyleBackColor = true;
            ckb_autoStart.CheckedChanged += ckb_autoStart_CheckedChanged;
            // 
            // ckb_startMinimized
            // 
            ckb_startMinimized.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ckb_startMinimized.AutoSize = true;
            ckb_startMinimized.ForeColor = SystemColors.ButtonHighlight;
            ckb_startMinimized.Location = new Point(176, 300);
            ckb_startMinimized.Name = "ckb_startMinimized";
            ckb_startMinimized.Size = new Size(124, 19);
            ckb_startMinimized.TabIndex = 15;
            ckb_startMinimized.Text = "Iniciar minimizado";
            ckb_startMinimized.UseVisualStyleBackColor = true;
            ckb_startMinimized.CheckedChanged += ckb_startMinimized_CheckedChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(11, 260);
            label3.Name = "label3";
            label3.Size = new Size(124, 21);
            label3.TabIndex = 16;
            label3.Text = "Nunca ausente";
            label3.Visible = false;
            // 
            // ckb_alwaysPresent
            // 
            ckb_alwaysPresent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ckb_alwaysPresent.AutoSize = true;
            ckb_alwaysPresent.ForeColor = SystemColors.ButtonHighlight;
            ckb_alwaysPresent.Location = new Point(162, 264);
            ckb_alwaysPresent.Name = "ckb_alwaysPresent";
            ckb_alwaysPresent.Size = new Size(54, 19);
            ckb_alwaysPresent.TabIndex = 17;
            ckb_alwaysPresent.Text = "Ativo";
            ckb_alwaysPresent.UseVisualStyleBackColor = true;
            ckb_alwaysPresent.Visible = false;
            ckb_alwaysPresent.CheckedChanged += ckb_alwaysPresent_CheckedChanged;
            // 
            // lbl_help
            // 
            lbl_help.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_help.BackColor = Color.Transparent;
            lbl_help.Font = new Font("Segoe UI", 10F);
            lbl_help.ForeColor = SystemColors.ButtonHighlight;
            lbl_help.Image = (Image)resources.GetObject("lbl_help.Image");
            lbl_help.Location = new Point(658, 9);
            lbl_help.Name = "lbl_help";
            lbl_help.Size = new Size(20, 18);
            lbl_help.TabIndex = 25;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { tb_funcao, ckb_ctrl, ckb_alt, ckb_shift, cb_tecla, ckb_ativo });
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(640, 221);
            dataGridView.TabIndex = 38;
            // 
            // tb_funcao
            // 
            tb_funcao.Frozen = true;
            tb_funcao.HeaderText = "FUNCAO";
            tb_funcao.Name = "tb_funcao";
            tb_funcao.Width = 250;
            // 
            // ckb_ctrl
            // 
            ckb_ctrl.FalseValue = "";
            ckb_ctrl.HeaderText = "CTRL";
            ckb_ctrl.IndeterminateValue = "";
            ckb_ctrl.Name = "ckb_ctrl";
            ckb_ctrl.TrueValue = "";
            ckb_ctrl.Width = 50;
            // 
            // ckb_alt
            // 
            ckb_alt.HeaderText = "ALT";
            ckb_alt.IndeterminateValue = "";
            ckb_alt.Name = "ckb_alt";
            ckb_alt.Width = 50;
            // 
            // ckb_shift
            // 
            ckb_shift.HeaderText = "SHIFT";
            ckb_shift.IndeterminateValue = "";
            ckb_shift.Name = "ckb_shift";
            ckb_shift.Width = 50;
            // 
            // cb_tecla
            // 
            cb_tecla.HeaderText = "TECLA";
            cb_tecla.Name = "cb_tecla";
            // 
            // ckb_ativo
            // 
            ckb_ativo.HeaderText = "ATIVO";
            ckb_ativo.IndeterminateValue = "";
            ckb_ativo.Name = "ckb_ativo";
            ckb_ativo.Width = 50;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(685, 330);
            Controls.Add(dataGridView);
            Controls.Add(lbl_help);
            Controls.Add(ckb_alwaysPresent);
            Controls.Add(label3);
            Controls.Add(ckb_startMinimized);
            Controls.Add(ckb_autoStart);
            Controls.Add(bt_save);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "My Tools";
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button bt_save;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private CheckBox ckb_autoStart;
        private CheckBox ckb_startMinimized;
        private Label label3;
        private CheckBox ckb_alwaysPresent;
        private Label lbl_help;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn tb_funcao;
        private DataGridViewCheckBoxColumn ckb_ctrl;
        private DataGridViewCheckBoxColumn ckb_alt;
        private DataGridViewCheckBoxColumn ckb_shift;
        private DataGridViewComboBoxColumn cb_tecla;
        private DataGridViewCheckBoxColumn ckb_ativo;
    }
}
