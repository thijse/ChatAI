namespace winforms_chat.View
{
    partial class SettingsForm
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
            tabControlSettings = new System.Windows.Forms.TabControl();
            tabPageModel = new System.Windows.Forms.TabPage();
            comboBoxAIModelProvider = new System.Windows.Forms.ComboBox();
            panel2 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            tabPageDisplay = new System.Windows.Forms.TabPage();
            tabControlSettings.SuspendLayout();
            tabPageModel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlSettings
            // 
            tabControlSettings.Controls.Add(tabPageModel);
            tabControlSettings.Controls.Add(tabPageDisplay);
            tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControlSettings.Location = new System.Drawing.Point(0, 0);
            tabControlSettings.Name = "tabControlSettings";
            tabControlSettings.Padding = new System.Drawing.Point(15, 15);
            tabControlSettings.SelectedIndex = 0;
            tabControlSettings.Size = new System.Drawing.Size(710, 397);
            tabControlSettings.TabIndex = 0;
            // 
            // tabPageModel
            // 
            tabPageModel.BackColor = System.Drawing.Color.White;
            tabPageModel.Controls.Add(comboBoxAIModelProvider);
            tabPageModel.Controls.Add(panel2);
            tabPageModel.Controls.Add(label3);
            tabPageModel.ForeColor = System.Drawing.SystemColors.HotTrack;
            tabPageModel.Location = new System.Drawing.Point(4, 54);
            tabPageModel.Name = "tabPageModel";
            tabPageModel.Padding = new System.Windows.Forms.Padding(3);
            tabPageModel.Size = new System.Drawing.Size(702, 339);
            tabPageModel.TabIndex = 0;
            tabPageModel.Text = "Model";
            // 
            // comboBoxAIModelProvider
            // 
            comboBoxAIModelProvider.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBoxAIModelProvider.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxAIModelProvider.FormattingEnabled = true;
            comboBoxAIModelProvider.Items.AddRange(new object[] { "OpenAI" });
            comboBoxAIModelProvider.Location = new System.Drawing.Point(8, 40);
            comboBoxAIModelProvider.Name = "comboBoxAIModelProvider";
            comboBoxAIModelProvider.Size = new System.Drawing.Size(688, 29);
            comboBoxAIModelProvider.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(3, 88);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(696, 248);
            panel2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(135, 21);
            label3.TabIndex = 8;
            label3.Text = "AI Model Provider";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageDisplay
            // 
            tabPageDisplay.BackColor = System.Drawing.Color.White;
            tabPageDisplay.Location = new System.Drawing.Point(4, 54);
            tabPageDisplay.Name = "tabPageDisplay";
            tabPageDisplay.Padding = new System.Windows.Forms.Padding(3);
            tabPageDisplay.Size = new System.Drawing.Size(702, 339);
            tabPageDisplay.TabIndex = 1;
            tabPageDisplay.Text = "Display";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonFace;
            ClientSize = new System.Drawing.Size(710, 397);
            Controls.Add(tabControlSettings);
            Name = "SettingsForm";
            Text = "Form1";
            FormClosing += SettingsForm_FormClosing;
            tabControlSettings.ResumeLayout(false);
            tabPageModel.ResumeLayout(false);
            tabPageModel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageModel;
        private System.Windows.Forms.TabPage tabPageDisplay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.ComboBox comboBoxAIModelProvider;
    }
}