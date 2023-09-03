using System.Windows.Forms;

namespace ChatAI.AIProvider.OpenAI
{
    public partial class OpenAISettingsUserComponent : UserControl
    {
        private OpenAISettingsViewModel _openAISettingsViewModel;

        public OpenAISettingsUserComponent()
        {
            InitializeComponent();
            comboBoxBaseUrl.SelectedIndex = 0;
        }
    }
}
