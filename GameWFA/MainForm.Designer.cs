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
            this.components = new System.ComponentModel.Container();
            this.createCharBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.levelupBtn = new System.Windows.Forms.Button();
            this.loaddataBtn = new System.Windows.Forms.Button();
            this.logLbl = new System.Windows.Forms.Label();
            this.logandbtnPnl = new System.Windows.Forms.Panel();
            this.currentstatesLbl = new System.Windows.Forms.Label();
            this.gamePnl = new System.Windows.Forms.Panel();
            this.gameTmr = new System.Windows.Forms.Timer(this.components);
            this.logandbtnPnl.SuspendLayout();
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
            this.startBtn.Location = new System.Drawing.Point(12, 56);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // levelupBtn
            // 
            this.levelupBtn.Location = new System.Drawing.Point(93, 56);
            this.levelupBtn.Name = "levelupBtn";
            this.levelupBtn.Size = new System.Drawing.Size(75, 23);
            this.levelupBtn.TabIndex = 2;
            this.levelupBtn.Text = "Level Up";
            this.levelupBtn.UseVisualStyleBackColor = true;
            // 
            // loaddataBtn
            // 
            this.loaddataBtn.Location = new System.Drawing.Point(129, 12);
            this.loaddataBtn.Name = "loaddataBtn";
            this.loaddataBtn.Size = new System.Drawing.Size(103, 23);
            this.loaddataBtn.TabIndex = 3;
            this.loaddataBtn.Text = "Load Data";
            this.loaddataBtn.UseVisualStyleBackColor = true;
            this.loaddataBtn.Click += new System.EventHandler(this.loaddataBtn_Click);
            // 
            // logLbl
            // 
            this.logLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logLbl.Location = new System.Drawing.Point(12, 102);
            this.logLbl.Name = "logLbl";
            this.logLbl.Size = new System.Drawing.Size(220, 170);
            this.logLbl.TabIndex = 4;
            this.logLbl.Text = "Game Log";
            // 
            // logandbtnPnl
            // 
            this.logandbtnPnl.Controls.Add(this.currentstatesLbl);
            this.logandbtnPnl.Controls.Add(this.loaddataBtn);
            this.logandbtnPnl.Controls.Add(this.logLbl);
            this.logandbtnPnl.Controls.Add(this.startBtn);
            this.logandbtnPnl.Controls.Add(this.levelupBtn);
            this.logandbtnPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.logandbtnPnl.Location = new System.Drawing.Point(0, 0);
            this.logandbtnPnl.Name = "logandbtnPnl";
            this.logandbtnPnl.Size = new System.Drawing.Size(238, 637);
            this.logandbtnPnl.TabIndex = 5;
            // 
            // currentstatesLbl
            // 
            this.currentstatesLbl.AutoSize = true;
            this.currentstatesLbl.Location = new System.Drawing.Point(12, 291);
            this.currentstatesLbl.Name = "currentstatesLbl";
            this.currentstatesLbl.Size = new System.Drawing.Size(69, 13);
            this.currentstatesLbl.TabIndex = 6;
            this.currentstatesLbl.Text = "Current State";
            // 
            // gamePnl
            // 
            this.gamePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gamePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePnl.Location = new System.Drawing.Point(238, 0);
            this.gamePnl.Name = "gamePnl";
            this.gamePnl.Size = new System.Drawing.Size(833, 637);
            this.gamePnl.TabIndex = 6;
            // 
            // gameTmr
            // 
            this.gameTmr.Tick += new System.EventHandler(this.gameTmr_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1071, 637);
            this.Controls.Add(this.gamePnl);
            this.Controls.Add(this.createCharBtn);
            this.Controls.Add(this.logandbtnPnl);
            this.Name = "MainForm";
            this.Text = "Project Form";
            this.logandbtnPnl.ResumeLayout(false);
            this.logandbtnPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createCharBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button levelupBtn;
        private System.Windows.Forms.Button loaddataBtn;
        private System.Windows.Forms.Label logLbl;
        private System.Windows.Forms.Panel logandbtnPnl;
        private System.Windows.Forms.Panel gamePnl;
        private System.Windows.Forms.Label currentstatesLbl;
        private System.Windows.Forms.Timer gameTmr;
    }
}

