using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilLib
{
    /// <summary>
    /// Defines Tests
    /// </summary>
    public partial class TestDefine
    {
        [JsonProperty("tests")]
        public List<Test> Tests { get; set; }

        [JsonProperty("base_url")]
        public string BaseURL { get; set; }
    }

    public class Test
    {
        /// <summary>
        /// Test HTTP Method
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Test URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Test Body
        /// </summary>
        /// <remarks>Only works on POST,PUT like requests</remarks>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Action for next Test
        /// </summary>
        [JsonProperty("action")]
        public ActionTypes Action { get; set; }

        /// <summary>
        /// Expected response, using Contains
        /// </summary>
        [JsonProperty("expected")]
        public string Expected { get; set; }
    }

    public partial class TestDefine
    {
        public static TestDefine FromJson(string json) => JsonConvert.DeserializeObject<TestDefine>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this TestDefine self) => JsonConvert.SerializeObject(self);
    }

}
