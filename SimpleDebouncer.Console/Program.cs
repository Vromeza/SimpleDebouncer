using SimpleDebouncer.Console.Services;
using System;

namespace SimpleDebouncer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Debouncer debouncer = new Debouncer();

            for (int i=0; i< 50; i++) {
                debouncer.Debounce("Scope", "UniqueSignature", "Requestor", () =>
                {
                    System.Console.WriteLine($"PASSED {i}");
                });
            }
            System.Console.ReadLine();
        }
    }
}
