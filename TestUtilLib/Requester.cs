using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TestUtilLib
{
    public class Requester
    {
        private readonly string _baseUrl;
        private RestClient _client;

        public Requester(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = buildClient();
        }

        private RestClient buildClient()
        {
            RestClient client = new(_baseUrl);
            client.AddDefaultHeader("User-Agent", $"TestUtil/{Assembly.GetExecutingAssembly().GetName().Version}");
            return client;
        }

        private RestRequest buildRequest(Test test)
        {
            Method method = Enum.Parse<Method>(test.Method);
            RestRequest request = new (test.Url, method);
            if (method != Method.Get) //todo more good code
            {
                request.AddJsonBody(test.Payload);
            }

            return request;
        }

        private async Task<RestResponse> sendRequest(Test test)
        {
            RestRequest request = buildRequest(test);
            return await _client.ExecuteAsync(request);
        }

        private async Task<bool> perform(Test test)
        {
            try
            {
                RestResponse response = await sendRequest(test);
                switch (test.Action)
                {
                    case ActionTypes.None:
                    default:
                        break;
                    case ActionTypes.SaveCookie:
                        _client.CookieContainer.SetCookies(new Uri(new Uri(_baseUrl), test.Url),
                            response.Headers.FirstOrDefault(x => x.Name.ToLower() == "cookies").Value.ToString() ??
                            string.Empty); //todo wrong?
                        break;
                }

                return response.Content.Contains(test.Expected);
            }
            catch (Exception e) //todo pass exception object with tuple
            {
                return false;
            }
            
        }

        public async Task<bool> PerformRequestAsync(Test test) => await perform(test);
    }
}
