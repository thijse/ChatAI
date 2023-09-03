using System;
using ChatAI.AIProvider.OpenAI;
using ChatAI.ChatForm;
using ChatAI.Model;
using ChatAI.Utilities;
using ChatAI.View;

namespace ChatAI.ViewModels
{
    public class ChatAIViewModel
    {
        

        private Chatbox _chatbox;
        private ChatboxInfo _chatboxInfo;

        public MessageChainViewModel _messageChainVm { get; private set; }
        public OpenAIViewModel    OpenAIGPTVM { get; private set; }

        public ChatAIViewModel(ChatMainForm chatMainForm)
        {
            _chatboxInfo   = chatMainForm.chatboxInfo;
            _chatbox       = chatMainForm.chatBox;
            OpenAIGPTVM    = new OpenAIViewModel();
            _messageChainVm = new MessageChainViewModel(OpenAIGPTVM);

            _chatbox.sendButton.Click += SendMessage;
            _chatbox.CtrlEnterPressed += SendMessage;
            _chatbox.buttonSettings.Click += OpenSettings;
            chatMainForm.Load += ChatMainFormLoad;
            

        }

        private void ChatMainFormLoad(object sender, EventArgs e)
        {
            _chatbox.AddMessage(_messageChainVm.AddInitialPromptMessage());
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            // todo, move to ChatAIViewModel
            var settingForm             = new SettingsForm();
            var AIPanel                 = settingForm.CreateAIPanel();
            var openAISettingsViewModel = new OpenAISettingsViewModel(AIPanel, OpenAIGPTVM);
            var settingsViewModel       = new SettingsViewModel(settingForm, openAISettingsViewModel);
            settingsViewModel.GetData();
            settingForm.ShowDialog();
            settingsViewModel.SetData();
            // todo settings do not go into effect until next reboot. From ChatAIViewModel
            Config<AppConfig>.Save();
        }

        async void SendMessage(object sender, EventArgs e)
        {
            string chatmessage = _chatbox.chatTextbox.Text.Trim();

            // Add sent message to chatbox 
            var message = _messageChainVm.AddNewUserMessage(_chatboxInfo, chatmessage);
            _chatbox.AddMessage(message);
            _chatbox.Text = "";

            // Add sent message to chatbox 
            var messageReceived = await _messageChainVm.GenerateAiResponse(_chatboxInfo, chatmessage);
            _chatbox.AddMessage(messageReceived);

            _chatbox.chatTextbox.Select();
        }


    }
}