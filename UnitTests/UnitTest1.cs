using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyBuddy.Entity;
using StudyBuddy.Network;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        
        [TestMethod]
        [Timeout(1000)]
        public void LoginTest()
        {
            Login();
        }

        public LocalUser Login(string username = "test1", string password = "pass1")
        {
            
            Authenticator.AuthStatus status = Authenticator.AuthStatus.UnknownError;
            LocalUser user = null;
            bool done = false;
            var auth = new Authenticator((_status, _user) => {
                status = _status;
                user = _user;
                done = true;
            });
            auth.login(username, password);
            while (!done) { }
            Assert.AreEqual(status, Authenticator.AuthStatus.Success);
            Assert.AreNotEqual(user, null);
            Assert.AreEqual(user.Username, username);
            return user;
        }

        [TestMethod]
        [Timeout(1000)]
        public void PrivateKeyTest()
        {
            LocalUser user = Login();
            bool done = false;
            LocalUser user1 = null;
            Authenticator.AuthStatus status = Authenticator.AuthStatus.UnknownError;
            
            var auth = new Authenticator((_status, _user) => {
                status = _status;
                user1 = _user;
                done = true;
            });
            auth.login(user.PrivateKey);
            while (!done) { }
            Assert.AreEqual(status, Authenticator.AuthStatus.Success);
            Assert.AreEqual(user.PrivateKey, user1.PrivateKey);
            Assert.AreEqual(user.Username, user1.Username);
        }

        [TestMethod]
        [Timeout(1000)]
        public void UserGetterTest()
        {
            LocalUser user = Login();
            var status = UserGetter.GetStatus.UnknownError;
            bool done = false;
            User user1 = null;

            var getter = new UserGetter(user, (_status, _user) => {
                status = _status;
                user1 = _user;
                done = true;
            });
            getter.get(user.Username);
            while (!done) { }
            Assert.AreEqual(status, UserGetter.GetStatus.Success);
            Assert.AreEqual(user.Username, user1.Username);
        }

        [TestMethod]
        [Timeout(1000)]
        public void CategoriesGetterTest()
        {
            LocalUser user = Login();
            var status = CategoriesGetter.GetStatus.UnknownError;
            bool done = false;
            List<Category> categories = null;

            var getter = new CategoriesGetter(user, (_status, _categories) => {
                status = _status;
                categories = _categories;
                done = true;
            });
            getter.get();
            while (!done) { }
            Assert.AreEqual(status, CategoriesGetter.GetStatus.Success);
            Assert.AreNotEqual(categories, null);
        }

        [TestMethod]
        [Timeout(1000)]
        public void ConversationGetterTest()
        {
            ConversationGetterCall();
        }

        public List<Conversation> ConversationGetterCall()
        {
            LocalUser user = Login();
            var status = ConversationGetter.GetStatus.UnknownError;
            bool done = false;

            List<Conversation> conversations = null;
            Dictionary<String, User> users = null;


            var getter = new ConversationGetter(user, (_status, _conversations, _users) => {
                status = _status;
                conversations = _conversations;
                users = _users;
                done = true;

            });
            getter.get(true);
            while (!done) { }
            Assert.AreEqual(status, ConversationGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(conversations, null);
            return conversations;
        }


        [TestMethod]
        [Timeout(1000)]
        public void HelpRequestGetterTest()
        {
            LocalUser user = Login();
            var status = HelpRequestGetter.GetStatus.UnknownError;
            bool done = false;

            List<HelpRequest> helpRequests = null;
            Dictionary<String, User> users = null;


            var getter = new HelpRequestGetter(user, (_status, _helpRequests, _users) => {
                status = _status;
                helpRequests = _helpRequests;
                users = _users;
                done = true;

            });
            getter.get(true);
            while (!done) { }
            Assert.AreEqual(status, HelpRequestGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(helpRequests, null);
        }

        [TestMethod]
        [Timeout(1000)]
        public void MessagesGetterTest()
        {
            LocalUser user = Login();
            var status = MessageGetter.MessageStatus.UnknownError;
            bool done = false;
            List<Message> messages = null;
            List<Conversation> conversations = ConversationGetterCall();

            var getter = new MessageGetter(user, (_status, _messages) => {
                status = _status;
                messages = _messages;
                done = true;

            });
            getter.get(conversations[0], 0, false);
            while (!done) { }
            Assert.AreEqual(status, MessageGetter.MessageStatus.Success);
            Assert.AreNotEqual(messages, null);
        }
        
        [TestMethod]
        [Timeout(1000)]
        public void UserReviewGetterTest()
        {
            LocalUser user = Login();
            var status = UserReviewGetter.GetStatus.UnknownError;
            bool done = false;

            List<UserReview> userReviews = null;
            Dictionary<String, User> users = null;


            var getter = new UserReviewGetter(user, (_status, _userReviews, _users) => {
                status = _status;
                userReviews = _userReviews;
                users = _users;
                done = true;

            });
            getter.get(true, user.Username);
            while (!done) { }
            Assert.AreEqual(status, UserReviewGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(userReviews, null);
        }

        [TestMethod]
        [Timeout(10000)]
        public void HelpRequestManagerFullTest()
        {
            LocalUser user = Login();
            var statusManager = HelpRequestManager.ManagerStatus.UnknownError;
            var statusGetterHelp = HelpRequestGetter.GetStatus.UnknownError;
            var statusGetterCategories = CategoriesGetter.GetStatus.UnknownError;
            bool done = false;
            HelpRequest helpRequest;
            List<HelpRequest> helpRequests = null;
            Dictionary<String, User> users = null;
            List<Category> categories = null;

            var helpRequestManager = new HelpRequestManager(user);
            helpRequestManager.PostHelpRequestResult = (_status, _helpRequest) =>
            {
                statusManager = _status;
                helpRequest = _helpRequest;
                done = true;
            };

            helpRequestManager.RemoveHelpRequestResult = (_status, _helpRequest) =>
            {
                statusManager = _status;
                helpRequest = _helpRequest;
                done = true;
            };

            var getterHelp = new HelpRequestGetter(user, (_status, _helpRequests, _users) => {
                statusGetterHelp = _status;
                helpRequests = _helpRequests;
                users = _users;
                done = true;

            });

            var getterCategories = new CategoriesGetter(user, (_status, _categories) => {
                statusGetterCategories = _status;
                categories = _categories;
                done = true;
            });

            ///Gaunam Kategorijas
            done = false;
            getterCategories.get();
            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoriesGetter.GetStatus.Success);
            Assert.AreNotEqual(categories, null);
            Assert.AreNotEqual(categories.Count, 0);
            ///

            ///Siunčiam helpRequest
            done = false;
            var random = new Random();

            helpRequest = new HelpRequest { Title = random.Next().ToString(), Description = random.Next().ToString(), Category = categories[0].Title };
            helpRequestManager.postHelpRequest(helpRequest);

            while (!done) { }
            Assert.AreEqual(statusManager, HelpRequestManager.ManagerStatus.Success);
            Assert.AreNotEqual(helpRequest, null);
            ///

            ///Gaunam visus helpRequest
            done = false;
            getterHelp.get(true);
            while (!done) { }

            Assert.AreEqual(statusGetterHelp, HelpRequestGetter.GetStatus.Success);
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
            helpRequestManager.removeHelpRequest(helpRequest);

            while (!done) { }
            Assert.AreEqual(statusManager, HelpRequestManager.ManagerStatus.Success);
            Assert.AreNotEqual(helpRequest, null);
            ///


            ///Gaunam visus helpRequest
            done = false;
            getterHelp.get(true);
            while (!done) { }

            Assert.AreEqual(statusGetterHelp, HelpRequestGetter.GetStatus.Success);
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

        [TestMethod]
        [Timeout(10000)]
        public void CategoriesManagerFullTest()
        {
            LocalUser user = Login(username: "test2", password: "pass2");
            var statusManager = CategoryManager.ManagerStatus.UnknownError;
            var statusGetterCategories = CategoriesGetter.GetStatus.UnknownError;
            bool done = false;
            Category category;
            List<Category> categories = null;
            var categoriesManager = new CategoryManager(user);

            categoriesManager.AddCategoryResult = (_status, _category) =>
            {
                statusManager = _status;
                category = _category;
                done = true;
            };

            categoriesManager.RemoveCategoryResult = (_status, _category) =>
            {
                statusManager = _status;
                category = _category;
                done = true;
            };

            categoriesManager.UpdateCategoryResult = (_status, _category) =>
            {
                statusManager = _status;
                category = _category;
                done = true;
            };

            var getterCategories = new CategoriesGetter(user, (_status, _categories) => {
                statusGetterCategories = _status;
                categories = _categories;
                done = true;
            });

            ///Siunčiam category
            done = false;
            var random = new Random();

            category = new Category { Title = random.Next().ToString(), Description = random.Next().ToString()};
            categoriesManager.addCategory(category);

            while (!done) { }
            Assert.AreEqual(statusManager, CategoryManager.ManagerStatus.Success);
            Assert.AreNotEqual(category, null);
            ///

            ///Gaunam categories
            done = false;
            getterCategories.get();

            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoriesGetter.GetStatus.Success);
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
            categoriesManager.updateCategory(category);

            while (!done) { }
            Assert.AreEqual(statusManager, CategoryManager.ManagerStatus.Success);
            Assert.AreNotEqual(category, null);
            ///

            ///Gaunam categories
            done = false;
            getterCategories.get();

            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoriesGetter.GetStatus.Success);
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
            categoriesManager.removeCategory(category);

            while (!done) { }
            Assert.AreEqual(statusManager, CategoryManager.ManagerStatus.Success);
            Assert.AreNotEqual(category, null);
            ///

            ///Gaunam categories
            done = false;
            getterCategories.get();

            while (!done) { }
            Assert.AreEqual(statusGetterCategories, CategoriesGetter.GetStatus.Success);
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

        [TestMethod]
        [Timeout(10000)]
        public void MessagingFullTest()
        {
            LocalUser user = Login(username: "test1", password: "pass1");
            var statusGetterConversation = ConversationGetter.GetStatus.UnknownError;
            var statusStarter = ConversationStarter.ConversationStatus.UnknownError;
            var statusPoster = MessagePoster.MessageStatus.UnknownError;
            var statusGetterMessages = MessageGetter.MessageStatus.UnknownError;
            bool done = false;
            Conversation conversation = null;
            string message = null;
            List<Message> messages = null;
            List<Conversation> conversations = null;
            Dictionary<String, User> users = null;


            var getterConv = new ConversationGetter(user, (_status, _conversations, _users) => {
                statusGetterConversation = _status;
                conversations = _conversations;
                users = _users;
                done = true;
                
            });

            var conversationStarter = new ConversationStarter(user, (_status, _conversation, _users) =>
            {
                statusStarter = _status;
                conversation = _conversation;
                users = _users;
                done = true;
            });

            var messagePoster = new MessagePoster(user, (_status, _conversation, _message) =>
            {
                statusPoster = _status;
                conversation = _conversation;
                message = _message;
                done = true;
            });

            var messageGetter = new MessageGetter(user, (_status, _messages) =>
            {
                statusGetterMessages = _status;
                messages = _messages;
                done = true;
            });
            
            ///Pradedam Conversation
            done = false;
            conversationStarter.start("test4");

            while (!done) { }
            Assert.AreEqual(statusStarter, ConversationStarter.ConversationStatus.Success);
            Assert.AreNotEqual(conversation, null);
            ///

            ///Gaunam messages
            done = false;
            messageGetter.get(conversation, 0, false);

            while (!done) { }
            Assert.AreEqual(statusGetterMessages, MessageGetter.MessageStatus.Success);
            Assert.AreNotEqual(messages, null);
            var timestamp = (messages.Count == 0 ? 0 : messages[messages.Count - 1].Timestamp);
            /// 

            ///Siunčiam message
            var random = new Random();
            done = false;
            messagePoster.post(conversation, random.Next().ToString());

            while (!done) { }
            Assert.AreEqual(statusPoster, MessagePoster.MessageStatus.Success);
            Assert.AreNotEqual(message, null);
            ///

            ///Gaunam messages
            done = false;
            messageGetter.get(conversation, timestamp, false);

            while (!done) { }
            Assert.AreEqual(statusGetterMessages, MessageGetter.MessageStatus.Success);
            Assert.AreNotEqual(messages, null);
            ///Tikrinam ar nusisiuntė
            var myMessage = messages.Find((_message) =>
            {
                return _message.Text == message &&
                    _message.Username == user.Username;
            });
            Assert.AreNotEqual(myMessage, null);
            /// 

            ///Gaunam conversations
            done = false;
            getterConv.get(true);
            while (!done) { }

            Assert.AreEqual(statusGetterConversation, ConversationGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(conversations, null);

            var myConversation = conversations.Find((_conversation) =>
            {
                return _conversation.Id == conversation.Id;
            });
            Assert.AreNotEqual(myConversation, null);
            ///
        }

        [TestMethod]
        [Timeout(10000)]
        public void ProfileUpdaterTest()
        {
            LocalUser user = Login(username: "test4", password: "pass4");
            var statusUpdater = UserUpdater.GetStatus.UnknownError;
            var statusGetter = UserGetter.GetStatus.UnknownError;
            bool done = false;
            User user1 = null;
            string firstName = "";
            string lastName = "";
            var random = new Random();

            var updater = new UserUpdater(user, (_status, _firstName, _lastName) =>
            {
                statusUpdater = _status;
                firstName = _firstName;
                lastName = _lastName;
                done = true;
            });

            var getter = new UserGetter(user, (_status, _user) => {
                statusGetter = _status;
                user1 = _user;
                done = true;
            });

            firstName = random.Next().ToString();
            lastName = random.Next().ToString();

            done = false;
            updater.get(firstName, lastName);

            while (!done) { }
            Assert.AreEqual(statusUpdater, UserUpdater.GetStatus.Success);
            Assert.AreNotEqual(firstName, null);
            Assert.AreNotEqual(lastName, null);

            done = false;
            getter.get(user.Username);

            while (!done) { }
            Assert.AreEqual(statusGetter, UserGetter.GetStatus.Success);
            Assert.AreEqual(user.Username, user1.Username);
            Assert.AreNotEqual(user.FirstName, user1.FirstName);
            Assert.AreNotEqual(user.LastName, user1.LastName);
            Assert.AreEqual(firstName, user1.FirstName);
            Assert.AreEqual(lastName, user1.LastName);

            done = false;
            updater.get(user.FirstName, user.LastName);

            while (!done) { }
            Assert.AreEqual(statusUpdater, UserUpdater.GetStatus.Success);
            Assert.AreNotEqual(firstName, null);
            Assert.AreNotEqual(lastName, null);

            done = false;
            getter.get(user.Username);

            while (!done) { }
            Assert.AreEqual(statusGetter, UserGetter.GetStatus.Success);
            Assert.AreEqual(user.Username, user1.Username);
            Assert.AreEqual(user.FirstName, user1.FirstName);
            Assert.AreEqual(user.LastName, user1.LastName);
        }
    }
}
