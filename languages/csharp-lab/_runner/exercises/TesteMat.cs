namespace runner.exercises;
public class TesteMat
{
    public static void Run()
    {
        var a = 10;
        var b = 32;
        Console.WriteLine($"A soma de {a} + {b} é {a + b}");

        void Saudacao(string nome) => Console.WriteLine($"Olá, {nome}!");
        Saudacao("José");

        Console.Write("Digite algo: ");
        var input = Console.ReadLine();
        Console.WriteLine($"Você digitou: {input}");

    }
}
    