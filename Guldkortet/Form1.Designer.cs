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
            this.btnStart = new System.Windows.Forms.Button();
            this.txbTextKontroll = new System.Windows.Forms.TextBox();
            this.btnStartaKlient = new System.Windows.Forms.Button();
            this.btnDekonstruering = new System.Windows.Forms.Button();
            this.btnFelprövning = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFileLoad = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnBrowsa = new System.Windows.Forms.Button();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 49);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 68);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Starta server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txbTextKontroll
            // 
            this.txbTextKontroll.Location = new System.Drawing.Point(6, 21);
            this.txbTextKontroll.Name = "txbTextKontroll";
            this.txbTextKontroll.Size = new System.Drawing.Size(198, 22);
            this.txbTextKontroll.TabIndex = 1;
            // 
            // btnStartaKlient
            // 
            this.btnStartaKlient.Location = new System.Drawing.Point(181, 49);
            this.btnStartaKlient.Name = "btnStartaKlient";
            this.btnStartaKlient.Size = new System.Drawing.Size(125, 68);
            this.btnStartaKlient.TabIndex = 2;
            this.btnStartaKlient.Text = "Starta klient";
            this.btnStartaKlient.UseVisualStyleBackColor = true;
            this.btnStartaKlient.Click += new System.EventHandler(this.btnStartaKlient_Click);
            // 
            // btnDekonstruering
            // 
            this.btnDekonstruering.Location = new System.Drawing.Point(267, 251);
            this.btnDekonstruering.Name = "btnDekonstruering";
            this.btnDekonstruering.Size = new System.Drawing.Size(151, 23);
            this.btnDekonstruering.TabIndex = 3;
            this.btnDekonstruering.Text = "dekonstruering";
            this.btnDekonstruering.UseVisualStyleBackColor = true;
            this.btnDekonstruering.Click += new System.EventHandler(this.btnDekonstruering_Click);
            // 
            // btnFelprövning
            // 
            this.btnFelprövning.Location = new System.Drawing.Point(291, 415);
            this.btnFelprövning.Name = "btnFelprövning";
            this.btnFelprövning.Size = new System.Drawing.Size(133, 23);
            this.btnFelprövning.TabIndex = 4;
            this.btnFelprövning.Text = "Felprövning";
            this.btnFelprövning.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbTextKontroll);
            this.groupBox1.Location = new System.Drawing.Point(18, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 57);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indata";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 84);
            this.listBox1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(267, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 117);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dekonstruerad data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 68);
            this.button1.TabIndex = 9;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFileLoad
            // 
            this.btnFileLoad.Location = new System.Drawing.Point(328, 141);
            this.btnFileLoad.Name = "btnFileLoad";
            this.btnFileLoad.Size = new System.Drawing.Size(75, 23);
            this.btnFileLoad.TabIndex = 10;
            this.btnFileLoad.Text = "load files";
            this.btnFileLoad.UseVisualStyleBackColor = true;
            this.btnFileLoad.Click += new System.EventHandler(this.btnFileLoad_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fil",
            "Databas"});
            this.comboBox1.Location = new System.Drawing.Point(18, 140);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Välj...";
            // 
            // btnBrowsa
            // 
            this.btnBrowsa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowsa.Location = new System.Drawing.Point(181, 140);
            this.btnBrowsa.Name = "btnBrowsa";
            this.btnBrowsa.Size = new System.Drawing.Size(91, 23);
            this.btnBrowsa.TabIndex = 13;
            this.btnBrowsa.Text = "Browsa...";
            this.btnBrowsa.UseVisualStyleBackColor = true;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.btnBrowsa);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnFileLoad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFelprövning);
            this.Controls.Add(this.btnDekonstruering);
            this.Controls.Add(this.btnStartaKlient);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Guldkort Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txbTextKontroll;
        private System.Windows.Forms.Button btnStartaKlient;
        private System.Windows.Forms.Button btnDekonstruering;
        private System.Windows.Forms.Button btnFelprövning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFileLoad;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBrowsa;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
    }
}

