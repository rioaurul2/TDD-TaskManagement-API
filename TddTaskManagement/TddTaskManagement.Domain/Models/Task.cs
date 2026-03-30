namespace TddTaskManagement.Domain.Models
{
    public class Task
    {
        public string Title { get; } = null!;

        public Task( string title)
        {
            Title = title;
        }
    }
}
