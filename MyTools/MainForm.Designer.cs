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
            label1 = new Label();
            bt_save = new Button();
            cb_key0 = new ComboBox();
            ckb_ctrl0 = new CheckBox();
            ckb_alt0 = new CheckBox();
            ckb_shift0 = new CheckBox();
            ckb_active0 = new CheckBox();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            abrirToolStripMenuItem = new ToolStripMenuItem();
            fecharToolStripMenuItem = new ToolStripMenuItem();
            ckb_active1 = new CheckBox();
            ckb_shift1 = new CheckBox();
            ckb_alt1 = new CheckBox();
            ckb_ctrl1 = new CheckBox();
            cb_key1 = new ComboBox();
            label2 = new Label();
            ckb_autoStart = new CheckBox();
            ckb_startMinimized = new CheckBox();
            label3 = new Label();
            ckb_alwaysPresent = new CheckBox();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(248, 21);
            label1.TabIndex = 1;
            label1.Text = "Criar novo documento de texto";
            // 
            // bt_save
            // 
            bt_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_save.BackColor = Color.Transparent;
            bt_save.FlatAppearance.BorderSize = 0;
            bt_save.FlatStyle = FlatStyle.Flat;
            bt_save.ForeColor = Color.Transparent;
            bt_save.Image = (Image)resources.GetObject("bt_save.Image");
            bt_save.Location = new Point(365, 295);
            bt_save.Name = "bt_save";
            bt_save.Size = new Size(32, 32);
            bt_save.TabIndex = 7;
            bt_save.UseVisualStyleBackColor = false;
            bt_save.Click += bt_save_Click;
            // 
            // cb_key0
            // 
            cb_key0.FormattingEnabled = true;
            cb_key0.Location = new Point(192, 36);
            cb_key0.Name = "cb_key0";
            cb_key0.Size = new Size(108, 23);
            cb_key0.TabIndex = 0;
            // 
            // ckb_ctrl0
            // 
            ckb_ctrl0.AutoSize = true;
            ckb_ctrl0.ForeColor = SystemColors.ButtonHighlight;
            ckb_ctrl0.Location = new Point(38, 38);
            ckb_ctrl0.Name = "ckb_ctrl0";
            ckb_ctrl0.Size = new Size(45, 19);
            ckb_ctrl0.TabIndex = 3;
            ckb_ctrl0.Text = "Ctrl";
            ckb_ctrl0.UseVisualStyleBackColor = true;
            // 
            // ckb_alt0
            // 
            ckb_alt0.AutoSize = true;
            ckb_alt0.ForeColor = SystemColors.ButtonHighlight;
            ckb_alt0.Location = new Point(89, 38);
            ckb_alt0.Name = "ckb_alt0";
            ckb_alt0.Size = new Size(41, 19);
            ckb_alt0.TabIndex = 4;
            ckb_alt0.Text = "Alt";
            ckb_alt0.UseVisualStyleBackColor = true;
            // 
            // ckb_shift0
            // 
            ckb_shift0.AutoSize = true;
            ckb_shift0.ForeColor = SystemColors.ButtonHighlight;
            ckb_shift0.Location = new Point(136, 38);
            ckb_shift0.Name = "ckb_shift0";
            ckb_shift0.Size = new Size(50, 19);
            ckb_shift0.TabIndex = 5;
            ckb_shift0.Text = "Shift";
            ckb_shift0.UseVisualStyleBackColor = true;
            // 
            // ckb_active0
            // 
            ckb_active0.AutoSize = true;
            ckb_active0.Checked = true;
            ckb_active0.CheckState = CheckState.Checked;
            ckb_active0.ForeColor = SystemColors.ButtonHighlight;
            ckb_active0.Location = new Point(318, 40);
            ckb_active0.Name = "ckb_active0";
            ckb_active0.Size = new Size(54, 19);
            ckb_active0.TabIndex = 6;
            ckb_active0.Text = "Ativo";
            ckb_active0.UseVisualStyleBackColor = true;
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
            // 
            // fecharToolStripMenuItem
            // 
            fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            fecharToolStripMenuItem.Size = new Size(109, 22);
            fecharToolStripMenuItem.Text = "Fechar";
            // 
            // ckb_active1
            // 
            ckb_active1.AutoSize = true;
            ckb_active1.Checked = true;
            ckb_active1.CheckState = CheckState.Checked;
            ckb_active1.ForeColor = SystemColors.ButtonHighlight;
            ckb_active1.Location = new Point(318, 104);
            ckb_active1.Name = "ckb_active1";
            ckb_active1.Size = new Size(54, 19);
            ckb_active1.TabIndex = 12;
            ckb_active1.Text = "Ativo";
            ckb_active1.UseVisualStyleBackColor = true;
            // 
            // ckb_shift1
            // 
            ckb_shift1.AutoSize = true;
            ckb_shift1.ForeColor = SystemColors.ButtonHighlight;
            ckb_shift1.Location = new Point(136, 102);
            ckb_shift1.Name = "ckb_shift1";
            ckb_shift1.Size = new Size(50, 19);
            ckb_shift1.TabIndex = 11;
            ckb_shift1.Text = "Shift";
            ckb_shift1.UseVisualStyleBackColor = true;
            // 
            // ckb_alt1
            // 
            ckb_alt1.AutoSize = true;
            ckb_alt1.ForeColor = SystemColors.ButtonHighlight;
            ckb_alt1.Location = new Point(89, 102);
            ckb_alt1.Name = "ckb_alt1";
            ckb_alt1.Size = new Size(41, 19);
            ckb_alt1.TabIndex = 10;
            ckb_alt1.Text = "Alt";
            ckb_alt1.UseVisualStyleBackColor = true;
            // 
            // ckb_ctrl1
            // 
            ckb_ctrl1.AutoSize = true;
            ckb_ctrl1.ForeColor = SystemColors.ButtonHighlight;
            ckb_ctrl1.Location = new Point(38, 102);
            ckb_ctrl1.Name = "ckb_ctrl1";
            ckb_ctrl1.Size = new Size(45, 19);
            ckb_ctrl1.TabIndex = 9;
            ckb_ctrl1.Text = "Ctrl";
            ckb_ctrl1.UseVisualStyleBackColor = true;
            // 
            // cb_key1
            // 
            cb_key1.FormattingEnabled = true;
            cb_key1.Location = new Point(192, 100);
            cb_key1.Name = "cb_key1";
            cb_key1.Size = new Size(108, 23);
            cb_key1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(210, 21);
            label2.TabIndex = 13;
            label2.Text = "Bota virgula pra mim Mini";
            // 
            // ckb_autoStart
            // 
            ckb_autoStart.AutoSize = true;
            ckb_autoStart.ForeColor = SystemColors.ButtonHighlight;
            ckb_autoStart.Location = new Point(12, 308);
            ckb_autoStart.Name = "ckb_autoStart";
            ckb_autoStart.Size = new Size(147, 19);
            ckb_autoStart.TabIndex = 14;
            ckb_autoStart.Text = "Iniciar com o Windows";
            ckb_autoStart.UseVisualStyleBackColor = true;
            ckb_autoStart.CheckedChanged += ckb_autoStart_CheckedChanged;
            // 
            // ckb_startMinimized
            // 
            ckb_startMinimized.AutoSize = true;
            ckb_startMinimized.ForeColor = SystemColors.ButtonHighlight;
            ckb_startMinimized.Location = new Point(177, 308);
            ckb_startMinimized.Name = "ckb_startMinimized";
            ckb_startMinimized.Size = new Size(124, 19);
            ckb_startMinimized.TabIndex = 15;
            ckb_startMinimized.Text = "Iniciar minimizado";
            ckb_startMinimized.UseVisualStyleBackColor = true;
            ckb_startMinimized.CheckedChanged += ckb_startMinimized_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(12, 136);
            label3.Name = "label3";
            label3.Size = new Size(124, 21);
            label3.TabIndex = 16;
            label3.Text = "Nunca ausente";
            // 
            // ckb_alwaysPresent
            // 
            ckb_alwaysPresent.AutoSize = true;
            ckb_alwaysPresent.Checked = true;
            ckb_alwaysPresent.CheckState = CheckState.Checked;
            ckb_alwaysPresent.ForeColor = SystemColors.ButtonHighlight;
            ckb_alwaysPresent.Location = new Point(163, 140);
            ckb_alwaysPresent.Name = "ckb_alwaysPresent";
            ckb_alwaysPresent.Size = new Size(54, 19);
            ckb_alwaysPresent.TabIndex = 17;
            ckb_alwaysPresent.Text = "Ativo";
            ckb_alwaysPresent.UseVisualStyleBackColor = true;
            ckb_alwaysPresent.CheckedChanged += ckb_alwaysPresent_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(404, 333);
            Controls.Add(ckb_alwaysPresent);
            Controls.Add(label3);
            Controls.Add(ckb_startMinimized);
            Controls.Add(ckb_autoStart);
            Controls.Add(label2);
            Controls.Add(ckb_active1);
            Controls.Add(ckb_shift1);
            Controls.Add(ckb_alt1);
            Controls.Add(ckb_ctrl1);
            Controls.Add(cb_key1);
            Controls.Add(bt_save);
            Controls.Add(ckb_active0);
            Controls.Add(ckb_shift0);
            Controls.Add(ckb_alt0);
            Controls.Add(ckb_ctrl0);
            Controls.Add(label1);
            Controls.Add(cb_key0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "My Tools";
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button bt_save;
        private ComboBox cb_key0;
        private CheckBox ckb_ctrl0;
        private CheckBox ckb_alt0;
        private CheckBox ckb_shift0;
        private CheckBox ckb_active0;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem fecharToolStripMenuItem;
        private CheckBox ckb_active1;
        private CheckBox ckb_shift1;
        private CheckBox ckb_alt1;
        private CheckBox ckb_ctrl1;
        private ComboBox cb_key1;
        private Label label2;
        private CheckBox ckb_autoStart;
        private CheckBox ckb_startMinimized;
        private Label label3;
        private CheckBox ckb_alwaysPresent;
    }
}
