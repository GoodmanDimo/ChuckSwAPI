using System.Net;

namespace ChuckSwAPI.WebRequests
{
    public class WebRequests
    {
        public WebResponse webRespose { get; set; }

        public WebRequests(string URL)
        {
            var req = WebRequest.Create(URL);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "GET";

            webRespose = req.GetResponse();
        }
    }
}
