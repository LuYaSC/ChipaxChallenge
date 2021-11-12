using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ChallengeAPI.Connectors.Base
{
    public abstract class RestFulConnector<RESPONSE> : BaseConnector<RESPONSE>
        where RESPONSE : class, new()
    {
        public RestFulConnector(string url) : base()
        {
            this.url = url;
        }
        protected string url;

        protected override bool Process()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
            
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return false;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            if(!string.IsNullOrEmpty(responseBody))
                            {
                                this.Response.Body = JsonConvert.DeserializeObject<RESPONSE>(responseBody);
                            }
                           
                        }
                    }
                }
            }
            catch (Exception e)
            {
                this.Response.SetException(e);
                return false;
            }
            return true;
        }
    }
}
