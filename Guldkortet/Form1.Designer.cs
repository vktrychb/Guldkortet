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
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(142, 177);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 68);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Starta server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txbTextKontroll
            // 
            this.txbTextKontroll.Location = new System.Drawing.Point(13, 313);
            this.txbTextKontroll.Name = "txbTextKontroll";
            this.txbTextKontroll.Size = new System.Drawing.Size(411, 22);
            this.txbTextKontroll.TabIndex = 1;
            // 
            // btnStartaKlient
            // 
            this.btnStartaKlient.Location = new System.Drawing.Point(253, 37);
            this.btnStartaKlient.Name = "btnStartaKlient";
            this.btnStartaKlient.Size = new System.Drawing.Size(117, 23);
            this.btnStartaKlient.TabIndex = 2;
            this.btnStartaKlient.Text = "Starta klient";
            this.btnStartaKlient.UseVisualStyleBackColor = true;
            this.btnStartaKlient.Click += new System.EventHandler(this.btnStartaKlient_Click);
            // 
            // btnDekonstruering
            // 
            this.btnDekonstruering.Location = new System.Drawing.Point(13, 342);
            this.btnDekonstruering.Name = "btnDekonstruering";
            this.btnDekonstruering.Size = new System.Drawing.Size(192, 23);
            this.btnDekonstruering.TabIndex = 3;
            this.btnDekonstruering.Text = "dekonstruering";
            this.btnDekonstruering.UseVisualStyleBackColor = true;
            this.btnDekonstruering.Click += new System.EventHandler(this.btnDekonstruering_Click);
            // 
            // btnFelprövning
            // 
            this.btnFelprövning.Location = new System.Drawing.Point(226, 341);
            this.btnFelprövning.Name = "btnFelprövning";
            this.btnFelprövning.Size = new System.Drawing.Size(198, 23);
            this.btnFelprövning.TabIndex = 4;
            this.btnFelprövning.Text = "Felprövning";
            this.btnFelprövning.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.btnFelprövning);
            this.Controls.Add(this.btnDekonstruering);
            this.Controls.Add(this.btnStartaKlient);
            this.Controls.Add(this.txbTextKontroll);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Guldkort Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txbTextKontroll;
        private System.Windows.Forms.Button btnStartaKlient;
        private System.Windows.Forms.Button btnDekonstruering;
        private System.Windows.Forms.Button btnFelprövning;


    }
}

