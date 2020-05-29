using System;
namespace Permutacao
{
    class Program
    {
        private static void Main(string[] args)
        {
            var WordPermute = new WordPermutation();
            var start = DateTime.Now;
            WordPermute.Find("ABCDEFGHIJKLMNOPQRSTUWXYZ");
            var end = DateTime.Now;
            Console.WriteLine($"Levou {end.Subtract(start).Seconds} segundos e {end.Subtract(start).Milliseconds} milisegundos");
        }
    }
}