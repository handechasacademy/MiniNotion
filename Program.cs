using MiniNotion.Data;

namespace MiniNotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();
        }
    }
}
