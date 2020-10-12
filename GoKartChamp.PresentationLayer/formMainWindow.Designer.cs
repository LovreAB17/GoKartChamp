namespace GoKartChamp.PresentationLayer
{
    partial class formMainWindow
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
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upcomingRacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedRacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDriversToolStripMenuItem,
            this.addDriverToolStripMenuItem});
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // viewDriversToolStripMenuItem
            // 
            this.viewDriversToolStripMenuItem.Name = "viewDriversToolStripMenuItem";
            this.viewDriversToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewDriversToolStripMenuItem.Text = "View drivers";
            this.viewDriversToolStripMenuItem.Click += new System.EventHandler(this.viewDriversToolStripMenuItem_Click);
            // 
            // addDriverToolStripMenuItem
            // 
            this.addDriverToolStripMenuItem.Name = "addDriverToolStripMenuItem";
            this.addDriverToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addDriverToolStripMenuItem.Text = "Add driver";
            this.addDriverToolStripMenuItem.Click += new System.EventHandler(this.addDriversToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTracksToolStripMenuItem,
            this.addTrackToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "Tracks";
            // 
            // viewTracksToolStripMenuItem
            // 
            this.viewTracksToolStripMenuItem.Name = "viewTracksToolStripMenuItem";
            this.viewTracksToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.viewTracksToolStripMenuItem.Text = "View tracks";
            this.viewTracksToolStripMenuItem.Click += new System.EventHandler(this.viewTracksToolStripMenuItem_Click);
            // 
            // addTrackToolStripMenuItem
            // 
            this.addTrackToolStripMenuItem.Name = "addTrackToolStripMenuItem";
            this.addTrackToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addTrackToolStripMenuItem.Text = "Add track";
            this.addTrackToolStripMenuItem.Click += new System.EventHandler(this.AddTracksToolStripMenuItem_Click);
            // 
            // racesToolStripMenuItem
            // 
            this.racesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRacesToolStripMenuItem,
            this.addRaceToolStripMenuItem});
            this.racesToolStripMenuItem.Name = "racesToolStripMenuItem";
            this.racesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.racesToolStripMenuItem.Text = "Races";
            // 
            // viewRacesToolStripMenuItem
            // 
            this.viewRacesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upcomingRacesToolStripMenuItem,
            this.finishedRacesToolStripMenuItem});
            this.viewRacesToolStripMenuItem.Name = "viewRacesToolStripMenuItem";
            this.viewRacesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.viewRacesToolStripMenuItem.Text = "View races";
            // 
            // upcomingRacesToolStripMenuItem
            // 
            this.upcomingRacesToolStripMenuItem.Name = "upcomingRacesToolStripMenuItem";
            this.upcomingRacesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.upcomingRacesToolStripMenuItem.Text = "Upcoming races";
            this.upcomingRacesToolStripMenuItem.Click += new System.EventHandler(this.viewUpcomingRacesToolStripMenuItem_Click);
            // 
            // finishedRacesToolStripMenuItem
            // 
            this.finishedRacesToolStripMenuItem.Name = "finishedRacesToolStripMenuItem";
            this.finishedRacesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.finishedRacesToolStripMenuItem.Text = "Finished races";
            this.finishedRacesToolStripMenuItem.Click += new System.EventHandler(this.viewFinishedRacesToolStripMenuItem_Click);
            // 
            // addRaceToolStripMenuItem
            // 
            this.addRaceToolStripMenuItem.Name = "addRaceToolStripMenuItem";
            this.addRaceToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.addRaceToolStripMenuItem.Text = "Add race";
            this.addRaceToolStripMenuItem.Click += new System.EventHandler(this.AddRacesToolStripMenuItem_Click);
            // 
            // standingsToolStripMenuItem
            // 
            this.standingsToolStripMenuItem.Name = "standingsToolStripMenuItem";
            this.standingsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.standingsToolStripMenuItem.Text = "Standings";
            this.standingsToolStripMenuItem.Click += new System.EventHandler(this.viewStandingsToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driversToolStripMenuItem,
            this.toolStripMenuItem1,
            this.racesToolStripMenuItem,
            this.standingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formMainWindow";
            this.Text = "GoKart Championship";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upcomingRacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishedRacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standingsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

