namespace Algorithm_Encryption
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.RSAButton = new System.Windows.Forms.Button();
            this.GostButton = new System.Windows.Forms.Button();
            this.RC4Button = new System.Windows.Forms.Button();
            this.AESButton = new System.Windows.Forms.Button();
            this.El_GamalButton = new System.Windows.Forms.Button();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.TimerStartWork = new System.Windows.Forms.Timer(this.components);
            this.CamelliaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RSAButton
            // 
            this.RSAButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RSAButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RSAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RSAButton.Location = new System.Drawing.Point(101, 88);
            this.RSAButton.Name = "RSAButton";
            this.RSAButton.Size = new System.Drawing.Size(169, 79);
            this.RSAButton.TabIndex = 1;
            this.RSAButton.Tag = "";
            this.RSAButton.Text = "RSA";
            this.RSAButton.UseVisualStyleBackColor = true;
            this.RSAButton.Click += new System.EventHandler(this.RSAButton_Click);
            // 
            // GostButton
            // 
            this.GostButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GostButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GostButton.Location = new System.Drawing.Point(333, 88);
            this.GostButton.Name = "GostButton";
            this.GostButton.Size = new System.Drawing.Size(170, 79);
            this.GostButton.TabIndex = 2;
            this.GostButton.Text = "ГОСТ";
            this.GostButton.UseVisualStyleBackColor = true;
            this.GostButton.Click += new System.EventHandler(this.GostButton_Click);
            // 
            // RC4Button
            // 
            this.RC4Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RC4Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RC4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RC4Button.Location = new System.Drawing.Point(334, 230);
            this.RC4Button.Name = "RC4Button";
            this.RC4Button.Size = new System.Drawing.Size(169, 79);
            this.RC4Button.TabIndex = 3;
            this.RC4Button.Text = "RC4";
            this.RC4Button.UseVisualStyleBackColor = true;
            this.RC4Button.Click += new System.EventHandler(this.RC4Button_Click);
            // 
            // AESButton
            // 
            this.AESButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AESButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AESButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AESButton.Location = new System.Drawing.Point(570, 88);
            this.AESButton.Name = "AESButton";
            this.AESButton.Size = new System.Drawing.Size(169, 79);
            this.AESButton.TabIndex = 4;
            this.AESButton.Text = "AES";
            this.AESButton.UseVisualStyleBackColor = true;
            this.AESButton.Click += new System.EventHandler(this.AESButton_Click);
            // 
            // El_GamalButton
            // 
            this.El_GamalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.El_GamalButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.El_GamalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.El_GamalButton.Location = new System.Drawing.Point(570, 227);
            this.El_GamalButton.Name = "El_GamalButton";
            this.El_GamalButton.Size = new System.Drawing.Size(169, 79);
            this.El_GamalButton.TabIndex = 5;
            this.El_GamalButton.Text = "El-Gamal";
            this.El_GamalButton.UseVisualStyleBackColor = true;
            this.El_GamalButton.Click += new System.EventHandler(this.El_GamalButton_Click);
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelloLabel.Location = new System.Drawing.Point(-8, -1);
            this.HelloLabel.MaximumSize = new System.Drawing.Size(833, 500);
            this.HelloLabel.MinimumSize = new System.Drawing.Size(833, 500);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(833, 500);
            this.HelloLabel.TabIndex = 6;
            this.HelloLabel.Text = "&Вас приветствует приложение \"Алгоритмы шифрования\"";
            this.HelloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HelloLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HelloLabel_MouseMove);
            // 
            // TimerStartWork
            // 
            this.TimerStartWork.Interval = 2000;
            this.TimerStartWork.Tick += new System.EventHandler(this.TimerStartWork_Tick);
            // 
            // CamelliaButton
            // 
            this.CamelliaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CamelliaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CamelliaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CamelliaButton.Location = new System.Drawing.Point(101, 230);
            this.CamelliaButton.Name = "CamelliaButton";
            this.CamelliaButton.Size = new System.Drawing.Size(169, 79);
            this.CamelliaButton.TabIndex = 7;
            this.CamelliaButton.Text = "Camellia";
            this.CamelliaButton.UseVisualStyleBackColor = true;
            this.CamelliaButton.Click += new System.EventHandler(this.CamelliaButton_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(817, 491);
            this.Controls.Add(this.HelloLabel);
            this.Controls.Add(this.CamelliaButton);
            this.Controls.Add(this.El_GamalButton);
            this.Controls.Add(this.AESButton);
            this.Controls.Add(this.RC4Button);
            this.Controls.Add(this.GostButton);
            this.Controls.Add(this.RSAButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(833, 530);
            this.MinimumSize = new System.Drawing.Size(833, 530);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Алгоритмы шифрования";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RSAButton;
        private System.Windows.Forms.Button GostButton;
        private System.Windows.Forms.Button RC4Button;
        private System.Windows.Forms.Button AESButton;
        private System.Windows.Forms.Button El_GamalButton;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.Timer TimerStartWork;
        private System.Windows.Forms.Button CamelliaButton;
    }
}

