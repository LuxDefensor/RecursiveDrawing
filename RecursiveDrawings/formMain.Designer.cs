namespace RecursiveDrawings
{
    partial class formMain
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrawType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCircles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKoch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuForeColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLineWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuDrawType,
            this.menuSettings,
            this.menuWindow});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.MdiWindowListItem = this.menuWindow;
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(690, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(92, 22);
            this.menuExit.Text = "Exit";
            // 
            // menuDrawType
            // 
            this.menuDrawType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCircles,
            this.menuKoch});
            this.menuDrawType.Name = "menuDrawType";
            this.menuDrawType.Size = new System.Drawing.Size(77, 20);
            this.menuDrawType.Text = "Draw types";
            // 
            // menuCircles
            // 
            this.menuCircles.Name = "menuCircles";
            this.menuCircles.Size = new System.Drawing.Size(162, 22);
            this.menuCircles.Text = "Circles";
            // 
            // menuKoch
            // 
            this.menuKoch.Name = "menuKoch";
            this.menuKoch.Size = new System.Drawing.Size(162, 22);
            this.menuKoch.Text = "Koch snowflakes";
            // 
            // menuSettings
            // 
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuForeColor,
            this.menuBackColor,
            this.menuLineWeight,
            this.menuSize});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(61, 20);
            this.menuSettings.Text = "Settings";
            // 
            // menuForeColor
            // 
            this.menuForeColor.Name = "menuForeColor";
            this.menuForeColor.Size = new System.Drawing.Size(204, 22);
            this.menuForeColor.Text = "Forecolor";
            // 
            // menuBackColor
            // 
            this.menuBackColor.Name = "menuBackColor";
            this.menuBackColor.Size = new System.Drawing.Size(204, 22);
            this.menuBackColor.Text = "BackColor";
            // 
            // menuSize
            // 
            this.menuSize.Name = "menuSize";
            this.menuSize.Size = new System.Drawing.Size(204, 22);
            this.menuSize.Text = "Canvas size (1920 x 1080)";
            // 
            // menuWindow
            // 
            this.menuWindow.Name = "menuWindow";
            this.menuWindow.Size = new System.Drawing.Size(63, 20);
            this.menuWindow.Text = "Window";
            // 
            // menuLineWeight
            // 
            this.menuLineWeight.Name = "menuLineWeight";
            this.menuLineWeight.Size = new System.Drawing.Size(204, 22);
            this.menuLineWeight.Text = "Line weight = 1";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 541);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "formMain";
            this.Text = "Recursive Drawings";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuDrawType;
        private System.Windows.Forms.ToolStripMenuItem menuWindow;
        private System.Windows.Forms.ToolStripMenuItem menuCircles;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuForeColor;
        private System.Windows.Forms.ToolStripMenuItem menuBackColor;
        private System.Windows.Forms.ToolStripMenuItem menuSize;
        private System.Windows.Forms.ToolStripMenuItem menuKoch;
        private System.Windows.Forms.ToolStripMenuItem menuLineWeight;
    }
}