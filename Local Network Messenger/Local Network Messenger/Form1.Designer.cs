namespace Local_Network_Messenger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TxtMessageHistory = new TextBox();
            LblYourIp = new Label();
            TxtUserIp = new TextBox();
            TxtMessageBox = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            CmdSend = new Button();
            CmdConnextToTarget = new Button();
            SuspendLayout();
            // 
            // TxtMessageHistory
            // 
            TxtMessageHistory.Location = new Point(978, 182);
            TxtMessageHistory.MaximumSize = new Size(250, 150);
            TxtMessageHistory.MinimumSize = new Size(450, 600);
            TxtMessageHistory.Multiline = true;
            TxtMessageHistory.Name = "TxtMessageHistory";
            TxtMessageHistory.Size = new Size(450, 600);
            TxtMessageHistory.TabIndex = 0;
            // 
            // LblYourIp
            // 
            LblYourIp.AutoSize = true;
            LblYourIp.Location = new Point(36, 27);
            LblYourIp.Name = "LblYourIp";
            LblYourIp.Size = new Size(117, 41);
            LblYourIp.TabIndex = 1;
            LblYourIp.Text = "Your IP:";
            // 
            // TxtUserIp
            // 
            TxtUserIp.Location = new Point(173, 27);
            TxtUserIp.Name = "TxtUserIp";
            TxtUserIp.Size = new Size(529, 47);
            TxtUserIp.TabIndex = 2;
            // 
            // TxtMessageBox
            // 
            TxtMessageBox.Location = new Point(978, 788);
            TxtMessageBox.MinimumSize = new Size(350, 100);
            TxtMessageBox.Name = "TxtMessageBox";
            TxtMessageBox.Size = new Size(350, 100);
            TxtMessageBox.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(877, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(529, 47);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(716, 30);
            label1.Name = "label1";
            label1.Size = new Size(155, 41);
            label1.TabIndex = 5;
            label1.Text = "Friends Ip:";
            // 
            // CmdSend
            // 
            CmdSend.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CmdSend.BackgroundImage = (Image)resources.GetObject("CmdSend.BackgroundImage");
            CmdSend.BackgroundImageLayout = ImageLayout.Stretch;
            CmdSend.Location = new Point(1328, 788);
            CmdSend.MinimumSize = new Size(100, 100);
            CmdSend.Name = "CmdSend";
            CmdSend.Size = new Size(100, 100);
            CmdSend.TabIndex = 6;
            CmdSend.UseMnemonic = false;
            CmdSend.UseVisualStyleBackColor = true;
            CmdSend.Click += SendMessageButton_Click;
            // 
            // CmdConnextToTarget
            // 
            CmdConnextToTarget.Location = new Point(1052, 80);
            CmdConnextToTarget.Name = "CmdConnextToTarget";
            CmdConnextToTarget.Size = new Size(188, 58);
            CmdConnextToTarget.TabIndex = 7;
            CmdConnextToTarget.Text = "Connect";
            CmdConnextToTarget.UseVisualStyleBackColor = true;
            CmdConnextToTarget.Click += ConnectToTargetButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1455, 917);
            Controls.Add(CmdConnextToTarget);
            Controls.Add(CmdSend);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(TxtMessageBox);
            Controls.Add(TxtUserIp);
            Controls.Add(LblYourIp);
            Controls.Add(TxtMessageHistory);
            Name = "Form1";
            Text = "LNM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtMessageHistory;
        private Label LblYourIp;
        private TextBox TxtUserIp;
        private TextBox TxtMessageBox;
        private TextBox textBox1;
        private Label label1;
        private Button CmdSend;
        private Button CmdConnextToTarget;
    }
}