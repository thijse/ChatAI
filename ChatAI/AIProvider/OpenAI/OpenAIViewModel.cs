using OpenAI.Managers;
using OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.ResponseModels;
using OpenAI.ObjectModels.SharedModels;
using winforms_chat.Utilities;
using winforms_chat.Model;
using winforms_chat.ChatGPT;
using System.Threading;

namespace winforms_chat.AIProvider.OpenAI
{
    public class OpenAIViewModel : IAIViewModel
    {
        private OpenAIService _openAiService;
        //AppConfig config = new AppConfig();


        public OpenAIViewModel()
        {
            LoadOpenAIService();
        }

        public void LoadOpenAIService()
        {
            _openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey                  = Config<AppConfig>.Params.OpenAIKey,
                OpenAiDefaultBaseDomain = Config<AppConfig>.Params.BaseUrl, // "http://localhost:8080/"                
            });
        }

        //        private ChatCompletionCreateRequest GetDefaultChatCompletionCreateRequest()
        //        {
        //#pragma warning disable CS0618 // Type or member is obsolete
        //            var request = new ChatCompletionCreateRequest()
        //            {
        //                Model = Models.ChatGpt3_5Turbo0301,
        //                //MaxTokens = 3000//optional
        //            };
        //#pragma warning restore CS0618 // Type or member is obsolete

        //            return request;
        //        }

        private ChatCompletionCreateRequest GetDefaultChatCompletionCreateRequest()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var request = new ChatCompletionCreateRequest()
            {
                Model = Config<AppConfig>.Params.Model  // "ggml-gpt4all-j",
                //Model = "ggml-gpt4all-j",
                //MaxTokens = 3000//optional
            };
#pragma warning restore CS0618 // Type or member is obsolete

            return request;
        }

        public async Task<List<string>> GetModels()
        {
            List<string> models = new List<string>();   
            var response = await _openAiService.ListModel(new CancellationTokenSource(2500).Token);
            if (response == null) {return models; }
            foreach (var model in response.Models){ models.Add(model.Id); }   
            return models;
        }

        public async Task<MessageModel> GetAiResponse(MessageChainModel messageChain)
        {
            var messages = CreateGPTMessages(messageChain);
            var request = GetDefaultChatCompletionCreateRequest();
            request.Messages = messages;
            ChatCompletionCreateResponse completeRequest = null;
            try
            {
                completeRequest = await _openAiService.ChatCompletion.CreateCompletion(request);
            }
            catch { }


            return CreateInternalMessageFromResponse(completeRequest);
        }

        // Generate a ChatMessage List as input for ChatGPT based on internal MessageChain model
        private List<ChatMessage> CreateGPTMessages(MessageChainModel messageChain)
        {
            List<ChatMessage> chatMessages = new List<ChatMessage>();
            foreach (var message in messageChain)
            {
                if (message.UsedInAIChat && HasGPTRole(message))
                {
                    chatMessages.Add(GetGPTMessage(message));
                }
            }
            return chatMessages;
        }

        private bool HasGPTRole(MessageModel message)
        {
            return message.Role == Roles.System || message.Role == Roles.Assistant || message.Role == Roles.User;
        }

        // Generate a message List as input for ChatGPT based on internal MessageChain model
        private ChatMessage GetGPTMessage(MessageModel message)
        {
            // we will rebuild the message from the message chain, rather than use the ChatMessage directly
            // this is because the Message may have been modified , and we want to use that one. E.g. the role may have been changed
            var chatMessage = new ChatMessage(GetGPTRole(message), GetGPTContent(message), GetGPTName(message));
            return chatMessage;
        }

        private string GetGPTRole(MessageModel message)
        {
            // create switch case on the Role returning the appropriate ChatGPT role
            switch (message.Role)
            {
                case Roles.System: return "system";
                case Roles.User: return "user";
                case Roles.Assistant: return "assistant";
                case Roles.Other: return "other"; // will probably be ignored by ChatGPT
                default: return "none";  // will probably be ignored by ChatGPT
            }
        }

        private Roles GetInternalRole(ChatChoiceResponse selectedChatGPTMessage)
        {
            // convert selectedChatGPTMessage.Message.Role to enum Roles
            switch (selectedChatGPTMessage?.Message?.Role)
            {
                case "system": return Roles.System;
                case "user": return Roles.User;
                case "assistant": return Roles.Assistant;
                case "other": return Roles.Other;
                default: return Roles.None;
            }
        }

        private string GetGPTContent(MessageModel message)
        {
            return message.AIOutputMessage; // Not too much to be done here, may change in future
        }
        private string GetGPTName(MessageModel message)
        {
            return message.Persona; // Not too much to be done here, may change in future
        }

        // Generate internal MessageChain based on response from ChatGPT 
        private MessageModel CreateInternalMessageFromResponse(ChatCompletionCreateResponse completionResult)
        {
            var message = new MessageModel();

            // add the response to the message verbatim
            message.ReceivedChatGPTMessages.Add(completionResult);


            // if not succesful:
            if (completionResult == null || !completionResult.Successful)
            {
                message.UsedInAIChat = false;                                                                                                   // if not succesfull, we will still store it, but not use it
                message.CustomPrompt = "The message could not be processed. Please see the reason below.\r\n" + completionResult?.Error.Message ?? "No answer received";  // and we will show an error message
                return message;
            }
            else
            {
                // We will trim the message content, as it may contain whitespaces or newlines
                foreach (var choice in completionResult.Choices) { choice.Message.Content = choice.Message.Content.Trim(); }

                message.UsedInAIChat = true;
                // if this is the first message, select it, otherwise one has already been selected
                if (message.ReceivedChatGPTMessages.Count == 1)
                {
                    message.SelectedChatGPTMessage = message.ReceivedChatGPTMessages[0].Choices.First();
                    // todo, fill Custom prompt or automatically switch based on selected message
                }
            }


            message.Role = GetInternalRole(message.SelectedChatGPTMessage);
            message.Persona = message.SelectedChatGPTMessage?.Message?.Name;
            message.TimeStamp = DateTime.Now;
            message.Collapsed = false;
            return message;
        }
    }
}
