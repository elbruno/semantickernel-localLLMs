namespace SKPhi2Local.Models
{
    public class ChatRequest
    {
        public ChatRequest()
        {
            messages = new List<ChatMessage>();
            temperature = 0.7f;
            max_tokens = 25;
            stream = "false";
        }
        public List<ChatMessage> messages { get; set; }
        public float temperature { get; set; }
        public int max_tokens { get; set; }
        public string stream { get; set; }
    }
}
