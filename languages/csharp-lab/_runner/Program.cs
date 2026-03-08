using System.Reflection;

class Program
{
    static void Main()
    {
        var methods = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static))
            .Where(m => m.Name == "Run")
            .ToList();

         while (true)
        {
            Console.Clear();

            var categories = methods
                .GroupBy(m => m.DeclaringType!.Namespace!.Split('.').Last())
                .ToList();

            Console.WriteLine("(.--______--.)\n");
            Console.WriteLine("Categorias:\n");

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Key}");
            }

            Console.WriteLine("\n0. Sair");
            Console.Write("\n> ");

            if (!int.TryParse(Console.ReadLine(), out int catChoice))
                continue;

            if (catChoice == 0)
                break;

            if (catChoice < 1 || catChoice > categories.Count)
                continue;

            var selectedCategory = categories[catChoice - 1].ToList();

            Console.Clear();
            Console.WriteLine($"Categoria: {categories[catChoice - 1].Key}\n");

            for (int i = 0; i < selectedCategory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedCategory[i].DeclaringType!.Name}");
            }

            Console.WriteLine("\n0. Voltar");
            Console.Write("\n> ");

            if (!int.TryParse(Console.ReadLine(), out int exChoice))
                continue;

            if (exChoice == 0)
                continue;

            if (exChoice < 1 || exChoice > selectedCategory.Count)
                continue;

            var method = selectedCategory[exChoice - 1];

            Console.Clear();
            Console.WriteLine($"Executando: {method.DeclaringType!.Name}\n");

            try
            {
                var result = method.Invoke(null, null);

                if (result != null)
                {
                    Console.WriteLine("\nResultado:");
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.InnerException?.Message ?? ex.Message}");
            }

            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Pressione ENTER para voltar...");
            Console.ReadLine();
        }
    }
}