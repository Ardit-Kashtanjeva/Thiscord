namespace LNM_Exclusive
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
            this.LblClientIP = new System.Windows.Forms.Label();
            this.TxtClientIP = new System.Windows.Forms.TextBox();
            this.TxtMessageHistory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblClientIP
            // 
            this.LblClientIP.AutoSize = true;
            this.LblClientIP.Location = new System.Drawing.Point(49, 46);
            this.LblClientIP.Name = "LblClientIP";
            this.LblClientIP.Size = new System.Drawing.Size(115, 32);
            this.LblClientIP.TabIndex = 0;
            this.LblClientIP.Text = "Your IP:";
            // 
            // TxtClientIP
            // 
            this.TxtClientIP.Location = new System.Drawing.Point(170, 46);
            this.TxtClientIP.Name = "TxtClientIP";
            this.TxtClientIP.ReadOnly = true;
            this.TxtClientIP.Size = new System.Drawing.Size(253, 38);
            this.TxtClientIP.TabIndex = 1;
            // 
            // TxtMessageHistory
            // 
            this.TxtMessageHistory.Location = new System.Drawing.Point(1186, 181);
            this.TxtMessageHistory.Name = "TxtMessageHistory";
            this.TxtMessageHistory.Size = new System.Drawing.Size(500, 38);
            this.TxtMessageHistory.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 1058);
            this.Controls.Add(this.TxtMessageHistory);
            this.Controls.Add(this.TxtClientIP);
            this.Controls.Add(this.LblClientIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblClientIP;
        private System.Windows.Forms.TextBox TxtClientIP;
        private System.Windows.Forms.TextBox TxtMessageHistory;
    }
}

