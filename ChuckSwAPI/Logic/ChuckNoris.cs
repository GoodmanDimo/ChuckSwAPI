using ChuckSwAPI.Common;
using ChuckSwAPI.Models;
using ChuckSwAPI.WebRequests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChuckNoris.Logic
{
    public class ChuckNoris : ISearch
    {

        public List<string> GetCategories()
        {
            WebRequests requests = new("https://api.chucknorris.io/jokes/categories");

            if (requests == null)
                return null;

            using (var r = new StreamReader(requests.webRespose.GetResponseStream()))
            {
                string json = r.ReadToEnd().Trim();

                char[] delimiterChars = {'"','"',' ',',', '[', ']'};

                string[] words = json.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);
      
                return words.ToList();
            }
        }


        public async Task<Object> Search(string query)
        {
            WebRequests requests = new($"https://api.chucknorris.io/jokes/search?query=" + query);

            if (requests == null)
                return null;

            using (var r = new StreamReader(requests.webRespose.GetResponseStream()))
            {
                string json = r.ReadToEnd().Trim();
                var jsonObject = JsonConvert.DeserializeObject(json);

                return jsonObject;
            }
        }
    }
}
