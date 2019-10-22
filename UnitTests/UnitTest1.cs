using System;
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
    }
}
