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
            TxtMessageHistory.BackColor = SystemColors.Window;
            TxtMessageHistory.Location = new Point(403, 67);
            TxtMessageHistory.Margin = new Padding(1);
            TxtMessageHistory.MaximumSize = new Size(105, 57);
            TxtMessageHistory.MinimumSize = new Size(188, 222);
            TxtMessageHistory.Multiline = true;
            TxtMessageHistory.Name = "TxtMessageHistory";
            TxtMessageHistory.ReadOnly = true;
            TxtMessageHistory.Size = new Size(188, 222);
            TxtMessageHistory.TabIndex = 0;
            // 
            // LblYourIp
            // 
            LblYourIp.AutoSize = true;
            LblYourIp.Location = new Point(15, 10);
            LblYourIp.Margin = new Padding(1, 0, 1, 0);
            LblYourIp.Name = "LblYourIp";
            LblYourIp.Size = new Size(47, 15);
            LblYourIp.TabIndex = 1;
            LblYourIp.Text = "Your IP:";
            // 
            // TxtUserIp
            // 
            TxtUserIp.Location = new Point(71, 10);
            TxtUserIp.Margin = new Padding(1);
            TxtUserIp.Name = "TxtUserIp";
            TxtUserIp.Size = new Size(220, 23);
            TxtUserIp.TabIndex = 2;
            // 
            // TxtMessageBox
            // 
            TxtMessageBox.Location = new Point(403, 291);
            TxtMessageBox.Margin = new Padding(1);
            TxtMessageBox.MinimumSize = new Size(136, 50);
            TxtMessageBox.Name = "TxtMessageBox";
            TxtMessageBox.Size = new Size(136, 50);
            TxtMessageBox.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(361, 10);
            textBox1.Margin = new Padding(1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 23);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 11);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 5;
            label1.Text = "Friends Ip:";
            // 
            // CmdSend
            // 
            CmdSend.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CmdSend.BackgroundImage = (Image)resources.GetObject("CmdSend.BackgroundImage");
            CmdSend.BackgroundImageLayout = ImageLayout.Stretch;
            CmdSend.Location = new Point(541, 291);
            CmdSend.Margin = new Padding(1);
            CmdSend.MinimumSize = new Size(50, 50);
            CmdSend.Name = "CmdSend";
            CmdSend.Size = new Size(50, 50);
            CmdSend.TabIndex = 6;
            CmdSend.UseMnemonic = false;
            CmdSend.UseVisualStyleBackColor = true;
            CmdSend.Click += SendMessageButton_Click;
            // 
            // CmdConnextToTarget
            // 
            CmdConnextToTarget.Location = new Point(438, 35);
            CmdConnextToTarget.Margin = new Padding(1);
            CmdConnextToTarget.Name = "CmdConnextToTarget";
            CmdConnextToTarget.Size = new Size(77, 21);
            CmdConnextToTarget.TabIndex = 7;
            CmdConnextToTarget.Text = "Connect";
            CmdConnextToTarget.UseVisualStyleBackColor = true;
            CmdConnextToTarget.Click += ConnectToTargetButton_Click;
            // 
            // Form1
            // 
            AcceptButton = CmdSend;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 390);
            Controls.Add(CmdConnextToTarget);
            Controls.Add(CmdSend);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(TxtMessageBox);
            Controls.Add(TxtUserIp);
            Controls.Add(LblYourIp);
            Controls.Add(TxtMessageHistory);
            Margin = new Padding(1);
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