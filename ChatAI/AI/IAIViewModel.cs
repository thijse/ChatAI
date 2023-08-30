using System.Threading.Tasks;
using winforms_chat.Model;

namespace winforms_chat.ChatGPT
{
    public interface IAIViewModel
    {
        Task<MessageModel> GetAiResponse(MessageChainModel messageChain);
    }
}