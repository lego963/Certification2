﻿namespace GameWFA
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
            this.coordsLbl = new System.Windows.Forms.Label();
            this.costLbl = new System.Windows.Forms.Label();
            this.currentstatesLbl = new System.Windows.Forms.Label();
            this.gamePnl = new System.Windows.Forms.Panel();
            this.waveLbl = new System.Windows.Forms.Label();
            this.gameTmr = new System.Windows.Forms.Timer(this.components);
            this.buyMinionBtn = new System.Windows.Forms.Button();
            this.minionCostLbl = new System.Windows.Forms.Label();
            this.logandbtnPnl.SuspendLayout();
            this.gamePnl.SuspendLayout();
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
            this.levelupBtn.Location = new System.Drawing.Point(12, 93);
            this.levelupBtn.Name = "levelupBtn";
            this.levelupBtn.Size = new System.Drawing.Size(75, 23);
            this.levelupBtn.TabIndex = 2;
            this.levelupBtn.Text = "Level Up";
            this.levelupBtn.UseVisualStyleBackColor = true;
            this.levelupBtn.Click += new System.EventHandler(this.levelupBtn_Click);
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
            this.logLbl.Location = new System.Drawing.Point(12, 148);
            this.logLbl.Name = "logLbl";
            this.logLbl.Size = new System.Drawing.Size(220, 170);
            this.logLbl.TabIndex = 4;
            this.logLbl.Text = "Game Log";
            // 
            // logandbtnPnl
            // 
            this.logandbtnPnl.Controls.Add(this.minionCostLbl);
            this.logandbtnPnl.Controls.Add(this.buyMinionBtn);
            this.logandbtnPnl.Controls.Add(this.coordsLbl);
            this.logandbtnPnl.Controls.Add(this.costLbl);
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
            // coordsLbl
            // 
            this.coordsLbl.AutoSize = true;
            this.coordsLbl.Location = new System.Drawing.Point(12, 576);
            this.coordsLbl.Name = "coordsLbl";
            this.coordsLbl.Size = new System.Drawing.Size(36, 13);
            this.coordsLbl.TabIndex = 8;
            this.coordsLbl.Text = "X: ; Y:";
            // 
            // costLbl
            // 
            this.costLbl.AutoSize = true;
            this.costLbl.Location = new System.Drawing.Point(93, 98);
            this.costLbl.Name = "costLbl";
            this.costLbl.Size = new System.Drawing.Size(79, 13);
            this.costLbl.TabIndex = 7;
            this.costLbl.Text = "Level Up cost: ";
            // 
            // currentstatesLbl
            // 
            this.currentstatesLbl.AutoSize = true;
            this.currentstatesLbl.Location = new System.Drawing.Point(12, 318);
            this.currentstatesLbl.Name = "currentstatesLbl";
            this.currentstatesLbl.Size = new System.Drawing.Size(69, 13);
            this.currentstatesLbl.TabIndex = 6;
            this.currentstatesLbl.Text = "Current State";
            // 
            // gamePnl
            // 
            this.gamePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gamePnl.Controls.Add(this.waveLbl);
            this.gamePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePnl.Location = new System.Drawing.Point(238, 0);
            this.gamePnl.Name = "gamePnl";
            this.gamePnl.Size = new System.Drawing.Size(833, 637);
            this.gamePnl.TabIndex = 6;
            this.gamePnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gamePnl_MouseMove);
            // 
            // waveLbl
            // 
            this.waveLbl.AutoSize = true;
            this.waveLbl.Location = new System.Drawing.Point(741, 4);
            this.waveLbl.Name = "waveLbl";
            this.waveLbl.Size = new System.Drawing.Size(42, 13);
            this.waveLbl.TabIndex = 0;
            this.waveLbl.Text = "Wave: ";
            // 
            // gameTmr
            // 
            this.gameTmr.Tick += new System.EventHandler(this.gameTmr_Tick);
            // 
            // buyMinionBtn
            // 
            this.buyMinionBtn.Location = new System.Drawing.Point(12, 122);
            this.buyMinionBtn.Name = "buyMinionBtn";
            this.buyMinionBtn.Size = new System.Drawing.Size(75, 23);
            this.buyMinionBtn.TabIndex = 9;
            this.buyMinionBtn.Text = "Buy minion";
            this.buyMinionBtn.UseVisualStyleBackColor = true;
            this.buyMinionBtn.Click += new System.EventHandler(this.buyMinionBtn_Click);
            // 
            // minionCostLbl
            // 
            this.minionCostLbl.AutoSize = true;
            this.minionCostLbl.Location = new System.Drawing.Point(92, 127);
            this.minionCostLbl.Name = "minionCostLbl";
            this.minionCostLbl.Size = new System.Drawing.Size(64, 13);
            this.minionCostLbl.TabIndex = 10;
            this.minionCostLbl.Text = "Minion cost:";
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
            this.gamePnl.ResumeLayout(false);
            this.gamePnl.PerformLayout();
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
        private System.Windows.Forms.Label costLbl;
        private System.Windows.Forms.Label waveLbl;
        private System.Windows.Forms.Label coordsLbl;
        private System.Windows.Forms.Label minionCostLbl;
        private System.Windows.Forms.Button buyMinionBtn;
    }
}

