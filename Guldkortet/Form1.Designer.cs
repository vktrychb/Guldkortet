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
            this.btnStartaKlient = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnVäljKortdata = new System.Windows.Forms.Button();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVäljKunddata = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startaServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avslutaKopplingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txbTextKontroll = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetResult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartaKlient
            // 
            this.btnStartaKlient.Location = new System.Drawing.Point(173, 202);
            this.btnStartaKlient.Name = "btnStartaKlient";
            this.btnStartaKlient.Size = new System.Drawing.Size(82, 46);
            this.btnStartaKlient.TabIndex = 2;
            this.btnStartaKlient.Text = "Starta klient";
            this.btnStartaKlient.UseVisualStyleBackColor = true;
            this.btnStartaKlient.Click += new System.EventHandler(this.btnStartaKlient_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fil",
            "Databas"});
            this.comboBox1.Location = new System.Drawing.Point(6, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Välj...";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnVäljKortdata
            // 
            this.btnVäljKortdata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVäljKortdata.Location = new System.Drawing.Point(142, 34);
            this.btnVäljKortdata.Name = "btnVäljKortdata";
            this.btnVäljKortdata.Size = new System.Drawing.Size(95, 23);
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
            this.groupBox3.Controls.Add(this.btnVäljKunddata);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.btnVäljKortdata);
            this.groupBox3.Location = new System.Drawing.Point(18, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 69);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datakälla för kund- och kortdata";
            // 
            // btnVäljKunddata
            // 
            this.btnVäljKunddata.Location = new System.Drawing.Point(273, 35);
            this.btnVäljKunddata.Name = "btnVäljKunddata";
            this.btnVäljKunddata.Size = new System.Drawing.Size(98, 23);
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
            this.menuStrip1.Size = new System.Drawing.Size(436, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startaServerToolStripMenuItem,
            this.avslutaKopplingToolStripMenuItem});
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Enabled = false;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox1.Location = new System.Drawing.Point(342, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 20);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Tag = "Koppling";
            this.checkBox1.Text = "Koppling";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txbTextKontroll
            // 
            this.txbTextKontroll.Location = new System.Drawing.Point(6, 21);
            this.txbTextKontroll.Name = "txbTextKontroll";
            this.txbTextKontroll.Size = new System.Drawing.Size(198, 22);
            this.txbTextKontroll.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbTextKontroll);
            this.groupBox1.Location = new System.Drawing.Point(18, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 51);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indata";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 52);
            this.listBox1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(251, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 83);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dekonstruerad data";
            // 
            // btnGetResult
            // 
            this.btnGetResult.Location = new System.Drawing.Point(35, 265);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(117, 27);
            this.btnGetResult.TabIndex = 16;
            this.btnGetResult.Text = "Få resultat";
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.btnGetResult_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "DELETE LATER";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnGetResult);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartaKlient);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NOS_Server";
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartaKlient;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnVäljKortdata;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVäljKunddata;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startaServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avslutaKopplingToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txbTextKontroll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetResult;
        private System.Windows.Forms.Label label1;
    }
}

