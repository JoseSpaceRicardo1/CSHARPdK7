
namespace runner.exercises
{
    public class HelloWorld : IRunnable
    {
        public string Category => "exercises";
        public void Execute()
        {
            Console.WriteLine("Hello World");
        }
    }
}
