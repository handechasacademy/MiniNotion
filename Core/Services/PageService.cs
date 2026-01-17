using MiniNotion.Core.Entities;
using MiniNotion.Data;

namespace MiniNotion.Core.Services
{
    public class PageService
    {
        private readonly AppDbContext _context;
        public PageService(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePage(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.", nameof(title));
            }

            var page = new Entities.Page
            {
                Title = title,
                CreatedAt = DateTime.UtcNow
            };


            _context.Pages.Add(page);
            _context.SaveChanges();
        }

        public List<Entities.Page> GetAllPages()
        {
            return _context.Pages
                .Where(p => !p.IsArchived)
                .OrderBy(p => p.OrderIndex)
                .ToList();
        }

        public Page? GetPageById(int id)
        {
            return _context.Pages
                .FirstOrDefault(p => p.Id == id && !p.IsArchived);
        }

        public void EditPage(int id, string newTitle)
        {
            var page = GetPageById(id);
            if (page == null)
            {
                throw new InvalidOperationException("Page not found.");
            }
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Title cannot be empty.", nameof(newTitle));
            }
            page.Title = newTitle;
            _context.SaveChanges();
        }

        public void DeletePage(int id)
        {
            var page = GetPageById(id);
            if (page == null)
            {
                throw new InvalidOperationException("Page not found.");
            }
            page.IsArchived = true;
            _context.SaveChanges();
        }


    }   
}
