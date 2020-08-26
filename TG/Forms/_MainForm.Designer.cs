using TG.PlayerCharacterItems;

namespace TG.Forms
{
    partial class _MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niecoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.cheatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreEnergyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.foodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.cheatsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.niecoToolStripMenuItem,
            this.endDayToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "menu";
            // 
            // niecoToolStripMenuItem
            // 
            this.niecoToolStripMenuItem.Name = "niecoToolStripMenuItem";
            this.niecoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.niecoToolStripMenuItem.Text = "Save";
            this.niecoToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // endDayToolStripMenuItem
            // 
            this.endDayToolStripMenuItem.Name = "endDayToolStripMenuItem";
            this.endDayToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.endDayToolStripMenuItem.Text = "End Day";
            this.endDayToolStripMenuItem.Click += new System.EventHandler(this.endDayToolStripMenuItem_Click);
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(0, 24);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(956, 654);
            this.mainContentPanel.TabIndex = 1;
            // 
            // cheatsToolStripMenuItem
            // 
            this.cheatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreEnergyToolStripMenuItem,
            this.foodToolStripMenuItem});
            this.cheatsToolStripMenuItem.Name = "cheatsToolStripMenuItem";
            this.cheatsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cheatsToolStripMenuItem.Text = "Cheats";
            // 
            // restoreEnergyToolStripMenuItem
            // 
            this.restoreEnergyToolStripMenuItem.Name = "restoreEnergyToolStripMenuItem";
            this.restoreEnergyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restoreEnergyToolStripMenuItem.Text = "Restore Energy";
            this.restoreEnergyToolStripMenuItem.Click += new System.EventHandler(this.restoreEnergyToolStripMenuItem_Click);
            // 
            // questionFormBindingSource
            // 
            this.questionFormBindingSource.DataSource = typeof(TG.PlayerCharacterItems.Character);
            // 
            // foodToolStripMenuItem
            // 
            this.foodToolStripMenuItem.Name = "foodToolStripMenuItem";
            this.foodToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.foodToolStripMenuItem.Text = "+10 Food";
            this.foodToolStripMenuItem.Click += new System.EventHandler(this.foodToolStripMenuItem_Click);
            // 
            // _MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(956, 678);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "_MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niecoToolStripMenuItem;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.BindingSource questionFormBindingSource;
        private System.Windows.Forms.ToolStripMenuItem endDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreEnergyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foodToolStripMenuItem;
    }
}

