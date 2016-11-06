namespace GameWFA
{
    partial class CreateCharacter
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.classCmbB = new System.Windows.Forms.ComboBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.classLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 51);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(82, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Character name";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(100, 48);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(227, 20);
            this.nameTxt.TabIndex = 1;
            // 
            // classCmbB
            // 
            this.classCmbB.FormattingEnabled = true;
            this.classCmbB.Items.AddRange(new object[] {
            "Griffin",
            "Knight",
            "Crusader"});
            this.classCmbB.Location = new System.Drawing.Point(100, 104);
            this.classCmbB.Name = "classCmbB";
            this.classCmbB.Size = new System.Drawing.Size(227, 21);
            this.classCmbB.TabIndex = 2;
            this.classCmbB.Text = "Unknown";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(128, 213);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 3;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // classLbl
            // 
            this.classLbl.AutoSize = true;
            this.classLbl.Location = new System.Drawing.Point(12, 107);
            this.classLbl.Name = "classLbl";
            this.classLbl.Size = new System.Drawing.Size(80, 13);
            this.classLbl.TabIndex = 4;
            this.classLbl.Text = "Character class";
            // 
            // CreateCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 248);
            this.Controls.Add(this.classLbl);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.classCmbB);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.nameLbl);
            this.Name = "CreateCharacter";
            this.Text = "CreateCharacter";
            this.Load += new System.EventHandler(this.CreateCharacter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.ComboBox classCmbB;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Label classLbl;
    }
}