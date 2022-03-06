using ChuckSwAPI.Common;
using ChuckSwAPI.Models;
using ChuckSwAPI.WebRequests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Swapi.Logic
{
    public class Swapi : ISearch
    {
        public List<results> GetPeople()
        {
            WebRequests requests = new("https://swapi.dev/api/people");

            if (requests == null)
                return null;

            using (var r = new StreamReader(requests.webRespose.GetResponseStream()))
            {
                string json = r.ReadToEnd().Trim();
                var jsonObject = (JObject)JsonConvert.DeserializeObject(json);
                var JsonResults = jsonObject["results"];
                return JsonConvert.DeserializeObject<List<results>>(JsonResults.ToString());
            }
        }

        public async Task<Object> Search(string query)
        {
          
            WebRequests requests = new($"https://swapi.dev/api/people/?search=" + query);

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
