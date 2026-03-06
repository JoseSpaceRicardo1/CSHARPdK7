using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runner.exercises
{
    public class TesteMat : IRunnable
    {
        public string Category => "exercises";

        public void Execute()
        {
            int a = 10;
            int b = 32;
            Console.WriteLine($"A soma de {a} + {b} é {a + b}");

            void Saudacao(string nome) => Console.WriteLine($"Olá, {nome}!");
            Saudacao("José");
        }
    }
}
