namespace SweetShellCup.Models
{
    public class ChatRequest
    {
        public string Message { get; set; } = "";
        public List<ChatMessage>? History { get; set; }
    }

    public class ChatMessage
    {
        public string Role { get; set; } = "user";
        public string Content { get; set; } = "";
    }

    public class ChatResponse
    {
        public string Reply { get; set; } = "";
        public bool Success { get; set; } = true;
        public string? Error { get; set; }
    }
}