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
    class CategoryManager
    {
        public enum ManagerStatus
        {
            Success,
            JsonReadException,
            FailedToConnect,
            UnknownError,
            TitleMissing,
            InvalidUserType,         // Lecturers only!!!
            TitleAlreadyTaken,       // Unique titles only
            FieldsMissing,
            FailedToFindCategory     // Failed to find the category you were going to delete
        }
        public delegate void CategoryManagerDelegate(ManagerStatus status, Category category);
        public CategoryManagerDelegate AddCategoryResult { get; set; }
        public CategoryManagerDelegate RemoveCategoryResult { get; set; }
        public string PrivateKey { get; set; }
        private Thread categoryManagerThread;

        public CategoryManager() : this("") { }
        public CategoryManager(LocalUser user) : this(user.privateKey) { }
        public CategoryManager(string privateKey)
        {
            PrivateKey = privateKey;
        }
        public void addCategory(Category category)
        {
            if (categoryManagerThread != null && categoryManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(category.title) || String.IsNullOrWhiteSpace(category.title))
            {
                AddCategoryResult(ManagerStatus.TitleMissing, null);
                return;
            }
            categoryManagerThread = new Thread(() => apiLogic(true, category)); // There's probably a better way
            categoryManagerThread.Start();
        }

        public void removeCategory(Category category)
        {
            if (categoryManagerThread != null && categoryManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(category.title) || String.IsNullOrWhiteSpace(category.title))
            {
                RemoveCategoryResult(ManagerStatus.TitleMissing, null);
                return;
            }
            categoryManagerThread = new Thread(() => apiLogic(false, category)); // There's probably a better way
            categoryManagerThread.Start();
        }

        public void apiLogic(bool add, Category category)
        {
            JObject obj = new APICaller((add ? "addCategory.php" : "removeCategory.php"))
                .addParam("privateKey", PrivateKey)
                .addParam("title", category.title)
                .addParam("description", category.description)
                .call();
            ManagerStatus status = ManagerStatus.UnknownError;
            if (!Enum.TryParse<ManagerStatus>(obj["message"].ToString(), out status))
            {
                status = ManagerStatus.UnknownError;
            }
            if (add)
            {
                AddCategoryResult(status, category);
            }
            else
            {
                RemoveCategoryResult(status, category);
            }

        }
    }
}
