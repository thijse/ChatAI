using winforms_chat.ChatGPT;
using winforms_chat.Model;

namespace winforms_chat.ViewModels
{
    public class ChatAIViewModel
    {
        public MessageChainViewModel MessageChainVM { get; private set; }
        public OpenAIGPTViewModel    OpenAIGPTVM { get; private set; }

        public ChatAIViewModel()
        {
            
            OpenAIGPTVM    = new OpenAIGPTViewModel();
            MessageChainVM = new MessageChainViewModel(OpenAIGPTVM);
        }
    }
}