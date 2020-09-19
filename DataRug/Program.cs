using System;

namespace DataRug
{
    class Program
    {
        static void Main(string[] args)
        {
            var cOne = Mass.Milligrams(100);
            var cTwo = Mass.Grams(1);

            var cResult = cOne + cTwo;
            var cResultValue = cResult.Value ?? default;

            Console.WriteLine($"100mg + 1g = {cResultValue}mg");
            Console.ReadLine();
        }
    }
}
