using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_chat.AIProvider.OpenAI
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
