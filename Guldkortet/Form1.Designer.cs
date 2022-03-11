namespace Guldkortet
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnVäljKortdata = new System.Windows.Forms.Button();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbUserData = new System.Windows.Forms.CheckBox();
            this.chbCardData = new System.Windows.Forms.CheckBox();
            this.btnVäljKunddata = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startaServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avslutaKopplingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startaKlientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chbConnection = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fil",
            "Databas"});
            this.comboBox1.Location = new System.Drawing.Point(6, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Välj...";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnVäljKortdata
            // 
            this.btnVäljKortdata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVäljKortdata.Location = new System.Drawing.Point(31, 66);
            this.btnVäljKortdata.Name = "btnVäljKortdata";
            this.btnVäljKortdata.Size = new System.Drawing.Size(173, 23);
            this.btnVäljKortdata.TabIndex = 13;
            this.btnVäljKortdata.Text = "Kortdata";
            this.btnVäljKortdata.UseVisualStyleBackColor = true;
            this.btnVäljKortdata.Click += new System.EventHandler(this.btnBrowsa_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbUserData);
            this.groupBox3.Controls.Add(this.chbCardData);
            this.groupBox3.Controls.Add(this.btnVäljKunddata);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.btnVäljKortdata);
            this.groupBox3.Location = new System.Drawing.Point(12, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 129);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datakälla för kund- och kortdata";
            // 
            // chbUserData
            // 
            this.chbUserData.AutoSize = true;
            this.chbUserData.Enabled = false;
            this.chbUserData.Location = new System.Drawing.Point(7, 99);
            this.chbUserData.Name = "chbUserData";
            this.chbUserData.Size = new System.Drawing.Size(18, 17);
            this.chbUserData.TabIndex = 16;
            this.chbUserData.UseVisualStyleBackColor = true;
            // 
            // chbCardData
            // 
            this.chbCardData.AutoSize = true;
            this.chbCardData.Enabled = false;
            this.chbCardData.Location = new System.Drawing.Point(7, 68);
            this.chbCardData.Name = "chbCardData";
            this.chbCardData.Size = new System.Drawing.Size(18, 17);
            this.chbCardData.TabIndex = 15;
            this.chbCardData.UseVisualStyleBackColor = true;
            // 
            // btnVäljKunddata
            // 
            this.btnVäljKunddata.Location = new System.Drawing.Point(31, 95);
            this.btnVäljKunddata.Name = "btnVäljKunddata";
            this.btnVäljKunddata.Size = new System.Drawing.Size(173, 23);
            this.btnVäljKunddata.TabIndex = 14;
            this.btnVäljKunddata.Text = "Kunddata";
            this.btnVäljKunddata.UseVisualStyleBackColor = true;
            this.btnVäljKunddata.Click += new System.EventHandler(this.btnVäljKunddata_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(485, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startaServerToolStripMenuItem,
            this.avslutaKopplingToolStripMenuItem,
            this.startaKlientToolStripMenuItem,
            this.exitServerToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // startaServerToolStripMenuItem
            // 
            this.startaServerToolStripMenuItem.Name = "startaServerToolStripMenuItem";
            this.startaServerToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.startaServerToolStripMenuItem.Text = "Starta koppling";
            this.startaServerToolStripMenuItem.Click += new System.EventHandler(this.startaServerToolStripMenuItem_Click);
            // 
            // avslutaKopplingToolStripMenuItem
            // 
            this.avslutaKopplingToolStripMenuItem.Name = "avslutaKopplingToolStripMenuItem";
            this.avslutaKopplingToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.avslutaKopplingToolStripMenuItem.Text = "Avsluta koppling";
            this.avslutaKopplingToolStripMenuItem.Click += new System.EventHandler(this.avslutaKopplingToolStripMenuItem_Click);
            // 
            // startaKlientToolStripMenuItem
            // 
            this.startaKlientToolStripMenuItem.Name = "startaKlientToolStripMenuItem";
            this.startaKlientToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.startaKlientToolStripMenuItem.Text = "Starta klient";
            this.startaKlientToolStripMenuItem.Click += new System.EventHandler(this.startaKlientToolStripMenuItem_Click);
            // 
            // chbConnection
            // 
            this.chbConnection.AutoSize = true;
            this.chbConnection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbConnection.Enabled = false;
            this.chbConnection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbConnection.Location = new System.Drawing.Point(391, 33);
            this.chbConnection.Name = "chbConnection";
            this.chbConnection.Size = new System.Drawing.Size(82, 20);
            this.chbConnection.TabIndex = 19;
            this.chbConnection.Tag = "Koppling";
            this.chbConnection.Text = "Koppling";
            this.chbConnection.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(235, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // exitServerToolStripMenuItem
            // 
            this.exitServerToolStripMenuItem.Name = "exitServerToolStripMenuItem";
            this.exitServerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitServerToolStripMenuItem.Text = "Exit server";
            this.exitServerToolStripMenuItem.Click += new System.EventHandler(this.exitServerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 251);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chbConnection);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NOS_Server";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnVäljKortdata;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVäljKunddata;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startaServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avslutaKopplingToolStripMenuItem;
        private System.Windows.Forms.CheckBox chbConnection;
        private System.Windows.Forms.ToolStripMenuItem startaKlientToolStripMenuItem;
        private System.Windows.Forms.CheckBox chbUserData;
        private System.Windows.Forms.CheckBox chbCardData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem exitServerToolStripMenuItem;
    }
}

