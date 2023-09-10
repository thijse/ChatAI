
namespace ChatAI.ChatForm
{
    partial class Chatbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chatbox));
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            itemsPanel = new System.Windows.Forms.Panel();
            topPanel = new System.Windows.Forms.Panel();
            buttonSettings = new System.Windows.Forms.Button();
            statusLabel = new System.Windows.Forms.Label();
            subHeaderLabel = new System.Windows.Forms.Label();
            mainHeaderLabel = new System.Windows.Forms.Label();
            bottomPanel = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            chatTextbox = new System.Windows.Forms.TextBox();
            sendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            topPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(itemsPanel);
            splitContainer1.Panel1.Controls.Add(topPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(bottomPanel);
            splitContainer1.Panel2MinSize = 82;
            splitContainer1.Size = new System.Drawing.Size(872, 643);
            splitContainer1.SplitterDistance = 556;
            splitContainer1.TabIndex = 2;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            itemsPanel.Location = new System.Drawing.Point(0, 60);
            itemsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new System.Drawing.Size(872, 496);
            itemsPanel.TabIndex = 4;
            // 
            // topPanel
            // 
            topPanel.BackColor = System.Drawing.Color.FromArgb(246, 246, 246);
            topPanel.Controls.Add(buttonSettings);
            topPanel.Controls.Add(statusLabel);
            topPanel.Controls.Add(subHeaderLabel);
            topPanel.Controls.Add(mainHeaderLabel);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            topPanel.ImeMode = System.Windows.Forms.ImeMode.Off;
            topPanel.Location = new System.Drawing.Point(0, 0);
            topPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            topPanel.Name = "topPanel";
            topPanel.Padding = new System.Windows.Forms.Padding(18, 17, 18, 17);
            topPanel.Size = new System.Drawing.Size(872, 60);
            topPanel.TabIndex = 3;
            // 
            // buttonSettings
            // 
            buttonSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(246, 246, 246);
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSettings.Image = (System.Drawing.Image)resources.GetObject("buttonSettings.Image");
            buttonSettings.Location = new System.Drawing.Point(832, 3);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new System.Drawing.Size(32, 33);
            buttonSettings.TabIndex = 3;
            buttonSettings.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            statusLabel.AutoSize = true;
            statusLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            statusLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            statusLabel.Location = new System.Drawing.Point(824, 39);
            statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(40, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "Status";
            // 
            // subHeaderLabel
            // 
            subHeaderLabel.AutoSize = true;
            subHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            subHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            subHeaderLabel.Location = new System.Drawing.Point(4, 28);
            subHeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            subHeaderLabel.Name = "subHeaderLabel";
            subHeaderLabel.Size = new System.Drawing.Size(93, 21);
            subHeaderLabel.TabIndex = 1;
            subHeaderLabel.Text = "Sub header";
            // 
            // mainHeaderLabel
            // 
            mainHeaderLabel.AutoSize = true;
            mainHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mainHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            mainHeaderLabel.Location = new System.Drawing.Point(4, 7);
            mainHeaderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            mainHeaderLabel.Name = "mainHeaderLabel";
            mainHeaderLabel.Size = new System.Drawing.Size(120, 25);
            mainHeaderLabel.TabIndex = 0;
            mainHeaderLabel.Text = "Main header";
            mainHeaderLabel.Click += mainHeaderLabel_Click;
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = System.Drawing.Color.FromArgb(246, 246, 246);
            bottomPanel.Controls.Add(label1);
            bottomPanel.Controls.Add(chatTextbox);
            bottomPanel.Controls.Add(sendButton);
            bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            bottomPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            bottomPanel.Location = new System.Drawing.Point(0, 0);
            bottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            bottomPanel.Size = new System.Drawing.Size(872, 83);
            bottomPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            label1.Location = new System.Drawing.Point(16, 63);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(194, 15);
            label1.TabIndex = 2;
            label1.Text = "[Shift-Enter] send, [Enter] line break";
            // 
            // chatTextbox
            // 
            chatTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chatTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chatTextbox.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chatTextbox.Location = new System.Drawing.Point(18, 8);
            chatTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            chatTextbox.Size = new System.Drawing.Size(781, 51);
            chatTextbox.TabIndex = 0;
            chatTextbox.TextChanged += chatTextbox_TextChanged;
            // 
            // sendButton
            // 
            sendButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            sendButton.BackColor = System.Drawing.Color.FromArgb(44, 107, 237);
            sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            sendButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            sendButton.Image = (System.Drawing.Image)resources.GetObject("sendButton.Image");
            sendButton.Location = new System.Drawing.Point(807, 8);
            sendButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(61, 51);
            sendButton.TabIndex = 1;
            sendButton.UseVisualStyleBackColor = false;
            // 
            // Chatbox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(splitContainer1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Chatbox";
            Size = new System.Drawing.Size(872, 643);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label subHeaderLabel;
        private System.Windows.Forms.Label mainHeaderLabel;
        private System.Windows.Forms.Panel bottomPanel;
        public System.Windows.Forms.TextBox chatTextbox;
        public System.Windows.Forms.Button sendButton;
        public System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label label1;
    }
}
