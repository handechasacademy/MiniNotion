namespace MiniNotion.Core.Entities
{
    public class PageContent
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public string Text { get; set; } = string.Empty;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Page? Page { get; set; }
    }
}
