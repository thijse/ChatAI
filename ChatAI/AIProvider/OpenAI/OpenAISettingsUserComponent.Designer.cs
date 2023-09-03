namespace ChatAI.AIProvider.OpenAI
{
    partial class OpenAISettingsUserComponent
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
            textBoxOpenAiKey = new System.Windows.Forms.TextBox();
            comboBoxOpenAiModel = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            comboBoxBaseUrl = new System.Windows.Forms.ComboBox();
            labelBaseUrl = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // textBoxOpenAiKey
            // 
            textBoxOpenAiKey.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxOpenAiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxOpenAiKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxOpenAiKey.Location = new System.Drawing.Point(16, 35);
            textBoxOpenAiKey.Name = "textBoxOpenAiKey";
            textBoxOpenAiKey.Size = new System.Drawing.Size(490, 29);
            textBoxOpenAiKey.TabIndex = 12;
            // 
            // comboBoxOpenAiModel
            // 
            comboBoxOpenAiModel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBoxOpenAiModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxOpenAiModel.FormattingEnabled = true;
            comboBoxOpenAiModel.Location = new System.Drawing.Point(16, 167);
            comboBoxOpenAiModel.Name = "comboBoxOpenAiModel";
            comboBoxOpenAiModel.Size = new System.Drawing.Size(490, 29);
            comboBoxOpenAiModel.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            label4.Location = new System.Drawing.Point(18, 143);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(110, 21);
            label4.TabIndex = 10;
            label4.Text = "OpenAI Model";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            label5.Location = new System.Drawing.Point(16, 11);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(118, 21);
            label5.TabIndex = 9;
            label5.Text = "OpenAI API Key";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxBaseUrl
            // 
            comboBoxBaseUrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBoxBaseUrl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxBaseUrl.FormattingEnabled = true;
            comboBoxBaseUrl.Items.AddRange(new object[] { "https://api.openai.com/" });
            comboBoxBaseUrl.Location = new System.Drawing.Point(16, 101);
            comboBoxBaseUrl.Name = "comboBoxBaseUrl";
            comboBoxBaseUrl.Size = new System.Drawing.Size(490, 29);
            comboBoxBaseUrl.TabIndex = 14;
            // 
            // labelBaseUrl
            // 
            labelBaseUrl.AutoSize = true;
            labelBaseUrl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelBaseUrl.ForeColor = System.Drawing.SystemColors.HotTrack;
            labelBaseUrl.Location = new System.Drawing.Point(18, 77);
            labelBaseUrl.Name = "labelBaseUrl";
            labelBaseUrl.Size = new System.Drawing.Size(131, 21);
            labelBaseUrl.TabIndex = 13;
            labelBaseUrl.Text = "OpenAI Base URL";
            labelBaseUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OpenAISettingsUserComponent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(comboBoxBaseUrl);
            Controls.Add(labelBaseUrl);
            Controls.Add(textBoxOpenAiKey);
            Controls.Add(comboBoxOpenAiModel);
            Controls.Add(label4);
            Controls.Add(label5);
            Name = "OpenAISettingsUserComponent";
            Size = new System.Drawing.Size(521, 248);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxOpenAiKey;
        public System.Windows.Forms.ComboBox comboBoxOpenAiModel;
        public System.Windows.Forms.ComboBox comboBoxBaseUrl;
        private System.Windows.Forms.Label labelBaseUrl;
    }
}
