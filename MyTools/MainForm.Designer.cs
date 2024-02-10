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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.bt_save = new System.Windows.Forms.Button();
            this.cb_key0 = new System.Windows.Forms.ComboBox();
            this.ckb_ctrl0 = new System.Windows.Forms.CheckBox();
            this.ckb_alt0 = new System.Windows.Forms.CheckBox();
            this.ckb_shift0 = new System.Windows.Forms.CheckBox();
            this.ckb_active0 = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckb_active1 = new System.Windows.Forms.CheckBox();
            this.ckb_shift1 = new System.Windows.Forms.CheckBox();
            this.ckb_alt1 = new System.Windows.Forms.CheckBox();
            this.ckb_ctrl1 = new System.Windows.Forms.CheckBox();
            this.cb_key1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckb_autoStart = new System.Windows.Forms.CheckBox();
            this.ckb_startMinimized = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckb_alwaysPresent = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Criar novo documento de texto";
            // 
            // bt_save
            // 
            this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_save.BackColor = System.Drawing.Color.Transparent;
            this.bt_save.FlatAppearance.BorderSize = 0;
            this.bt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_save.ForeColor = System.Drawing.Color.Transparent;
            this.bt_save.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.Image")));
            this.bt_save.Location = new System.Drawing.Point(417, 393);
            this.bt_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(37, 43);
            this.bt_save.TabIndex = 7;
            this.bt_save.UseVisualStyleBackColor = false;
            // 
            // cb_key0
            // 
            this.cb_key0.FormattingEnabled = true;
            this.cb_key0.Location = new System.Drawing.Point(219, 48);
            this.cb_key0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_key0.Name = "cb_key0";
            this.cb_key0.Size = new System.Drawing.Size(123, 28);
            this.cb_key0.TabIndex = 0;
            // 
            // ckb_ctrl0
            // 
            this.ckb_ctrl0.AutoSize = true;
            this.ckb_ctrl0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_ctrl0.Location = new System.Drawing.Point(43, 51);
            this.ckb_ctrl0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_ctrl0.Name = "ckb_ctrl0";
            this.ckb_ctrl0.Size = new System.Drawing.Size(54, 24);
            this.ckb_ctrl0.TabIndex = 3;
            this.ckb_ctrl0.Text = "Ctrl";
            this.ckb_ctrl0.UseVisualStyleBackColor = true;
            // 
            // ckb_alt0
            // 
            this.ckb_alt0.AutoSize = true;
            this.ckb_alt0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_alt0.Location = new System.Drawing.Point(102, 51);
            this.ckb_alt0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_alt0.Name = "ckb_alt0";
            this.ckb_alt0.Size = new System.Drawing.Size(50, 24);
            this.ckb_alt0.TabIndex = 4;
            this.ckb_alt0.Text = "Alt";
            this.ckb_alt0.UseVisualStyleBackColor = true;
            // 
            // ckb_shift0
            // 
            this.ckb_shift0.AutoSize = true;
            this.ckb_shift0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_shift0.Location = new System.Drawing.Point(155, 51);
            this.ckb_shift0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_shift0.Name = "ckb_shift0";
            this.ckb_shift0.Size = new System.Drawing.Size(61, 24);
            this.ckb_shift0.TabIndex = 5;
            this.ckb_shift0.Text = "Shift";
            this.ckb_shift0.UseVisualStyleBackColor = true;
            // 
            // ckb_active0
            // 
            this.ckb_active0.AutoSize = true;
            this.ckb_active0.Checked = true;
            this.ckb_active0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_active0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_active0.Location = new System.Drawing.Point(363, 53);
            this.ckb_active0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_active0.Name = "ckb_active0";
            this.ckb_active0.Size = new System.Drawing.Size(66, 24);
            this.ckb_active0.TabIndex = 6;
            this.ckb_active0.Text = "Ativo";
            this.ckb_active0.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "My Tools";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(122, 52);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.fecharToolStripMenuItem.Text = "Fechar";
            // 
            // ckb_active1
            // 
            this.ckb_active1.AutoSize = true;
            this.ckb_active1.Checked = true;
            this.ckb_active1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_active1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_active1.Location = new System.Drawing.Point(363, 139);
            this.ckb_active1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_active1.Name = "ckb_active1";
            this.ckb_active1.Size = new System.Drawing.Size(66, 24);
            this.ckb_active1.TabIndex = 12;
            this.ckb_active1.Text = "Ativo";
            this.ckb_active1.UseVisualStyleBackColor = true;
            // 
            // ckb_shift1
            // 
            this.ckb_shift1.AutoSize = true;
            this.ckb_shift1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_shift1.Location = new System.Drawing.Point(155, 136);
            this.ckb_shift1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_shift1.Name = "ckb_shift1";
            this.ckb_shift1.Size = new System.Drawing.Size(61, 24);
            this.ckb_shift1.TabIndex = 11;
            this.ckb_shift1.Text = "Shift";
            this.ckb_shift1.UseVisualStyleBackColor = true;
            // 
            // ckb_alt1
            // 
            this.ckb_alt1.AutoSize = true;
            this.ckb_alt1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_alt1.Location = new System.Drawing.Point(102, 136);
            this.ckb_alt1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_alt1.Name = "ckb_alt1";
            this.ckb_alt1.Size = new System.Drawing.Size(50, 24);
            this.ckb_alt1.TabIndex = 10;
            this.ckb_alt1.Text = "Alt";
            this.ckb_alt1.UseVisualStyleBackColor = true;
            // 
            // ckb_ctrl1
            // 
            this.ckb_ctrl1.AutoSize = true;
            this.ckb_ctrl1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_ctrl1.Location = new System.Drawing.Point(43, 136);
            this.ckb_ctrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_ctrl1.Name = "ckb_ctrl1";
            this.ckb_ctrl1.Size = new System.Drawing.Size(54, 24);
            this.ckb_ctrl1.TabIndex = 9;
            this.ckb_ctrl1.Text = "Ctrl";
            this.ckb_ctrl1.UseVisualStyleBackColor = true;
            // 
            // cb_key1
            // 
            this.cb_key1.FormattingEnabled = true;
            this.cb_key1.Location = new System.Drawing.Point(219, 133);
            this.cb_key1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_key1.Name = "cb_key1";
            this.cb_key1.Size = new System.Drawing.Size(123, 28);
            this.cb_key1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(14, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Bota virgula pra mim Mini";
            // 
            // ckb_autoStart
            // 
            this.ckb_autoStart.AutoSize = true;
            this.ckb_autoStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_autoStart.Location = new System.Drawing.Point(14, 411);
            this.ckb_autoStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_autoStart.Name = "ckb_autoStart";
            this.ckb_autoStart.Size = new System.Drawing.Size(182, 24);
            this.ckb_autoStart.TabIndex = 14;
            this.ckb_autoStart.Text = "Iniciar com o Windows";
            this.ckb_autoStart.UseVisualStyleBackColor = true;
            // 
            // ckb_startMinimized
            // 
            this.ckb_startMinimized.AutoSize = true;
            this.ckb_startMinimized.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_startMinimized.Location = new System.Drawing.Point(202, 411);
            this.ckb_startMinimized.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_startMinimized.Name = "ckb_startMinimized";
            this.ckb_startMinimized.Size = new System.Drawing.Size(154, 24);
            this.ckb_startMinimized.TabIndex = 15;
            this.ckb_startMinimized.Text = "Iniciar minimizado";
            this.ckb_startMinimized.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(14, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 28);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nunca ausente";
            // 
            // ckb_alwaysPresent
            // 
            this.ckb_alwaysPresent.AutoSize = true;
            this.ckb_alwaysPresent.Checked = true;
            this.ckb_alwaysPresent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_alwaysPresent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ckb_alwaysPresent.Location = new System.Drawing.Point(186, 187);
            this.ckb_alwaysPresent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_alwaysPresent.Name = "ckb_alwaysPresent";
            this.ckb_alwaysPresent.Size = new System.Drawing.Size(66, 24);
            this.ckb_alwaysPresent.TabIndex = 17;
            this.ckb_alwaysPresent.Text = "Ativo";
            this.ckb_alwaysPresent.UseVisualStyleBackColor = true;
            this.ckb_alwaysPresent.CheckedChanged += new System.EventHandler(this.ckb_alwaysPresent_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(462, 444);
            this.Controls.Add(this.ckb_alwaysPresent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckb_startMinimized);
            this.Controls.Add(this.ckb_autoStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckb_active1);
            this.Controls.Add(this.ckb_shift1);
            this.Controls.Add(this.ckb_alt1);
            this.Controls.Add(this.ckb_ctrl1);
            this.Controls.Add(this.cb_key1);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.ckb_active0);
            this.Controls.Add(this.ckb_shift0);
            this.Controls.Add(this.ckb_alt0);
            this.Controls.Add(this.ckb_ctrl0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_key0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "My Tools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
