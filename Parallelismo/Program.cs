using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parallelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numeros = Enumerable.Range(0, 100);
            Parallel.ForEach(numeros, (i, loopState) =>
            {
                Console.WriteLine("O número acrescentado em 10 é {0}", i + 10);
                
                if (i + 10 > 50)
                {
                    loopState.Stop();
                }
                if (loopState.ShouldExitCurrentIteration)
                {
                    Console.WriteLine("Algum bloco paralelo solicitou a interrupção da action.");
                }
            });
            Console.ReadKey();
        }
    }
}