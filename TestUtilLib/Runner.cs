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

        public void Test()
        {
            Console.WriteLine(_parser.GetTests().ToJson());
        }
    }
}
