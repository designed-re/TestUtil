using TestUtilLib;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Loading tests.json");
            Runner runner = new Runner();
            runner.Load();
            await runner.Test();
        }
    }
}