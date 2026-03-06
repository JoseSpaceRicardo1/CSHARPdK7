using System.Reflection;
using runner;

class Program
{
    static void Main()
    {
        var exercises = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
                typeof(IRunnable).IsAssignableFrom(t) &&
                !t.IsInterface &&
                !t.IsAbstract)
            .Select(t => (IRunnable)Activator.CreateInstance(t)!)
            .ToList();

        var categories = exercises
            .GroupBy(e => e.Category)
            .ToList();

        Console.WriteLine("(.--______--.)");

        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Key}");
        }

        if (!int.TryParse(Console.ReadLine(), out int catChoice) ||
            catChoice < 1 || catChoice > categories.Count)
            return;

        var selectedCategory = categories[catChoice - 1].ToList();

        Console.WriteLine($"\nSelect exercise:\n");

        for (int i = 0; i < selectedCategory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {selectedCategory[i].GetType().Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int exChoice) ||
            exChoice < 1 || exChoice > selectedCategory.Count)
            return;

        Console.WriteLine("\n[Running...]\n");

        selectedCategory[exChoice - 1].Execute();

        Console.WriteLine("\n----------------");
    }
}