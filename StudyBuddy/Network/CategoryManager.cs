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
    public class CategoryManager
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
        public enum CategoryModification
        {
            Add = 0,
            Remove = 1,
            Update = 2
        }
        public delegate void CategoryManagerDelegate(ManagerStatus status, Category category);
        public CategoryManagerDelegate AddCategoryResult { get; set; }
        public CategoryManagerDelegate RemoveCategoryResult { get; set; }
        public CategoryManagerDelegate UpdateCategoryResult { get; set; }
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
            if (String.IsNullOrEmpty(category.Title) || String.IsNullOrWhiteSpace(category.Title))
            {
                AddCategoryResult(ManagerStatus.TitleMissing, null);
                return;
            }
            categoryManagerThread = new Thread(() => apiLogic(CategoryModification.Add, category)); // There's probably a better way
            categoryManagerThread.Start();
        }

        public void removeCategory(Category category)
        {
            if (categoryManagerThread != null && categoryManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(category.Title) || String.IsNullOrWhiteSpace(category.Title))
            {
                RemoveCategoryResult(ManagerStatus.TitleMissing, null);
                return;
            }
            categoryManagerThread = new Thread(() => apiLogic(CategoryModification.Remove, category)); // There's probably a better way
            categoryManagerThread.Start();
        }

        public void updateCategory(Category category)
        {
            if (categoryManagerThread != null && categoryManagerThread.IsAlive) // Jau vyksta užklausa
            {
                return;
            }
            if (String.IsNullOrEmpty(category.Title) || String.IsNullOrWhiteSpace(category.Title))
            {
                RemoveCategoryResult(ManagerStatus.TitleMissing, null);
                return;
            }
            categoryManagerThread = new Thread(() => apiLogic(CategoryModification.Update, category)); // There's probably a better way
            categoryManagerThread.Start();
        }
        public void apiLogic(CategoryModification categoryStatus, Category category)
        {   
            string modificationType;
            switch((int) categoryStatus)
            {
                case 0:
                    modificationType = "addCategory.php";
                    break;
                case 1:
                    modificationType = "removeCategory.php";
                    break;
                case 2:
                    modificationType = "updateCategory.php";
                    break;
                default:
                    modificationType = "false";
                    break;
            }
            JObject obj = new APICaller(modificationType)
                .addParam("privateKey", PrivateKey)
                .addParam("title", category.Title)
                .addParam("description", category.Description)
                .call();
            ManagerStatus status = ManagerStatus.UnknownError;
            if (!Enum.TryParse<ManagerStatus>(obj["message"].ToString(), out status))
            {
                status = ManagerStatus.UnknownError;
            }
            switch((int) categoryStatus)
            {
                case 0:
                    AddCategoryResult(status, category);
                    break;
                case 1:
                    RemoveCategoryResult(status, category);
                    break;
                case 2:
                    UpdateCategoryResult(status, category);
                    break;
            }
        }
    }
}
