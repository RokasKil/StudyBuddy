using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyBuddyShared.Entity;
using StudyBuddyShared.SystemManager;
using StudyBuddyShared.AuthenticationSystem; // Done
using StudyBuddyShared.CategorySystem;       // Done
using StudyBuddyShared.ConversationSystem;   // Done
using StudyBuddyShared.HelpRequestSystem;    // Done
using StudyBuddyShared.UserReviewSystem;     // Done
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
        public void CategoryFullTest()
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
            LocalUser user = UnitTestAuth.Login();
            var statusManager = HelpRequestManageStatus.UnknownError;
            var statusGetterHelp = HelpRequestGetStatus.UnknownError;
            var statusGetterCategories = CategoryGetStatus.UnknownError;
            bool done = false;
            HelpRequest helpRequest;
            List<HelpRequest> helpRequests = null;
            Dictionary<String, User> users = null;
            List<Category> categories = null;
            
            var adder = HelpRequestSystemManager.NewHelpRequestPoster();
            var remover = HelpRequestSystemManager.NewHelpRequestRemover();
            adder.Result = (_status, _helpRequest) =>
            {
                statusManager = _status;
                helpRequest = _helpRequest;
                done = true;
            };

            remover.Result = (_status, _helpRequest) =>
            {
                statusManager = _status;
                helpRequest = _helpRequest;
                done = true;
            };

            var getterHelpRequest = HelpRequestSystemManager.NewHelpRequestGetter();
            getterHelpRequest.Result += (_status, _helpRequests, _users) =>
            {
                statusGetterHelp = _status;
                helpRequests = _helpRequests;
                users = _users;
                done = true;

            };
            var getterCategories = CategorySystemManager.NewCategoryGetter(); ;
            getterCategories.Result += (_status, _categories) => {
                statusGetterCategories = _status;
                categories = _categories;
                done = true;
            };

            ///Gaunam Kategorijas
            done = false;
            getterCategories.Get();
            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoryGetStatus.Success);
            Assert.AreNotEqual(categories, null);
            Assert.AreNotEqual(categories.Count, 0);
            ///

            ///Siunčiam helpRequest
            done = false;
            var random = new Random();

            helpRequest = new HelpRequest { Title = random.Next().ToString(), Description = random.Next().ToString(), Category = categories[0].Title };
            adder.Post(helpRequest);

            while (!done) { }
            Assert.AreEqual(statusManager, HelpRequestManageStatus.Success);
            Assert.AreNotEqual(helpRequest, null);
            ///

            ///Gaunam visus helpRequest
            done = false;
            getterHelpRequest.Get(true);
            while (!done) { }

            Assert.AreEqual(statusGetterHelp, HelpRequestGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(helpRequests, null);
            ///Tikrinam ar mūsų yra
            var myHelpRequest = helpRequests.Find((_helpRequest) =>
            {
                return _helpRequest.Title == helpRequest.Title &&
                    _helpRequest.Description == helpRequest.Description &&
                    _helpRequest.CreatorUsername == user.Username &&
                    _helpRequest.Category == categories[0].Title;
            });
            Assert.AreNotEqual(myHelpRequest, null);
            ///

            ///Trinam helpRequest
            done = false;
            remover.Remove(helpRequest);

            while (!done) { }
            Assert.AreEqual(statusManager, HelpRequestManageStatus.Success);
            Assert.AreNotEqual(helpRequest, null);
            ///


            ///Gaunam visus helpRequest
            done = false;
            getterHelpRequest.Get(true);
            while (!done) { }

            Assert.AreEqual(statusGetterHelp, HelpRequestGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(helpRequests, null);
            ///Tikrinam ar mūsų nėra
            myHelpRequest = helpRequests.Find((_helpRequest) =>
            {
                return _helpRequest.Title == helpRequest.Title &&
                    _helpRequest.Description == helpRequest.Description &&
                    _helpRequest.CreatorUsername == user.Username &&
                    _helpRequest.Category == categories[0].Title;
            });
            Assert.AreEqual(myHelpRequest, null);
            ///
        }
    }
    #endregion

    #region Conversation tests
    [TestClass]
    public class UnitTestConversations
    {
        [TestMethod]
        [Timeout(10000)]
        public void ConversationGetterTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var status = ConversationGetStatus.UnknownError;
            bool done = false;

            List<Conversation> conversations = null;
            Dictionary<String, User> users = null;

            var getter = ConversationSystemManager.NewConversationGetter();
            getter.Result += (_status, _conversations, _users) =>
            {
                status = _status;
                conversations = _conversations;
                users = _users;
                done = true;

            };
            getter.GetUsers = true;
            getter.GetConversations();
            while (!done) { }
            Assert.AreEqual(status, ConversationGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(conversations, null);
        }
        [TestMethod]
        [Timeout(10000)]
        public void ConversationStarterTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var status = ConversationStartStatus.UnknownError;
            bool done = false;

            Conversation conversation = null;
            Dictionary<String, User> users = null;

            var starter = ConversationSystemManager.NewConversationStarter();
            starter.Result += (_status, _conversation, _users) =>
            {
                status = _status;
                conversation = _conversation;
                users = _users;
                done = true;

            };
            starter.StartConversation("test4");
            while (!done) { }
            Assert.AreEqual(status, ConversationStartStatus.Success);
            Assert.AreNotEqual(conversation, null);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(users["test4"], null);
        }
        [TestMethod]
        [Timeout(10000)]
        public void ConversationFullTest()
        {
            LocalUser user = UnitTestAuth.Login(username: "test1", password: "pass1");
            var statusGetterConversation = ConversationGetStatus.UnknownError;
            var statusStarter = ConversationStartStatus.UnknownError;
            var statusPoster = MessageSendStatus.UnknownError;
            var statusGetterMessages = MessageGetAllStatus.UnknownError;
            bool done = false;
            Conversation conversation = null;
            Message message = null;
            Dictionary<int, List<Message>> messages = null;
            List<Conversation> conversations = null;
            Dictionary<String, User> users = null;


            var getterConv = ConversationSystemManager.NewConversationGetter();
            getterConv.Result += (_status, _conversations, _users) => {
                statusGetterConversation = _status;
                conversations = _conversations;
                users = _users;
                done = true;

            };

            var conversationStarter = ConversationSystemManager.NewConversationStarter();
            conversationStarter.Result += (_status, _conversation, _users) =>
            {
                statusStarter = _status;
                conversation = _conversation;
                users = _users;
                done = true;
            };

            var messagePoster = ConversationSystemManager.NewMessageSender();
            messagePoster.Result += (_status, _message) =>
            {
                statusPoster = _status;
                message = _message;
                done = true;
            };

            var messageGetter = ConversationSystemManager.NewMessageGetter();
            messageGetter.Result += (_status, _conversations, _messages, _users) =>
            {
                statusGetterMessages = _status;
                conversations = _conversations;
                messages = _messages;
                users = _users;
                done = true;
            };

            ///Pradedam Conversation
            done = false;
            
            conversationStarter.StartConversation("test4");

            while (!done) { }
            Assert.AreEqual(statusStarter, ConversationStartStatus.Success);
            Assert.AreNotEqual(conversation, null);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(users["test4"], null);
            ///

            ///Gaunam messages
            done = false;
            messageGetter.GetMessages();

            while (!done) { }
            Assert.AreEqual(statusGetterMessages, MessageGetAllStatus.Success);
            Assert.AreNotEqual(messages, null);
            Assert.AreNotEqual(conversations, null);
            Assert.AreNotEqual(users, null);
            var timestamp = (messages.ContainsKey(conversation.Id) && messages[conversation.Id].Count > 0 ? messages[conversation.Id][messages[conversation.Id].Count - 1].Timestamp : 0);
            /// 

            ///Siunčiam message
            var random = new Random();
            done = false;
            messagePoster.StartSending();
            messagePoster.AddMessageToQueue(new Message
            {
                Conversation = conversation.Id,
                Text = random.Next().ToString()

            });

            while (!done) { }
            Assert.AreEqual(statusPoster, MessageSendStatus.Success);
            Assert.AreNotEqual(message, null);
            ///

            ///Gaunam messages
            done = false;
            messageGetter.TimeStamp = timestamp;
            messageGetter.GetMessages();

            while (!done) { }
            Assert.AreEqual(statusGetterMessages, MessageGetAllStatus.Success);
            Assert.AreNotEqual(messages, null);
            Assert.AreNotEqual(conversations, null);
            Assert.AreNotEqual(users, null);
            Assert.AreEqual(messages.ContainsKey(conversation.Id), true);

            ///Tikrinam ar nusisiuntė
            var myMessage = messages[conversation.Id].Find((_message) =>
            {
                return _message.Text == message.Text &&
                    _message.Username == user.Username;
            });
            Assert.AreNotEqual(myMessage, null);
            /// 

            ///Gaunam conversations
            done = false;
            getterConv.GetUsers = true;
            getterConv.GetConversations();
            while (!done) { }

            Assert.AreEqual(statusGetterConversation, ConversationGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(conversations, null);

            var myConversation = conversations.Find((_conversation) =>
            {
                return _conversation.Id == conversation.Id;
            });
            Assert.AreNotEqual(myConversation, null);
            ///
        }
    }
    #endregion Conversation tests

    #region UserReview tests
    [TestClass]
    public class UnitTestUserReview
    {
        [TestMethod]
        [Timeout(1000)]
        public void UserReviewGetterTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var status = UserReviewsGetStatus.UnknownError;
            bool done = false;

            List<UserReview> userReviews = null;
            Dictionary<String, User> users = null;


            var getter = UserReviewSystemManager.NewUserReviewGetter();
            getter.Result += (_status, _userReviews, _users) => {
                status = _status;
                userReviews = _userReviews;
                users = _users;
                done = true;

            };
            
            getter.Get(user.Username, true);
            while (!done) { }
            Assert.AreEqual(status, UserReviewsGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(userReviews, null);
        }

        [TestMethod]
        [Timeout(1000)]
        public void UserReviewFullTest()
        {
            LocalUser user = UnitTestAuth.Login();
            var getStatus = UserReviewsGetStatus.UnknownError;
            var postStatus = UserReviewManageStatus.UnknownError;
            var removeStatus = UserReviewManageStatus.UnknownError;
            bool done = false;

            UserReview review = null;
            List<UserReview> userReviews = null;
            Dictionary<String, User> users = null;
            var random = new Random();
            var message = random.Next().ToString();

            var getter = UserReviewSystemManager.NewUserReviewGetter();
            getter.Result += (_status, _userReviews, _users) => {
                getStatus = _status;
                userReviews = _userReviews;
                users = _users;
                done = true;

            };

            var poster = UserReviewSystemManager.NewUserReviewPoster();
            poster.Result += (_status, _review) =>
            {
                postStatus = _status;
                review = _review;
                done = true;
            };

            var remover = UserReviewSystemManager.NewUserReviewRemover();
            remover.Result += (_status, _review) =>
            {
                removeStatus = _status;
                review = _review;
                done = true;
            };
            /// Siunčiam review
            done = false;
            poster.Post(new UserReview
            {
                Username = "test4",
                Message = message,
                Karma = 1
            });
            while (!done) { }
            Assert.AreEqual(postStatus, UserReviewManageStatus.Success);
            Assert.AreNotEqual(review, null);
            ///
            /// Gaunam reviews ir patikrinam ar esam sąraše
            done = false;
            getter.Get("test4", true);
            while (!done) { }
            Assert.AreEqual(getStatus, UserReviewsGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(users[user.Username], null);
            Assert.AreNotEqual(userReviews, null);
            Assert.AreNotEqual(userReviews.Find((_review) => _review.Username == user.Username && _review.Message == message), null);
            ///
            /// Trinam review
            done = false;
            remover.Remove(new UserReview
            {
                Username = "test4",
            });
            while (!done) { }
            Assert.AreEqual(removeStatus, UserReviewManageStatus.Success);
            Assert.AreNotEqual(review, null);
            ///

            /// Gaunam reviews ir patikrinam ar nesam sąraše
            done = false;
            getter.Get("test4", true);
            while (!done) { }
            Assert.AreEqual(getStatus, UserReviewsGetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(userReviews, null);
            Assert.AreEqual(userReviews.Find((_review) => _review.Username == user.Username && _review.Message == message), null);
            ///
        }
    }
    #endregion
}
