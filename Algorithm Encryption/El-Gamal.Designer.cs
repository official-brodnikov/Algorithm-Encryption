namespace Algorithm_Encryption
{
    partial class El_Gamal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(El_Gamal));
            this.InputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.YKeyTB = new System.Windows.Forms.TextBox();
            this.EncButton = new System.Windows.Forms.Button();
            this.DecButton = new System.Windows.Forms.Button();
            this.PKeyTB = new System.Windows.Forms.TextBox();
            this.GKeyTB = new System.Windows.Forms.TextBox();
            this.XKeyTB = new System.Windows.Forms.TextBox();
            this.PLabel = new System.Windows.Forms.Label();
            this.TimerAlgorithm = new System.Windows.Forms.Timer(this.components);
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SecondsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьЦветЗаливкиТекстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обалгоритмеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.опрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadTextButton = new System.Windows.Forms.Button();
            this.SaveTextButton = new System.Windows.Forms.Button();
            this.GenKeyButton = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.SaveKeyButton = new System.Windows.Forms.Button();
            this.StatusStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputRichTextBox
            // 
            this.InputRichTextBox.Location = new System.Drawing.Point(12, 199);
            this.InputRichTextBox.Name = "InputRichTextBox";
            this.InputRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.InputRichTextBox.Size = new System.Drawing.Size(288, 210);
            this.InputRichTextBox.TabIndex = 2;
            this.InputRichTextBox.Text = "";
            this.InputRichTextBox.TextChanged += new System.EventHandler(this.InputRichTextBox_TextChanged);
            // 
            // OutputRichTextBox
            // 
            this.OutputRichTextBox.Location = new System.Drawing.Point(501, 199);
            this.OutputRichTextBox.Name = "OutputRichTextBox";
            this.OutputRichTextBox.ReadOnly = true;
            this.OutputRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.OutputRichTextBox.Size = new System.Drawing.Size(288, 210);
            this.OutputRichTextBox.TabIndex = 10;
            this.OutputRichTextBox.Text = "";
            // 
            // YKeyTB
            // 
            this.YKeyTB.Location = new System.Drawing.Point(212, 113);
            this.YKeyTB.Name = "YKeyTB";
            this.YKeyTB.ReadOnly = true;
            this.YKeyTB.Size = new System.Drawing.Size(403, 20);
            this.YKeyTB.TabIndex = 11;
            // 
            // EncButton
            // 
            this.EncButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EncButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncButton.Location = new System.Drawing.Point(178, 415);
            this.EncButton.Name = "EncButton";
            this.EncButton.Size = new System.Drawing.Size(122, 33);
            this.EncButton.TabIndex = 12;
            this.EncButton.Text = "Зашифровать";
            this.EncButton.UseVisualStyleBackColor = true;
            this.EncButton.Click += new System.EventHandler(this.EncButton_Click);
            // 
            // DecButton
            // 
            this.DecButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DecButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecButton.Location = new System.Drawing.Point(501, 415);
            this.DecButton.Name = "DecButton";
            this.DecButton.Size = new System.Drawing.Size(129, 33);
            this.DecButton.TabIndex = 13;
            this.DecButton.Text = "Расшифровать";
            this.DecButton.UseVisualStyleBackColor = true;
            this.DecButton.Click += new System.EventHandler(this.DecButton_Click);
            // 
            // PKeyTB
            // 
            this.PKeyTB.Location = new System.Drawing.Point(212, 61);
            this.PKeyTB.Name = "PKeyTB";
            this.PKeyTB.Size = new System.Drawing.Size(403, 20);
            this.PKeyTB.TabIndex = 14;
            this.PKeyTB.TextChanged += new System.EventHandler(this.InputRichTextBox_TextChanged);
            this.PKeyTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyTB_KeyPress);
            // 
            // GKeyTB
            // 
            this.GKeyTB.Location = new System.Drawing.Point(212, 87);
            this.GKeyTB.Name = "GKeyTB";
            this.GKeyTB.Size = new System.Drawing.Size(403, 20);
            this.GKeyTB.TabIndex = 15;
            this.GKeyTB.TextChanged += new System.EventHandler(this.InputRichTextBox_TextChanged);
            this.GKeyTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyTB_KeyPress);
            // 
            // XKeyTB
            // 
            this.XKeyTB.Location = new System.Drawing.Point(212, 139);
            this.XKeyTB.Name = "XKeyTB";
            this.XKeyTB.Size = new System.Drawing.Size(403, 20);
            this.XKeyTB.TabIndex = 16;
            this.XKeyTB.TextChanged += new System.EventHandler(this.InputRichTextBox_TextChanged);
            this.XKeyTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyTB_KeyPress);
            // 
            // PLabel
            // 
            this.PLabel.AutoSize = true;
            this.PLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PLabel.Location = new System.Drawing.Point(57, 60);
            this.PLabel.Name = "PLabel";
            this.PLabel.Size = new System.Drawing.Size(148, 18);
            this.PLabel.TabIndex = 17;
            this.PLabel.Text = "Открытые ключи : p";
            // 
            // TimerAlgorithm
            // 
            this.TimerAlgorithm.Tick += new System.EventHandler(this.TimerAlgorithm_Tick);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.SecondsToolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 466);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(817, 25);
            this.StatusStrip.TabIndex = 18;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(356, 20);
            this.ToolStripStatusLabel.Text = "Время выполнения алгоритма (в миллисекундах)";
            // 
            // SecondsToolStripStatusLabel
            // 
            this.SecondsToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SecondsToolStripStatusLabel.Name = "SecondsToolStripStatusLabel";
            this.SecondsToolStripStatusLabel.Size = new System.Drawing.Size(17, 20);
            this.SecondsToolStripStatusLabel.Text = "0";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(817, 24);
            this.MenuStrip.TabIndex = 19;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripSeparator,
            this.сохранитьToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьToolStripMenuItem.Image")));
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.открытьToolStripMenuItem.Text = "&Загрузить текст из файла";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(298, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить зашифрованный текст в файл";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(298, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(298, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(301, 22);
            this.выходToolStripMenuItem.Text = "Вы&ход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorToolStripMenuItem,
            this.выбратьЦветЗаливкиТекстаToolStripMenuItem,
            this.FontToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "&Сервис";
            // 
            // ColorToolStripMenuItem
            // 
            this.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem";
            this.ColorToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ColorToolStripMenuItem.Text = "&Выбрать цвет текста";
            this.ColorToolStripMenuItem.Click += new System.EventHandler(this.ColorToolStripMenuItem_Click);
            // 
            // выбратьЦветЗаливкиТекстаToolStripMenuItem
            // 
            this.выбратьЦветЗаливкиТекстаToolStripMenuItem.Name = "выбратьЦветЗаливкиТекстаToolStripMenuItem";
            this.выбратьЦветЗаливкиТекстаToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.выбратьЦветЗаливкиТекстаToolStripMenuItem.Text = "&Выбрать цвет заливки текста";
            this.выбратьЦветЗаливкиТекстаToolStripMenuItem.Click += new System.EventHandler(this.выбратьЦветЗаливкиТекстаToolStripMenuItem_Click);
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.FontToolStripMenuItem.Text = "&Выбрать шрифт текста";
            this.FontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обалгоритмеToolStripMenuItem,
            this.toolStripSeparator5,
            this.опрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Спра&вка";
            // 
            // обалгоритмеToolStripMenuItem
            // 
            this.обалгоритмеToolStripMenuItem.Name = "обалгоритмеToolStripMenuItem";
            this.обалгоритмеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.обалгоритмеToolStripMenuItem.Text = "&Об алгоритме";
            this.обалгоритмеToolStripMenuItem.Click += new System.EventHandler(this.обалгоритмеToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(155, 6);
            // 
            // опрограммеToolStripMenuItem
            // 
            this.опрограммеToolStripMenuItem.Name = "опрограммеToolStripMenuItem";
            this.опрограммеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.опрограммеToolStripMenuItem.Text = "&О программе...";
            this.опрограммеToolStripMenuItem.Click += new System.EventHandler(this.опрограммеToolStripMenuItem_Click);
            // 
            // GLabel
            // 
            this.GLabel.AutoSize = true;
            this.GLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GLabel.Location = new System.Drawing.Point(190, 86);
            this.GLabel.Name = "GLabel";
            this.GLabel.Size = new System.Drawing.Size(16, 18);
            this.GLabel.TabIndex = 20;
            this.GLabel.Text = "g";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.XLabel.Location = new System.Drawing.Point(67, 138);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(140, 18);
            this.XLabel.TabIndex = 21;
            this.XLabel.Text = "Закрытый ключ (x)";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YLabel.Location = new System.Drawing.Point(190, 113);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(15, 18);
            this.YLabel.TabIndex = 22;
            this.YLabel.Text = "y";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // LoadTextButton
            // 
            this.LoadTextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadTextButton.Location = new System.Drawing.Point(12, 415);
            this.LoadTextButton.Name = "LoadTextButton";
            this.LoadTextButton.Size = new System.Drawing.Size(93, 33);
            this.LoadTextButton.TabIndex = 23;
            this.LoadTextButton.Text = "Загрузить";
            this.LoadTextButton.UseVisualStyleBackColor = true;
            this.LoadTextButton.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // SaveTextButton
            // 
            this.SaveTextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveTextButton.Location = new System.Drawing.Point(696, 415);
            this.SaveTextButton.Name = "SaveTextButton";
            this.SaveTextButton.Size = new System.Drawing.Size(93, 33);
            this.SaveTextButton.TabIndex = 24;
            this.SaveTextButton.Text = "Сохранить";
            this.SaveTextButton.UseVisualStyleBackColor = true;
            this.SaveTextButton.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // GenKeyButton
            // 
            this.GenKeyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenKeyButton.Location = new System.Drawing.Point(339, 296);
            this.GenKeyButton.Name = "GenKeyButton";
            this.GenKeyButton.Size = new System.Drawing.Size(122, 47);
            this.GenKeyButton.TabIndex = 25;
            this.GenKeyButton.Text = "Сгенерировать ключи";
            this.GenKeyButton.UseVisualStyleBackColor = true;
            this.GenKeyButton.Click += new System.EventHandler(this.GenKeyButton_Click);
            // 
            // SaveKeyButton
            // 
            this.SaveKeyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveKeyButton.Location = new System.Drawing.Point(621, 86);
            this.SaveKeyButton.Name = "SaveKeyButton";
            this.SaveKeyButton.Size = new System.Drawing.Size(93, 45);
            this.SaveKeyButton.TabIndex = 26;
            this.SaveKeyButton.Text = "Сохранить ключи";
            this.SaveKeyButton.UseVisualStyleBackColor = true;
            this.SaveKeyButton.Click += new System.EventHandler(this.SaveKeyButton_Click);
            // 
            // El_Gamal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 491);
            this.Controls.Add(this.SaveKeyButton);
            this.Controls.Add(this.GenKeyButton);
            this.Controls.Add(this.SaveTextButton);
            this.Controls.Add(this.LoadTextButton);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.GLabel);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.PLabel);
            this.Controls.Add(this.XKeyTB);
            this.Controls.Add(this.GKeyTB);
            this.Controls.Add(this.PKeyTB);
            this.Controls.Add(this.DecButton);
            this.Controls.Add(this.EncButton);
            this.Controls.Add(this.YKeyTB);
            this.Controls.Add(this.OutputRichTextBox);
            this.Controls.Add(this.InputRichTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximumSize = new System.Drawing.Size(833, 530);
            this.MinimumSize = new System.Drawing.Size(833, 530);
            this.Name = "El_Gamal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "El-Gamal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.El_Gamal_FormClosing);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox InputRichTextBox;
        private System.Windows.Forms.RichTextBox OutputRichTextBox;
        private System.Windows.Forms.TextBox YKeyTB;
        private System.Windows.Forms.Button EncButton;
        private System.Windows.Forms.Button DecButton;
        private System.Windows.Forms.TextBox PKeyTB;
        private System.Windows.Forms.TextBox GKeyTB;
        private System.Windows.Forms.TextBox XKeyTB;
        private System.Windows.Forms.Label PLabel;
        private System.Windows.Forms.Timer TimerAlgorithm;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обалгоритмеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem опрограммеToolStripMenuItem;
        private System.Windows.Forms.Label GLabel;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button LoadTextButton;
        private System.Windows.Forms.Button SaveTextButton;
        private System.Windows.Forms.Button GenKeyButton;
        private System.Windows.Forms.ToolStripStatusLabel SecondsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ToolStripMenuItem ColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьЦветЗаливкиТекстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
        private System.Windows.Forms.Button SaveKeyButton;
    }
}