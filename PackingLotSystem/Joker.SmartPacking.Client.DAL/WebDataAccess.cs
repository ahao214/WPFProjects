using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.DAL
{
    public class WebDataAccess
    {
        private string domain = "http://localhost:5000/api/";

        public Task<string> GetDatas(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.GetAsync($"{domain}{url}").GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }
        }


        public Task<string> PostDatas(string url,HttpContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                var resp = client.PostAsync($"{domain}{url}",content).GetAwaiter().GetResult();
                return resp.Content.ReadAsStringAsync();
            }

        }
    }
}
