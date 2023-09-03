using System.Windows.Forms;
using winforms_chat.ViewModels;

namespace winforms_chat.View
{
    public partial class SettingsForm : Form
    {
        public AIProvider.OpenAI.OpenAISettingsUserComponent OpenaiSettingsUc { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();

            comboBoxAIModelProvider.SelectedIndex = 0;
        }

        // Todo : Move this to viewmodel?
        public AIProvider.OpenAI.OpenAISettingsUserComponent CreateAIPanel()
        {
            OpenaiSettingsUc = new AIProvider.OpenAI.OpenAISettingsUserComponent();
            OpenaiSettingsUc.Location = new System.Drawing.Point(0, 0);
            OpenaiSettingsUc.Dock = DockStyle.Fill;
            OpenaiSettingsUc.TabIndex = 0;
            panel2.Controls.Add(OpenaiSettingsUc);
            return OpenaiSettingsUc;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) { }

    }
}
