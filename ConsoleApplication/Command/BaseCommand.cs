using ConsoleApplication.Helpers;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Command
{
    public abstract class BaseCommand
    {
        public abstract object GetRequest();

        public abstract void Valid(List<string> request);

        public abstract string ActionMetod { get; }

        HttpClient httpClient = new HttpClient();
        public virtual void Execute()
        {
            var json = JsonConvert.SerializeObject(this.GetRequest());
            string url = Helper.EndPointAddress + this.ActionMetod;
            Task<HttpResponseMessage> response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            string result = response.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine($"Called to {url} address");
            Console.WriteLine($"Result : {result}");
        }
    }
}
