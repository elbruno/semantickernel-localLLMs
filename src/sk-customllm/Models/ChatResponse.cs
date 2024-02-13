namespace sk_customllm.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ChatResponseChoice
    {
        public int ChatResponseindex { get; set; }
        public ChatResponseMessage message { get; set; }
        public string finish_reason { get; set; }
    }

    public class ChatResponseMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    public class ChatResponse
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<ChatResponseChoice> choices { get; set; }
        public ChatResponseUsage usage { get; set; }
    }

    public class ChatResponseUsage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}
