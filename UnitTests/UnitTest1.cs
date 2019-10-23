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

        public LocalUser Login()
        {
            
            Authenticator.AuthStatus status = Authenticator.AuthStatus.UnknownError;
            Console.WriteLine("test1");
            LocalUser user = null;
            bool done = false;
            var auth = new Authenticator((_status, _user) => {
                done = true;
                status = _status;
                user = _user;
            });
            auth.login("test1", "pass1");
            while (!done) { }
            Assert.AreEqual(status, Authenticator.AuthStatus.Success);
            Assert.AreNotEqual(user, null);
            Assert.AreEqual(user.Username, "test1");
            return user;
        }

        [TestMethod]
        [Timeout(1000)]
        public void PrivateKey()
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
        public void CategoriesGetterTest()
        {
            LocalUser user = Login();
            var status = CategoriesGetter.GetStatus.UnknownError;
            bool done = false;
            List<Category> categories = null;

            var getter = new CategoriesGetter(user, (_status, _categories) => {
                done = true;
                status = _status;
                categories = _categories;
            });
            getter.get();
            while (!done) { }
            Assert.AreEqual(status, CategoriesGetter.GetStatus.Success);
            Assert.AreNotEqual(categories, null);
        }

        [TestMethod]
        public List<Conversation> ConversationGetterTest()
        {
            LocalUser user = Login();
            var status = ConversationGetter.GetStatus.UnknownError;
            bool done = false;

            List<Conversation> conversations = null;
            Dictionary<String, User> users = null;


            var getter = new ConversationGetter(user, (_status, _conversations, _users) => {
                done = true;
                status = _status;
                conversations = _conversations;
                users = _users;
                
            });
            getter.get(true);
            while (!done) { }
            Assert.AreEqual(status, ConversationGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(conversations, null);
            return conversations;
        }


        [TestMethod]
        public void HelpRequestGetterTest()
        {
            LocalUser user = Login();
            var status = HelpRequestGetter.GetStatus.UnknownError;
            bool done = false;

            List<HelpRequest> helpRequests = null;
            Dictionary<String, User> users = null;


            var getter = new HelpRequestGetter(user, (_status, _helpRequests, _users) => {
                done = true;
                status = _status;
                helpRequests = _helpRequests;
                users = _users;

            });
            getter.get(true);
            while (!done) { }
            Assert.AreEqual(status, HelpRequestGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(helpRequests, null);
        }

        [TestMethod]
        public void MessagesGetterTest()
        {
            LocalUser user = Login();
            var status = MessageGetter.MessageStatus.UnknownError;
            bool done = false;
            List<Message> messages = null;
            List<Conversation> conversations = ConversationGetterTest();

            var getter = new MessageGetter(user, (_status, _messages) => {
                done = true;
                status = _status;
                messages = _messages;

            });
            getter.get(conversations[0], 0, false);
            while (!done) { }
            Assert.AreEqual(status, MessageGetter.MessageStatus.Success);
            Assert.AreNotEqual(messages, null);
        }

        [TestMethod]
        public void UserReviewGetterTest()
        {
            LocalUser user = Login();
            var status = UserReviewGetter.GetStatus.UnknownError;
            bool done = false;

            List<UserReview> userReviews = null;
            Dictionary<String, User> users = null;


            var getter = new UserReviewGetter(user, (_status, _userReviews, _users) => {
                done = true;
                status = _status;
                userReviews = _userReviews;
                users = _users;

            });
            getter.get(true, user.username);
            while (!done) { }
            Assert.AreEqual(status, UserReviewGetter.GetStatus.Success);
            Assert.AreNotEqual(users, null);
            Assert.AreNotEqual(userReviews, null);
        }
    }
}
