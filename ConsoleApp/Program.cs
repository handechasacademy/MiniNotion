using MiniNotion.Core.Services;
using MiniNotion.Data;
using Microsoft.EntityFrameworkCore;

namespace MiniNotion.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=mininotion.db")
                .Options;

            using var context = new AppDbContext(options);
            var pageService = new PageService(context);           
            var menu = new ConsoleMenu(pageService);

            menu.Run();
        }
    }
}
