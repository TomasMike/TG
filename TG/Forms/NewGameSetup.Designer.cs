namespace TG.Forms
{
    partial class NewGameSetup
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
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.p4panel = new System.Windows.Forms.Panel();
            this.p4name = new System.Windows.Forms.TextBox();
            this.p4char = new System.Windows.Forms.ComboBox();
            this.p4arch = new System.Windows.Forms.ComboBox();
            this.p3panel = new System.Windows.Forms.Panel();
            this.p3name = new System.Windows.Forms.TextBox();
            this.p3char = new System.Windows.Forms.ComboBox();
            this.p3arch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.p2panel = new System.Windows.Forms.Panel();
            this.p2name = new System.Windows.Forms.TextBox();
            this.p2char = new System.Windows.Forms.ComboBox();
            this.p2arch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.p1panel = new System.Windows.Forms.Panel();
            this.p1name = new System.Windows.Forms.TextBox();
            this.p1char = new System.Windows.Forms.ComboBox();
            this.p1arch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.p4panel.SuspendLayout();
            this.p3panel.SuspendLayout();
            this.p2panel.SuspendLayout();
            this.p1panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Player 4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add Player 2";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 9;
            this.button2.Text = "Add Player 3";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add Player 4";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Player Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Character";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Archetype";
            // 
            // p4panel
            // 
            this.p4panel.Controls.Add(this.p4name);
            this.p4panel.Controls.Add(this.p4char);
            this.p4panel.Controls.Add(this.p4arch);
            this.p4panel.Controls.Add(this.label4);
            this.p4panel.Location = new System.Drawing.Point(96, 146);
            this.p4panel.Name = "p4panel";
            this.p4panel.Size = new System.Drawing.Size(417, 31);
            this.p4panel.TabIndex = 28;
            // 
            // p4name
            // 
            this.p4name.Location = new System.Drawing.Point(54, 0);
            this.p4name.Name = "p4name";
            this.p4name.Size = new System.Drawing.Size(100, 20);
            this.p4name.TabIndex = 0;
            this.p4name.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateNameBoxes);
            // 
            // p4char
            // 
            this.p4char.FormattingEnabled = true;
            this.p4char.Location = new System.Drawing.Point(160, 0);
            this.p4char.Name = "p4char";
            this.p4char.Size = new System.Drawing.Size(121, 21);
            this.p4char.TabIndex = 12;
            // 
            // p4arch
            // 
            this.p4arch.FormattingEnabled = true;
            this.p4arch.Location = new System.Drawing.Point(287, 3);
            this.p4arch.Name = "p4arch";
            this.p4arch.Size = new System.Drawing.Size(121, 21);
            this.p4arch.TabIndex = 16;
            // 
            // p3panel
            // 
            this.p3panel.Controls.Add(this.p3name);
            this.p3panel.Controls.Add(this.p3char);
            this.p3panel.Controls.Add(this.p3arch);
            this.p3panel.Controls.Add(this.label1);
            this.p3panel.Location = new System.Drawing.Point(96, 109);
            this.p3panel.Name = "p3panel";
            this.p3panel.Size = new System.Drawing.Size(417, 31);
            this.p3panel.TabIndex = 29;
            // 
            // p3name
            // 
            this.p3name.Location = new System.Drawing.Point(54, 0);
            this.p3name.Name = "p3name";
            this.p3name.Size = new System.Drawing.Size(100, 20);
            this.p3name.TabIndex = 0;
            this.p3name.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateNameBoxes);
            // 
            // p3char
            // 
            this.p3char.FormattingEnabled = true;
            this.p3char.Location = new System.Drawing.Point(160, 0);
            this.p3char.Name = "p3char";
            this.p3char.Size = new System.Drawing.Size(121, 21);
            this.p3char.TabIndex = 12;
            // 
            // p3arch
            // 
            this.p3arch.FormattingEnabled = true;
            this.p3arch.Location = new System.Drawing.Point(287, 3);
            this.p3arch.Name = "p3arch";
            this.p3arch.Size = new System.Drawing.Size(121, 21);
            this.p3arch.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player 3";
            // 
            // p2panel
            // 
            this.p2panel.Controls.Add(this.p2name);
            this.p2panel.Controls.Add(this.p2char);
            this.p2panel.Controls.Add(this.p2arch);
            this.p2panel.Controls.Add(this.label2);
            this.p2panel.Location = new System.Drawing.Point(96, 72);
            this.p2panel.Name = "p2panel";
            this.p2panel.Size = new System.Drawing.Size(417, 31);
            this.p2panel.TabIndex = 29;
            // 
            // p2name
            // 
            this.p2name.Location = new System.Drawing.Point(54, 0);
            this.p2name.Name = "p2name";
            this.p2name.Size = new System.Drawing.Size(100, 20);
            this.p2name.TabIndex = 0;
            this.p2name.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateNameBoxes);
            // 
            // p2char
            // 
            this.p2char.FormattingEnabled = true;
            this.p2char.Location = new System.Drawing.Point(160, 0);
            this.p2char.Name = "p2char";
            this.p2char.Size = new System.Drawing.Size(121, 21);
            this.p2char.TabIndex = 12;
            // 
            // p2arch
            // 
            this.p2arch.FormattingEnabled = true;
            this.p2arch.Location = new System.Drawing.Point(287, 3);
            this.p2arch.Name = "p2arch";
            this.p2arch.Size = new System.Drawing.Size(121, 21);
            this.p2arch.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Player 2";
            // 
            // p1panel
            // 
            this.p1panel.Controls.Add(this.p1name);
            this.p1panel.Controls.Add(this.p1char);
            this.p1panel.Controls.Add(this.p1arch);
            this.p1panel.Controls.Add(this.label3);
            this.p1panel.Location = new System.Drawing.Point(96, 35);
            this.p1panel.Name = "p1panel";
            this.p1panel.Size = new System.Drawing.Size(417, 31);
            this.p1panel.TabIndex = 29;
            // 
            // p1name
            // 
            this.p1name.Location = new System.Drawing.Point(54, 0);
            this.p1name.Name = "p1name";
            this.p1name.Size = new System.Drawing.Size(100, 20);
            this.p1name.TabIndex = 0;
            this.p1name.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateNameBoxes);
            // 
            // p1char
            // 
            this.p1char.FormattingEnabled = true;
            this.p1char.Location = new System.Drawing.Point(160, 0);
            this.p1char.Name = "p1char";
            this.p1char.Size = new System.Drawing.Size(121, 21);
            this.p1char.TabIndex = 12;
            // 
            // p1arch
            // 
            this.p1arch.FormattingEnabled = true;
            this.p1arch.Location = new System.Drawing.Point(287, 3);
            this.p1arch.Name = "p1arch";
            this.p1arch.Size = new System.Drawing.Size(121, 21);
            this.p1arch.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Player 1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(210, 193);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 30;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // NewGameSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 225);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.p1panel);
            this.Controls.Add(this.p2panel);
            this.Controls.Add(this.p3panel);
            this.Controls.Add(this.p4panel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "NewGameSetup";
            this.Text = "NewGameSetupcs";
            this.Load += new System.EventHandler(this.NewGameSetupcs_Load);
            this.p4panel.ResumeLayout(false);
            this.p4panel.PerformLayout();
            this.p3panel.ResumeLayout(false);
            this.p3panel.PerformLayout();
            this.p2panel.ResumeLayout(false);
            this.p2panel.PerformLayout();
            this.p1panel.ResumeLayout(false);
            this.p1panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel p4panel;
        private System.Windows.Forms.TextBox p4name;
        private System.Windows.Forms.ComboBox p4char;
        private System.Windows.Forms.ComboBox p4arch;
        private System.Windows.Forms.Panel p3panel;
        private System.Windows.Forms.TextBox p3name;
        private System.Windows.Forms.ComboBox p3char;
        private System.Windows.Forms.ComboBox p3arch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel p2panel;
        private System.Windows.Forms.TextBox p2name;
        private System.Windows.Forms.ComboBox p2char;
        private System.Windows.Forms.ComboBox p2arch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel p1panel;
        private System.Windows.Forms.TextBox p1name;
        private System.Windows.Forms.ComboBox p1char;
        private System.Windows.Forms.ComboBox p1arch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button4;
    }
}