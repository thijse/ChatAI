using System;
using System.Collections.Generic;
using OpenAI.ObjectModels.ResponseModels;
using OpenAI.ObjectModels.SharedModels;

namespace ChatAI.Model
{

    public interface IChatModel
    {
        DateTime TimeStamp       { get; set; }
        string Persona           { get; set; }
        public Roles Role        { get; set; }
        string Type              { get; }
        string UserOutputMessage { get; }
    }


    public enum Roles
    {
        System,
        User,
        Assistant,
        Other,
        None
    }
    
    /// <summary>
    /// Message model
    /// </summary>
    public class MessageModel : IChatModel
    {
        public string Type                                                { get { return "text"; } }

        public DateTime TimeStamp                                         { get; set; }

        // The message may contain multiple received ChatGPTMessages, perhaps iterated upon to derive the final one
        public List<ChatCompletionCreateResponse> ReceivedChatGPTMessages { get; set; } = new List<ChatCompletionCreateResponse>();
        // The  ChatGPT message used for output to user or otherwise. Does not need to be the full message.
        public ChatChoiceResponse SelectedChatGPTMessage                  { get; set; }
        // The message used for output to user 
        public string UserOutputMessage                                   { get { return GetUserOutputMessage(); } }
        // The message used for output AI  
        public string AIOutputMessage                                     { get { return GetAIOutputMessage(); } }

        // The custom prompt has precedence over received chatmessaages. May be input by the user or computer generated.
        public string CustomPrompt                                        { get; set; } = "";
        // The persona connected for the message
        public string Persona                                             { get; set; } = "";
        // role of the message sender (as used by ChatGPT)
        public Roles Role                                                 { get; set; } = Roles.None;
        // determines if shown in chat
        public bool Visible                                               { get; set; } = true;
        // determines if shown collapsed in chat (future plan)
        public bool Collapsed                                             { get; set; } = false;
        // determines if this message is used in AI chat
        public bool UsedInAIChat                                          { get; set; } = true;


        private string GetUserOutputMessage()
        {
            // most basic implementation
            // An filled in user prompt always has priority. Otherwise, use the message received from AI.
            return !string.IsNullOrEmpty(CustomPrompt) ? CustomPrompt : SelectedChatGPTMessage?.Message.Content ?? "";
        }

        private string GetAIOutputMessage()
        {
            // most basic implementation
            // An filled in user prompt always has priority. Otherwise, use the message received from AI.
            return !string.IsNullOrEmpty(CustomPrompt) ? CustomPrompt : SelectedChatGPTMessage?.Message.Content ?? ""; ;
        }
    }

    /// <summary>
    /// Message chain model
    /// </summary>
    public class MessageChainModel : List<MessageModel>
    {
    }
}
