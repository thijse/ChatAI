using System.Threading.Tasks;
using ChatAI.Model;

namespace ChatAI.ChatGPT
{
    public interface IAIViewModel
    {
        Task<MessageModel> GetAiResponse(MessageChainModel messageChain);
    }
}