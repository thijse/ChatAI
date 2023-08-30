using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms_chat.ViewModels;

namespace winforms_chat
{
    public partial class ChatMainForm : Form
    {
        private ChatAIViewModel _chatAIVM;

        public ChatMainForm(ChatAIViewModel chatAIVM)
        {
            InitializeComponent();
            _chatAIVM = chatAIVM;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
            cbi.NamePlaceholder = "Chat";
            cbi.PhonePlaceholder = "";

            // todo connect cbi via _chatAIVM
            var chat_panel = new ChatForm.Chatbox(cbi, _chatAIVM);
            chat_panel.Name = "chat_panel";
            chat_panel.Dock = DockStyle.Fill;
            this.Controls.Add(chat_panel);
        }
    }
}
