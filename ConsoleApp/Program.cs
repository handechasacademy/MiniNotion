using MiniNotion.Data;
using MiniNotion.Core.Entities;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
    }
}
