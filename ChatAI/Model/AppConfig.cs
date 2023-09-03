namespace ChatAI.Model
{
    public class AppConfig
    {
        public string OpenAIKey { get; set; } = "API key here";
        public string BaseUrl   { get; set; } = "https://api.openai.com";
        public string Model     { get; set; } = "gpt-3.5-turbo-0301";
    }
}
