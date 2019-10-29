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
    public class HelpRequestManager
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
        public HelpRequestManager(LocalUser user) : this(user.PrivateKey) { }
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
            if (String.IsNullOrEmpty(helpRequest.Title) || String.IsNullOrWhiteSpace(helpRequest.Title))
            {
                RemoveHelpRequestResult(ManagerStatus.TitleMissing, null);
                return;
            }
            if (String.IsNullOrEmpty(helpRequest.Category) || String.IsNullOrWhiteSpace(helpRequest.Category))
            {
                RemoveHelpRequestResult(ManagerStatus.CategoryMissing, null);
                return;
            }
            if (String.IsNullOrEmpty(helpRequest.Description) || String.IsNullOrWhiteSpace(helpRequest.Description))
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
                .addParam("title", helpRequest.Title)
                .addParam("description", helpRequest.Description)
                .addParam("category", helpRequest.Category)
                .call();
            }
            else
            {
                obj = new APICaller("removeHelpRequest.php")
                .addParam("privateKey", PrivateKey)
                .addParam("id", helpRequest.Id.ToString())
                .call();
            }
            ManagerStatus status = ManagerStatus.UnknownError;
            if (!Enum.TryParse<ManagerStatus>(obj["message"].ToString(), out status))
            {
                status = ManagerStatus.UnknownError;
            }
            if (post)
            {
                if (status == ManagerStatus.Success)
                {
                    helpRequest.Id = obj["id"].ToObject<int>(); 
                }
                    PostHelpRequestResult(status, helpRequest);
            }
            else
            {
                RemoveHelpRequestResult(status, helpRequest);
            }

        }
    }
}
