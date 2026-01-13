namespace MiniNotion.Core.Entities
{
    public class Page
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public PageContent? Content { get; set; }
        public bool IsArchived { get; set; } = false;

        public int OrderIndex { get; set; }

        public string? Tags { get; set; }

    }
}
