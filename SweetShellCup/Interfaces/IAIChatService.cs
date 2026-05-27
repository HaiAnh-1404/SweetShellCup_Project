using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface IAIChatService
    {
        Task<ChatResponse> AskAsync(string userMessage, List<ChatMessage>? history = null);
    }
}