namespace steamdirectoryfinder
{
    partial class Client_Configuration
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
            this.hl2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.episodic = new System.Windows.Forms.CheckBox();
            this.ep2 = new System.Windows.Forms.CheckBox();
            this.lostcoast = new System.Windows.Forms.CheckBox();
            this.cstrike = new System.Windows.Forms.CheckBox();
            this.hl1 = new System.Windows.Forms.CheckBox();
            this.dod = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // hl2
            // 
            this.hl2.AutoSize = true;
            this.hl2.Checked = true;
            this.hl2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hl2.Location = new System.Drawing.Point(7, 63);
            this.hl2.Name = "hl2";
            this.hl2.Size = new System.Drawing.Size(74, 17);
            this.hl2.TabIndex = 0;
            this.hl2.Text = "Half Life 2";
            this.hl2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please deselect the mounts you do not want";
            // 
            // episodic
            // 
            this.episodic.AutoSize = true;
            this.episodic.Checked = true;
            this.episodic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.episodic.Location = new System.Drawing.Point(7, 86);
            this.episodic.Name = "episodic";
            this.episodic.Size = new System.Drawing.Size(127, 17);
            this.episodic.TabIndex = 2;
            this.episodic.Text = "Half Life 2: Episode 1";
            this.episodic.UseVisualStyleBackColor = true;
            // 
            // ep2
            // 
            this.ep2.AutoSize = true;
            this.ep2.Checked = true;
            this.ep2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ep2.Location = new System.Drawing.Point(7, 109);
            this.ep2.Name = "ep2";
            this.ep2.Size = new System.Drawing.Size(124, 17);
            this.ep2.TabIndex = 3;
            this.ep2.Text = "Half Life 2:Episode 2";
            this.ep2.UseVisualStyleBackColor = true;
            // 
            // lostcoast
            // 
            this.lostcoast.AutoSize = true;
            this.lostcoast.Checked = true;
            this.lostcoast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lostcoast.Location = new System.Drawing.Point(7, 132);
            this.lostcoast.Name = "lostcoast";
            this.lostcoast.Size = new System.Drawing.Size(126, 17);
            this.lostcoast.TabIndex = 4;
            this.lostcoast.Text = "Half Life 2: Lostcoast";
            this.lostcoast.UseVisualStyleBackColor = true;
            // 
            // cstrike
            // 
            this.cstrike.AutoSize = true;
            this.cstrike.Checked = true;
            this.cstrike.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cstrike.Location = new System.Drawing.Point(7, 155);
            this.cstrike.Name = "cstrike";
            this.cstrike.Size = new System.Drawing.Size(130, 17);
            this.cstrike.TabIndex = 5;
            this.cstrike.Text = "CounterStrike :Source";
            this.cstrike.UseVisualStyleBackColor = true;
            // 
            // hl1
            // 
            this.hl1.AutoSize = true;
            this.hl1.Checked = true;
            this.hl1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hl1.Location = new System.Drawing.Point(7, 40);
            this.hl1.Name = "hl1";
            this.hl1.Size = new System.Drawing.Size(74, 17);
            this.hl1.TabIndex = 6;
            this.hl1.Text = "Half Life 1";
            this.hl1.UseVisualStyleBackColor = true;
            // 
            // dod
            // 
            this.dod.AutoSize = true;
            this.dod.Checked = true;
            this.dod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dod.Location = new System.Drawing.Point(7, 178);
            this.dod.Name = "dod";
            this.dod.Size = new System.Drawing.Size(132, 17);
            this.dod.TabIndex = 7;
            this.dod.Text = "Day of Defeat: Source";
            this.dod.UseVisualStyleBackColor = true;
            // 
            // Client_Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 408);
            this.Controls.Add(this.dod);
            this.Controls.Add(this.hl1);
            this.Controls.Add(this.cstrike);
            this.Controls.Add(this.lostcoast);
            this.Controls.Add(this.ep2);
            this.Controls.Add(this.episodic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hl2);
            this.Name = "Client_Configuration";
            this.Text = "Client_Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox hl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox episodic;
        private System.Windows.Forms.CheckBox ep2;
        private System.Windows.Forms.CheckBox lostcoast;
        private System.Windows.Forms.CheckBox cstrike;
        private System.Windows.Forms.CheckBox hl1;
        private System.Windows.Forms.CheckBox dod;
    }
}