namespace sk_customllm.Models
{
    public class ChatRequest
    {
        public ChatRequest()
        {
            messages = new List<ChatMessage>();
            temperature = 0.7f;
            max_tokens = 2500;
            stream = "false";
        }
        public List<ChatMessage> messages { get; set; }
        public float temperature { get; set; }
        public int max_tokens { get; set; }
        public string stream { get; set; }
    }
}
