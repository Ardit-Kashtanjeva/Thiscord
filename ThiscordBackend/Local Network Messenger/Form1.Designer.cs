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
            TxtMessageBox = new TextBox();
            CmdSend = new Button();
            ComboBoxChats = new ComboBox();
            SuspendLayout();
            // 
            // TxtMessageHistory
            // 
            TxtMessageHistory.BackColor = Color.DimGray;
            TxtMessageHistory.BorderStyle = BorderStyle.None;
            TxtMessageHistory.Location = new Point(364, 0);
            TxtMessageHistory.Margin = new Padding(1);
            TxtMessageHistory.MaximumSize = new Size(105, 57);
            TxtMessageHistory.MinimumSize = new Size(270, 292);
            TxtMessageHistory.Multiline = true;
            TxtMessageHistory.Name = "TxtMessageHistory";
            TxtMessageHistory.ReadOnly = true;
            TxtMessageHistory.Size = new Size(270, 292);
            TxtMessageHistory.TabIndex = 0;
            TxtMessageHistory.TextChanged += TxtMessageHistory_TextChanged;
            // 
            // TxtMessageBox
            // 
            TxtMessageBox.BackColor = Color.Gray;
            TxtMessageBox.BorderStyle = BorderStyle.None;
            TxtMessageBox.Location = new Point(364, 291);
            TxtMessageBox.Margin = new Padding(1);
            TxtMessageBox.MinimumSize = new Size(136, 50);
            TxtMessageBox.Name = "TxtMessageBox";
            TxtMessageBox.Size = new Size(219, 50);
            TxtMessageBox.TabIndex = 3;
            // 
            // CmdSend
            // 
            CmdSend.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CmdSend.BackgroundImage = (Image)resources.GetObject("CmdSend.BackgroundImage");
            CmdSend.BackgroundImageLayout = ImageLayout.Stretch;
            CmdSend.Location = new Point(585, 291);
            CmdSend.Margin = new Padding(1);
            CmdSend.MinimumSize = new Size(50, 50);
            CmdSend.Name = "CmdSend";
            CmdSend.Size = new Size(50, 50);
            CmdSend.TabIndex = 6;
            CmdSend.UseMnemonic = false;
            CmdSend.UseVisualStyleBackColor = true;
            CmdSend.Click += SendMessageButton_Click;
            // 
            // ComboBoxChats
            // 
            ComboBoxChats.BackColor = Color.DimGray;
            ComboBoxChats.DropDownHeight = 120;
            ComboBoxChats.DropDownStyle = ComboBoxStyle.Simple;
            ComboBoxChats.FlatStyle = FlatStyle.Flat;
            ComboBoxChats.ForeColor = Color.White;
            ComboBoxChats.FormattingEnabled = true;
            ComboBoxChats.ImeMode = ImeMode.NoControl;
            ComboBoxChats.IntegralHeight = false;
            ComboBoxChats.ItemHeight = 15;
            ComboBoxChats.Location = new Point(9, -3);
            ComboBoxChats.Margin = new Padding(0);
            ComboBoxChats.Name = "ComboBoxChats";
            ComboBoxChats.Size = new Size(229, 350);
            ComboBoxChats.TabIndex = 7;
            ComboBoxChats.Text = "Chats";
            // 
            // Form1
            // 
            AcceptButton = CmdSend;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(650, 350);
            Controls.Add(ComboBoxChats);
            Controls.Add(CmdSend);
            Controls.Add(TxtMessageBox);
            Controls.Add(TxtMessageHistory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(1);
            MinimumSize = new Size(650, 350);
            Name = "Form1";
            Text = "LNM";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtMessageHistory;
        private TextBox TxtMessageBox;
        private Button CmdSend;
        private ComboBox ComboBoxChats;
    }
}