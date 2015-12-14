namespace YapayZeka2
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
            this.vezirTxt = new System.Windows.Forms.TextBox();
            this.atTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGonder = new System.Windows.Forms.Button();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vezirTxt
            // 
            this.vezirTxt.Location = new System.Drawing.Point(63, 732);
            this.vezirTxt.Name = "vezirTxt";
            this.vezirTxt.Size = new System.Drawing.Size(100, 20);
            this.vezirTxt.TabIndex = 0;
            // 
            // atTxt
            // 
            this.atTxt.Location = new System.Drawing.Point(225, 732);
            this.atTxt.Name = "atTxt";
            this.atTxt.Size = new System.Drawing.Size(100, 20);
            this.atTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 716);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "At Sayısı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 716);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vezir Sayısı";
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(382, 730);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(116, 23);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "Bilgileri Kaydet";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(541, 729);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(117, 23);
            this.btnBaslat.TabIndex = 5;
            this.btnBaslat.Text = "Programı Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(692, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 581);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bilgi Ekranı";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 764);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atTxt);
            this.Controls.Add(this.vezirTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vezirTxt;
        private System.Windows.Forms.TextBox atTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Label label3;
    }
}

