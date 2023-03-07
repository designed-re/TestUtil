using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilLib
{
    internal class Parser
    {
        private TestDefine _define;
        private string _jsonPath;
        public Parser(string jsonPath)
        {
            _jsonPath = jsonPath;
        }

        public bool Load()
        {
            try
            {
                _define = TestDefine.FromJson(File.ReadAllText(_jsonPath, Encoding.UTF8));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TestDefine GetTests() => _define;
    }
}
