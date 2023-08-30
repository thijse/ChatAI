using System;
using System.Drawing;
using System.Windows.Forms;
using winforms_chat.Model;
using winforms_chat.ViewModels;
using static OpenAI.ObjectModels.StaticValues.ImageStatics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winforms_chat.ChatForm
{
    public partial class Chatbox : UserControl
    {
        private int _baseHeightChat;
        private ChatAIViewModel _chatAiVm;

        public MessageChainViewModel _messageChainVm { get; }

        public ChatboxInfo chatboxInfo;
        public OpenFileDialog fileDialog = new OpenFileDialog();
        public string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private int _autoScaledHeight;

        public Chatbox(ChatboxInfo _chatbox_info, ChatAIViewModel chatAiVm)
        {
            InitializeComponent();
            _baseHeightChat = chatTextbox.Height;
            _chatAiVm = chatAiVm;
            _messageChainVm = chatAiVm.MessageChainVM;
            chatboxInfo = _chatbox_info;

            mainHeaderLabel.Text = chatboxInfo.NamePlaceholder;
            statusLabel.Text = chatboxInfo.StatusPlaceholder;
            subHeaderLabel.Text = chatboxInfo.PhonePlaceholder;
            chatTextbox.Text = chatboxInfo.ChatPlaceholder;

            chatTextbox.Enter += ChatEnter;
            chatTextbox.Leave += ChatLeave;
            sendButton.Click += SendMessage;

            chatTextbox.KeyDown += OnEnter;

            AddMessage(_messageChainVm.AddInitialPromptMessage());
        }

        /// <summary>
        /// ChatItem objects are generated dynamically from IChatModel. By default, a ChatItem is allowed to be resized up to 60% of the entire screen.
        /// I've thought about it being editable from outside, but there's no real need to.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(IChatModel message)
        {
            var chatItem = new ChatItem(message);
            chatItem.Name = "chatItem" + itemsPanel.Controls.Count;
            chatItem.Dock = DockStyle.Top;
            itemsPanel.Controls.Add(chatItem);
            chatItem.BringToFront();

            chatItem.ResizeBubbles((int)(itemsPanel.Width * 0.6));

            itemsPanel.ScrollControlIntoView(chatItem);
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chatTextbox.Text))
            {
                chatTextbox.Text = chatboxInfo.ChatPlaceholder;
                chatTextbox.ForeColor = Color.Gray;
            }
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatEnter(object sender, EventArgs e)
        {
            chatTextbox.ForeColor = Color.Black;
            if (chatTextbox.Text == chatboxInfo.ChatPlaceholder)
            {
                chatTextbox.Text = "";
            }
        }

        //Cross-tested this with the Twilio API and the RingCentral API, and async messaging is the way to go.
        async void SendMessage(object sender, EventArgs e)
        {
            string chatmessage = chatTextbox.Text.Trim();

            // Add sent message to chatbox 
            var message = _messageChainVm.AddNewUserMessage(chatboxInfo, chatmessage);
            AddMessage(message);


            // Add sent message to chatbox 
            var messageReceived = await _messageChainVm.GenerateAiResponse(chatboxInfo, chatmessage);
            AddMessage(messageReceived);

            chatTextbox.Text = "";
        }

        //Inspired from Slack, you can also press Shift + Enter to enter text.
        async void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                SendMessage(this, null);
            }
        }

        //When the Control resizes, it will trigger the resize event for all the ChatItem object inside as well, again with a default width of 60%.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (var control in itemsPanel.Controls)
            {
                if (control is ChatItem)
                {
                    (control as ChatItem).ResizeBubbles((int)(itemsPanel.Width * 0.6));
                }
            }
        }

        private void chatTextbox_TextChanged(object sender, EventArgs e)
        {
            SizeF size;
            using (Graphics G = chatTextbox.CreateGraphics()) size = G.MeasureString("Xy_", chatTextbox.Font, 999);
            var currentHeight = chatTextbox.Height;
            var newHeight = (int)(chatTextbox.Lines.Length * size.Height + 5);

            // Let the box grow, but not indefinately
            if (currentHeight < 100 && newHeight > currentHeight)
            {
                //splitContainer1.Panel2.Height = newHeight + 10;
                splitContainer1.SplitterDistance -= newHeight - currentHeight;
                _autoScaledHeight = newHeight;
            }
            else if (newHeight > _baseHeightChat && newHeight < currentHeight && currentHeight <= _autoScaledHeight)
            {
                splitContainer1.SplitterDistance -= newHeight - currentHeight;
            }
        }

        private void mainHeaderLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
