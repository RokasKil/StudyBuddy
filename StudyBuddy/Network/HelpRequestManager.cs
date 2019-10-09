using Newtonsoft.Json.Linq;
using StudyBuddy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddy.Network
{
    class HelpRequestManager
    {
        public enum ManagerStatus
        {
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            TitleMissing,
            DescriptionMissing,
            CategoryMissing,
            FailedToFindCategory,    
            FieldsMissing,              
            FailedToFindHelpRequest     // Failed to find the helpRequest you were going to delete (or it doesn't belong to you)
        }
        public delegate void HelpRequestManagerDelegate(ManagerStatus status, HelpRequest helpRequest);
        public HelpRequestManagerDelegate PostHelpRequestResult { get; set; }
        public HelpRequestManagerDelegate RemoveHelpRequestResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread helpRequestManagerThread;
        
        public HelpRequestManager() : this("") { }
        public HelpRequestManager(LocalUser user) : this(user.privateKey) { }
        public HelpRequestManager(string privateKey)
        {
            PrivateKey = privateKey;
        }

        public void postHelpRequest(HelpRequest helpRequest)
        {
            if (helpRequestManagerThread != null && helpRequestManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(helpRequest.title) || String.IsNullOrWhiteSpace(helpRequest.title))
            {
                RemoveHelpRequestResult(ManagerStatus.TitleMissing, null);
                return;
            }
            if (String.IsNullOrEmpty(helpRequest.category) || String.IsNullOrWhiteSpace(helpRequest.category))
            {
                RemoveHelpRequestResult(ManagerStatus.CategoryMissing, null);
                return;
            }
            if (String.IsNullOrEmpty(helpRequest.description) || String.IsNullOrWhiteSpace(helpRequest.description))
            {
                RemoveHelpRequestResult(ManagerStatus.DescriptionMissing, null);
                return;
            }
            helpRequestManagerThread = new Thread(() => apiLogic(true, helpRequest)); // There's probably a better way
            helpRequestManagerThread.Start();
        }

        public void removeHelpRequest(HelpRequest helpRequest)
        {
            if (helpRequestManagerThread != null && helpRequestManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            helpRequestManagerThread = new Thread(() => apiLogic(false, helpRequest)); // There's probably a better way
            helpRequestManagerThread.Start();
        }

        public void apiLogic(bool post, HelpRequest helpRequest)
        {
            JObject obj;
            if (post)
            {
                obj = new APICaller("postHelpRequest.php")
                .addParam("privateKey", PrivateKey)
                .addParam("title", helpRequest.title)
                .addParam("description", helpRequest.description)
                .addParam("category", helpRequest.category)
                .call();
            }
            else
            {
                obj = new APICaller("removeHelpRequest.php")
                .addParam("privateKey", PrivateKey)
                .addParam("id", helpRequest.id.ToString())
                .call();
            }
            ManagerStatus status = ManagerStatus.UnknownError;
            if (!Enum.TryParse<ManagerStatus>(obj["message"].ToString(), out status))
            {
                status = ManagerStatus.UnknownError;
            }
            if (post)
            {
                PostHelpRequestResult(status, helpRequest);
            }
            else
            {
                RemoveHelpRequestResult(status, helpRequest);
            }

        }
    }
}
