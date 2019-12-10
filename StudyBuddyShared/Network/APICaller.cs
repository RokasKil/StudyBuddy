using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddyShared.Network
{
    public class APICaller // Helper klasė kviečiant api calls
    {
        static APICaller() {
            System.Net.ServicePointManager.DefaultConnectionLimit = 100; // Pakeliam limit,nes default max 2
        }

        const string API_ROOT = "https://717592.s.dedikuoti.lt/StudyBuddy/API/";
        public string Api { get; set; } = "";
        public NameValueCollection PostParams { get; private set; } = new NameValueCollection();

        public delegate void APICallResultDelegate(JObject response);
        public APICallResultDelegate APICallResult { get; set; }
        private Thread callThread;

        public APICaller() : this("") { }
        public APICaller(string api)
        {
            Api = api;
        }

        public APICaller SetApi(string api)
        {
            Api = api;
            return this;
        }

        public APICaller AddParam(string param, string value)
        {
            PostParams.Add(param, value);
            return this;
        }

        public APICaller AddDelegate(APICallResultDelegate reciever)
        {
            APICallResult += reciever;
            return this;
        }
        public APICaller RemoveParam(string param, string value)
        {
            PostParams.Remove(param);
            return this;
        }

        public void CallAsync()
        {
            callThread = new Thread(() => APICallResult(Call()));
            callThread.Start();
        }

        public JObject Call()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string response = "";
                    if (PostParams.Count == 0)
                    {
                        response = client.DownloadString(API_ROOT + Api);
                    }
                    else
                    {
                        byte[] responsebytes = client.UploadValues(API_ROOT + Api, "POST", PostParams);
                        response = Encoding.UTF8.GetString(responsebytes);
                    }
                    try
                    {
                        return JObject.Parse(response);

                    }
                    catch (JsonReaderException exception)
                    {
                        JObject obj = new JObject();
                        obj["status"] = "failed";
                        obj["message"] = "JsonReadException";
                        obj["response"] = response;
                        return obj;
                    }
                }
                catch (Exception exception)
                {
                    JObject obj = new JObject();
                    obj["status"] = "failed";
                    obj["message"] = "FailedToConnect";
                    obj["exception"] = exception.ToString();
                    return obj;
                }
            }
        }
    }
}
