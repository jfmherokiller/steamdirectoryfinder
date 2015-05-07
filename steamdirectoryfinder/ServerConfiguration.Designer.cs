using System.ComponentModel;
using System.Windows.Forms;

namespace steamdirectoryfinder
{
    partial class ServerConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ep1 = new System.Windows.Forms.CheckBox();
            this.ep2 = new System.Windows.Forms.CheckBox();
            this.lostcoast = new System.Windows.Forms.CheckBox();
            this.dod = new System.Windows.Forms.CheckBox();
            this.css = new System.Windows.Forms.CheckBox();
            this.hl1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Install server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Please insert your Steam username and password";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(119, 49);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(96, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Steam Auth Fix";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hl1);
            this.groupBox1.Controls.Add(this.css);
            this.groupBox1.Controls.Add(this.dod);
            this.groupBox1.Controls.Add(this.lostcoast);
            this.groupBox1.Controls.Add(this.ep2);
            this.groupBox1.Controls.Add(this.ep1);
            this.groupBox1.Location = new System.Drawing.Point(119, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disabled Mounts";
            // 
            // ep1
            // 
            this.ep1.AutoSize = true;
            this.ep1.Location = new System.Drawing.Point(7, 16);
            this.ep1.Name = "ep1";
            this.ep1.Size = new System.Drawing.Size(44, 17);
            this.ep1.TabIndex = 0;
            this.ep1.Text = "ep1";
            this.ep1.UseVisualStyleBackColor = true;
            // 
            // ep2
            // 
            this.ep2.AutoSize = true;
            this.ep2.Location = new System.Drawing.Point(58, 16);
            this.ep2.Name = "ep2";
            this.ep2.Size = new System.Drawing.Size(44, 17);
            this.ep2.TabIndex = 1;
            this.ep2.Text = "ep2";
            this.ep2.UseVisualStyleBackColor = true;
            // 
            // lostcoast
            // 
            this.lostcoast.AutoSize = true;
            this.lostcoast.Location = new System.Drawing.Point(108, 16);
            this.lostcoast.Name = "lostcoast";
            this.lostcoast.Size = new System.Drawing.Size(68, 17);
            this.lostcoast.TabIndex = 2;
            this.lostcoast.Text = "lostcoast";
            this.lostcoast.UseVisualStyleBackColor = true;
            // 
            // dod
            // 
            this.dod.AutoSize = true;
            this.dod.Location = new System.Drawing.Point(7, 40);
            this.dod.Name = "dod";
            this.dod.Size = new System.Drawing.Size(44, 17);
            this.dod.TabIndex = 3;
            this.dod.Text = "dod";
            this.dod.UseVisualStyleBackColor = true;
            // 
            // css
            // 
            this.css.AutoSize = true;
            this.css.Location = new System.Drawing.Point(58, 40);
            this.css.Name = "css";
            this.css.Size = new System.Drawing.Size(42, 17);
            this.css.TabIndex = 4;
            this.css.Text = "css";
            this.css.UseVisualStyleBackColor = true;
            // 
            // hl1
            // 
            this.hl1.AutoSize = true;
            this.hl1.Location = new System.Drawing.Point(107, 40);
            this.hl1.Name = "hl1";
            this.hl1.Size = new System.Drawing.Size(40, 17);
            this.hl1.TabIndex = 5;
            this.hl1.Text = "hl1";
            this.hl1.UseVisualStyleBackColor = true;
            // 
            // ServerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 310);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ServerConfiguration";
            this.Text = "ServerConfiguration";
            this.Load += new System.EventHandler(this.ServerConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label2;
        private Label label3;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
        private CheckBox ep1;
        private CheckBox lostcoast;
        private CheckBox ep2;
        private CheckBox css;
        private CheckBox dod;
        private CheckBox hl1;
    }
}