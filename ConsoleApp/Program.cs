using TestUtilLib;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading tests.json");
            Runner runner = new Runner();
            runner.Test();
            runner.Load();
            runner.Test();
        }
    }
}