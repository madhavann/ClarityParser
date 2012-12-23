namespace ClarityData
{
    partial class ClarityDataParser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseOutlook = new System.Windows.Forms.Button();
            this.ParseReport = new System.Windows.Forms.Button();
            this.GetClarityReport = new System.Windows.Forms.Button();
            this.lblStatusOutput = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseOutlook);
            this.panel1.Controls.Add(this.ParseReport);
            this.panel1.Controls.Add(this.GetClarityReport);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 50);
            this.panel1.TabIndex = 0;
            // 
            // CloseOutlook
            // 
            this.CloseOutlook.Location = new System.Drawing.Point(304, 12);
            this.CloseOutlook.Name = "CloseOutlook";
            this.CloseOutlook.Size = new System.Drawing.Size(126, 23);
            this.CloseOutlook.TabIndex = 2;
            this.CloseOutlook.Text = "Close Outlook";
            this.CloseOutlook.UseVisualStyleBackColor = true;
            this.CloseOutlook.Click += new System.EventHandler(this.CloseOutlookClick);
            // 
            // ParseReport
            // 
            this.ParseReport.Location = new System.Drawing.Point(158, 12);
            this.ParseReport.Name = "ParseReport";
            this.ParseReport.Size = new System.Drawing.Size(117, 23);
            this.ParseReport.TabIndex = 1;
            this.ParseReport.Text = "Parse Clarity Report";
            this.ParseReport.UseVisualStyleBackColor = true;
            this.ParseReport.Click += new System.EventHandler(this.ParseReportClick);
            // 
            // GetClarityReport
            // 
            this.GetClarityReport.Location = new System.Drawing.Point(21, 12);
            this.GetClarityReport.Name = "GetClarityReport";
            this.GetClarityReport.Size = new System.Drawing.Size(117, 23);
            this.GetClarityReport.TabIndex = 0;
            this.GetClarityReport.Text = "Get Clarity Report";
            this.GetClarityReport.UseVisualStyleBackColor = true;
            this.GetClarityReport.Click += new System.EventHandler(this.GetClarityReportClick);
            // 
            // lblStatusOutput
            // 
            this.lblStatusOutput.AutoSize = true;
            this.lblStatusOutput.Location = new System.Drawing.Point(17, 18);
            this.lblStatusOutput.Name = "lblStatusOutput";
            this.lblStatusOutput.Size = new System.Drawing.Size(41, 13);
            this.lblStatusOutput.TabIndex = 1;
            this.lblStatusOutput.Text = "Display\r\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblStatusOutput);
            this.panel2.Location = new System.Drawing.Point(13, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 57);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Actions";
            // 
            // ClarityDataParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 252);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClarityDataParser";
            this.Text = "Clarity Data Parser";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ParseReport;
        private System.Windows.Forms.Button GetClarityReport;
        private System.Windows.Forms.Label lblStatusOutput;
        private System.Windows.Forms.Button CloseOutlook;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

