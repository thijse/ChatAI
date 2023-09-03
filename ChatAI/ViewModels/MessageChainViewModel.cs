using System;
using System.Threading.Tasks;
using ChatAI.ChatForm;
using ChatAI.ChatGPT;
using ChatAI.Model;

namespace ChatAI.ViewModels
{
    public class MessageChainViewModel
    {
        private IAIViewModel _AiVm;

        public  MessageChainModel MessageChainM { get; private set; }

        public MessageChainViewModel(IAIViewModel AiVm)
        {
            _AiVm = AiVm;
            MessageChainM = new MessageChainModel();
        }

        public MessageModel AddNewUserMessage(ChatboxInfo chatboxInfo, string message)
        {
            var messageModel          = new MessageModel();
            messageModel.Persona      = chatboxInfo.NamePlaceholder??"user";
            messageModel.Role         = Roles.User;
            messageModel.TimeStamp    = DateTime.Now;
            messageModel.CustomPrompt = message.Trim();
            MessageChainM.Add(messageModel);
            
            return messageModel;
        }

        internal async Task<MessageModel> GenerateAiResponse(ChatboxInfo chatboxInfo, string chatmessage)
        {
            var response = await  _AiVm.GetAiResponse(MessageChainM);
            response.Persona = "assistent";
            return response;
        }

        public MessageModel AddInitialPromptMessage()
        {
            var messageModel          = new MessageModel();
            messageModel.Persona      = "system";
            messageModel.Role         = Roles.System;
            messageModel.TimeStamp    = DateTime.Now;
            messageModel.CustomPrompt = "You are a helpful assistant. You can help me by answering my questions. You can also ask me questions.";
            MessageChainM.Add(messageModel);
            
            return messageModel;
        }
    }
}
