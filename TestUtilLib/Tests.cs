using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilLib
{
    public class Tests
    {
        private Parser _parser;
        public Tests(string jsonPath = "tests.json")
        {
            _parser = new(jsonPath);
        }
    }
}
