using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyBuddyShared.Entity;
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.AuthenticationSystem; // Done
using StudyBuddyShared.CategorySystem;       // Done
using StudyBuddyShared.ConversationSystem;   // 
using StudyBuddyShared.HelpRequestSystem;    // 
using StudyBuddyShared.UserReviewSystem;     // 
using StudyBuddyShared.UserSystem;           // No user profile
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    #region Authentication tests
    [TestClass]
    public class UnitTestAuth
    {
        [TestMethod]
        [Timeout(10000)]
        public void LoginTest()
        {
            Login();
        }

        public static LocalUser Login(string username = "test1", string password = "pass1")
        {

            AuthenticatorStatus status = AuthenticatorStatus.UnknownError;
            LocalUser user = null;
            bool done = false;
            var auth = AuthenticationSystemManager.NewAuthenticator();
            auth.Result += (_status, _user) =>
            {
                status = _status;
                user = _user;
                done = true;
            };
            auth.Login(username, password);
            while (!done) { }
            Assert.AreEqual(status, AuthenticatorStatus.Success);
            Assert.AreNotEqual(user, null);
            Assert.AreEqual(user.Username, username);
            LocalUserManager.LocalUser = user;
            return user;
        }

        [TestMethod]
        [Timeout(10000)]
        public void PrivateKeyTest()
        {
            LocalUser user = Login();
            bool done = false;
            LocalUser user1 = null;
            AuthenticatorStatus status = AuthenticatorStatus.UnknownError;

            var auth = AuthenticationSystemManager.NewAuthenticator();
            auth.Result += (_status, _user) =>
            {
                status = _status;
                user1 = _user;
                done = true;
            };
            auth.Login(user.PrivateKey);
            while (!done) { }
            Assert.AreEqual(status, AuthenticatorStatus.Success);
            Assert.AreEqual(user.PrivateKey, user1.PrivateKey);
            Assert.AreEqual(user.Username, user1.Username);
        }
    }
    #endregion Authentication tests

    #region User tests
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        [Timeout(10000)]
        public void UserGetterTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var status = UserGetStatus.UnknownError;
            bool done = false;
            User user1 = null;

            var getter = UserSystemManager.UserGetter();
            getter.Result += (_status, _user) =>
            {
                status = _status;
                user1 = _user;
                done = true;
            };
            getter.Get(user.Username);
            while (!done) { }
            Assert.AreEqual(status, UserGetStatus.Success);
            Assert.AreEqual(user.Username, user1.Username);
        }

        [TestMethod]
        [Timeout(10000)]
        public void UserUpdaterTest()
        {
            LocalUser user = UnitTestAuth.Login(username: "test4", password: "pass4");
            var statusUpdater = UserUpdateStatus.UnknownError;
            var statusGetter = UserGetStatus.UnknownError;
            bool done = false;
            User user1 = null;
            string firstName = "";
            string lastName = "";
            var random = new Random();

            var updater = UserSystemManager.UserUpdater();
            updater.Result += (_status, _firstName, _lastName) =>
            {
                statusUpdater = _status;
                firstName = _firstName;
                lastName = _lastName;
                done = true;
            };

            var getter = UserSystemManager.UserGetter();
            getter.Result += (_status, _user) =>
            {
                statusGetter = _status;
                user1 = _user;
                done = true;
            };

            firstName = random.Next().ToString();
            lastName = random.Next().ToString();

            done = false;
            updater.Update(firstName, lastName);

            while (!done) { }
            Assert.AreEqual(statusUpdater, UserUpdateStatus.Success);
            Assert.AreNotEqual(firstName, null);
            Assert.AreNotEqual(lastName, null);

            done = false;
            getter.Get(user.Username);

            while (!done) { }
            Assert.AreEqual(statusGetter, UserGetStatus.Success);
            Assert.AreEqual(user.Username, user1.Username);
            Assert.AreNotEqual(user.FirstName, user1.FirstName);
            Assert.AreNotEqual(user.LastName, user1.LastName);
            Assert.AreEqual(firstName, user1.FirstName);
            Assert.AreEqual(lastName, user1.LastName);

            done = false;
            updater.Update(user.FirstName, user.LastName);

            while (!done) { }
            Assert.AreEqual(statusUpdater, UserUpdateStatus.Success);
            Assert.AreNotEqual(firstName, null);
            Assert.AreNotEqual(lastName, null);

            done = false;
            getter.Get(user.Username);

            while (!done) { }
            Assert.AreEqual(statusGetter, UserGetStatus.Success);
            Assert.AreEqual(user.Username, user1.Username);
            Assert.AreEqual(user.FirstName, user1.FirstName);
            Assert.AreEqual(user.LastName, user1.LastName);
        }
    }
    #endregion

    #region Category tests
    [TestClass]
    public class UnitTestCategory
    {
        [TestMethod]
        [Timeout(10000)]
        public void CategoryGetterTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var status = CategoryGetStatus.UnknownError;
            bool done = false;
            List<Category> categories = null;
            var getter = CategorySystemManager.NewCategoryGetter();

            getter.Result += (_status, _categories) =>
            {
                status = _status;
                categories = _categories;
                done = true;
            };
            getter.Get();
            while (!done) { }
            Assert.AreEqual(status, CategoryGetStatus.Success);
            Assert.AreNotEqual(categories, null);
        }

        [TestMethod]
        [Timeout(10000)]
        public void CategoriesManagerFullTest()
        {
            LocalUser user = UnitTestAuth.Login(username: "test2", password: "pass2");
            var statusManager = CategoryManageStatus.UnknownError;
            var statusGetterCategories = CategoryGetStatus.UnknownError;
            bool done = false;
            Category category;
            List<Category> categories = null;
            var categoryAdder = CategorySystemManager.NewCategoryAdder();
            var categoryRemover = CategorySystemManager.NewCategoryRemover();
            var categoryUpdater = CategorySystemManager.NewCategoryUpdater();

            categoryAdder.Result = (_status, _category) =>
            {
                statusManager = _status;
                category = _category;
                done = true;
            };

            categoryRemover.Result = (_status, _category) =>
            {
                statusManager = _status;
                category = _category;
                done = true;
            };

            categoryUpdater.Result = (_status, _category) =>
            {
                statusManager = _status;
                category = _category;
                done = true;
            };

            var getter = CategorySystemManager.NewCategoryGetter();
            getter.Result += (_status, _categories) =>
            {
                statusGetterCategories = _status;
                categories = _categories;
                done = true;
            };

            ///Siunčiam category
            done = false;
            var random = new Random();

            category = new Category { Title = random.Next().ToString(), Description = random.Next().ToString() };
            categoryAdder.AddCategory(category);

            while (!done) { }
            Assert.AreEqual(statusManager, CategoryManageStatus.Success);
            Assert.AreNotEqual(category, null);
            ///

            ///Gaunam categories
            done = false;
            getter.Get();

            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoryGetStatus.Success);
            Assert.AreNotEqual(categories, null);
            ///Tikrinam ar yra mūsų
            var myCategory = categories.Find((_category) =>
            {
                return _category.Title == category.Title &&
                    _category.Description == category.Description &&
                    _category.CreatorUsername == user.Username;
            });
            Assert.AreNotEqual(myCategory, null);
            ///

            ///Naujinam category
            category.Description += random.Next().ToString();
            done = false;
            categoryUpdater.UpdateCategory(category);

            while (!done) { }
            Assert.AreEqual(statusManager, CategoryManageStatus.Success);
            Assert.AreNotEqual(category, null);
            ///

            ///Gaunam categories
            done = false;
            getter.Get();

            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoryGetStatus.Success);
            Assert.AreNotEqual(categories, null);
            ///Tikrinam ar atsinaujino
            myCategory = categories.Find((_category) =>
            {
                return _category.Title == category.Title &&
                    _category.Description == category.Description &&
                    _category.CreatorUsername == user.Username;
            });
            Assert.AreNotEqual(myCategory, null);
            ///

            ///Trinam category
            done = false;
            categoryRemover.RemoveCategory(category);

            while (!done) { }
            Assert.AreEqual(statusManager, CategoryManageStatus.Success);
            Assert.AreNotEqual(category, null);
            ///

            ///Gaunam categories
            done = false;
            getter.Get();

            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoryGetStatus.Success);
            Assert.AreNotEqual(categories, null);
            ///Tikrinam ar išsitrynė
            myCategory = categories.Find((_category) =>
            {
                return _category.Title == category.Title &&
                    _category.Description == category.Description &&
                    _category.CreatorUsername == user.Username;
            });
            Assert.AreEqual(myCategory, null);
            ///
        }
    }
    #endregion

    #region HelpRequests tests
    [TestClass]
    public class UnitTestHelpRequest
    {
        [TestMethod]
        [Timeout(10000)]
        public void HelpRequestGetterTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var status = HelpRequestGetStatus.UnknownError;
            bool done = false;

            List<HelpRequest> helpRequests = null;
            Dictionary<String, User> users = null;

            var getter = HelpRequestSystemManager.NewHelpRequestGetter();
            getter.Result += (_status, _helpRequests, _users) =>
            {
                status = _status;
                helpRequests = _helpRequests;
                users = _users;
                done = true;

            };
            getter.Get(true);
            while (!done) { }
            Assert.AreEqual(status, HelpRequestGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(helpRequests, null);
        }

        [TestMethod]
        [Timeout(10000)]
        public void HelpRequestFullTest()
        {

        }
    }
    #endregion
}
