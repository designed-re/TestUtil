using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilLib
{
    public class Runner
    {
        private Parser _parser;
        public Runner(string jsonPath = "tests.json")
        {
            _parser = new(jsonPath);
        }

        public void Load()
        {
            bool load = _parser.Load();
            if (!load) throw new Exception("failed to load test definition");
        }

        public async Task Test()
        {
            TestDefine tests = _parser.GetTests();
            Requester requester = new(tests.BaseURL);
            int i = 1;
            foreach (var test in tests.Tests)
            {
                Console.WriteLine($"Performing {i++} of {tests.Tests.Count} Tests");
                Console.WriteLine("\tPerforming request");
                bool res = await requester.PerformRequestAsync(test);
                Console.WriteLine($"\tResult: {res}");
            }
            Console.WriteLine("Test completed.");
        }
    }
}
