using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatAI.AIProvider.OpenAI;
using ChatAI.Model;
using ChatAI.Utilities;
using ChatAI.View;
using ChatAI.ViewModels;

namespace ChatAI.ChatForm
{
    public partial class Chatbox : UserControl
    {
        public event EventHandler CtrlEnterPressed;
        private int _baseHeightChat;
        private int _baseHeightEditPanel;

        public override string Text
        {
            get => chatTextbox.Text;
            set => chatTextbox.Text = value;
        }

        public ChatboxInfo chatboxInfo;
        public OpenFileDialog fileDialog = new OpenFileDialog();
        public string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Chatbox(ChatboxInfo _chatbox_info)
        {
            InitializeComponent();
            _baseHeightChat = chatTextbox.Height;
            _baseHeightEditPanel = bottomPanel.Height;

            chatboxInfo = _chatbox_info;
            mainHeaderLabel.Text = chatboxInfo.NamePlaceholder;
            statusLabel.Text = chatboxInfo.StatusPlaceholder;
            subHeaderLabel.Text = chatboxInfo.PhonePlaceholder;
            chatTextbox.Text = chatboxInfo.ChatPlaceholder;

            chatTextbox.Enter += ChatEnter;
            chatTextbox.KeyDown += OnKeyDown;


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

            chatItem.ResizeBubbles((int)(itemsPanel.Width * 1));
            itemsPanel.ScrollControlIntoView(chatItem);
            Task.Delay(100).ContinueWith(_ =>
            {
                this.Invoke(new Action(() => { chatTextbox.Select(); }));
            });
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

        //press Shift + Enter to enter text.
        async void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                if (CtrlEnterPressed != null) CtrlEnterPressed(this, null);

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
                    (control as ChatItem).ResizeBubbles((int)(itemsPanel.Width * 1.0));
                }
            }
        }

        private void chatTextbox_TextChanged(object sender, EventArgs e)
        {
            SizeF size;
            using (Graphics G = chatTextbox.CreateGraphics()) size = G.MeasureString("Xy_", chatTextbox.Font, 999);
            var currentHeight = chatTextbox.Height;
            var newHeight = (int)(chatTextbox.Lines.Length * size.Height + 5);
            var maxAutoGrowHeight = 100;

            // Splitter minimum size depends directly on the height of the chatbox,
            // But never smaller than the initial height of the edit panel
            splitContainer1.Panel2MinSize = Math.Max(newHeight + 10, _baseHeightEditPanel);

            // Let the box grow, but not indefinitely
            if (currentHeight < maxAutoGrowHeight && newHeight > currentHeight)
            {
                //splitContainer1.Panel2.Height = newHeight + 10;
                splitContainer1.SplitterDistance -= newHeight - currentHeight;

                //_autoScaledHeight = newHeight;
            }
            // Shrink the box if the text is deleted
            else if (newHeight < currentHeight)// &&  currentHeight <= _autoScaledHeight)
            {
                newHeight = Math.Max(newHeight, _baseHeightChat);
                splitContainer1.SplitterDistance -= newHeight - currentHeight;
            }
        }

        private void mainHeaderLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
