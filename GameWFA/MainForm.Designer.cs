namespace GameWFA
{
    partial class MainForm
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
            this.createCharBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.levelupBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createCharBtn
            // 
            this.createCharBtn.Location = new System.Drawing.Point(12, 12);
            this.createCharBtn.Name = "createCharBtn";
            this.createCharBtn.Size = new System.Drawing.Size(103, 23);
            this.createCharBtn.TabIndex = 0;
            this.createCharBtn.Text = "Create character";
            this.createCharBtn.UseVisualStyleBackColor = true;
            this.createCharBtn.Click += new System.EventHandler(this.createCharBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 42);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            // 
            // levelupBtn
            // 
            this.levelupBtn.Location = new System.Drawing.Point(12, 72);
            this.levelupBtn.Name = "levelupBtn";
            this.levelupBtn.Size = new System.Drawing.Size(75, 23);
            this.levelupBtn.TabIndex = 2;
            this.levelupBtn.Text = "Level Up";
            this.levelupBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 455);
            this.Controls.Add(this.levelupBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.createCharBtn);
            this.Name = "MainForm";
            this.Text = "Project Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createCharBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button levelupBtn;
    }
}

