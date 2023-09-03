using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms_chat.ChatForm;
using winforms_chat.ViewModels;

namespace winforms_chat
{
    public partial class ChatMainForm : Form
    {
        public ChatboxInfo chatboxInfo;
        public Chatbox chatBox;

        //private ChatAIViewModel _chatAIVM;

        //public ChatMainForm(ChatAIViewModel chatAIVM)
        public ChatMainForm()
        {
            InitializeComponent();
            //_chatAIVM = chatAIVM;
            chatboxInfo = new ChatForm.ChatboxInfo();
            chatboxInfo.NamePlaceholder = "Chat";
            chatboxInfo.PhonePlaceholder = "";

            chatBox = new ChatForm.Chatbox(chatboxInfo);
            chatBox.Name = "chat_panel";
            chatBox.Dock = DockStyle.Fill;
            this.Controls.Add(chatBox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {        }
    }
}
