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
                //Assert.AreEqual(status, Authenticator.AuthStatus.UnknownError);
                done = true;
                status = _status;
                //Console.WriteLine("test2");
                user = _user;
            });
            auth.login("test1", "pass1");
            while (!done) { }
            Assert.AreEqual(status, Authenticator.AuthStatus.Success);
            Assert.AreNotEqual(user, null);
            Assert.AreEqual(user.username, "test1");
            return user;
        }

        [TestMethod]
        public void PrivateKey()
        {
            LocalUser user = Login();
            bool done = false;
            LocalUser user1 = null;
            Authenticator.AuthStatus status = Authenticator.AuthStatus.UnknownError;
            
            var auth = new Authenticator((_status, _user) => {
                done = true;
                status = _status;
                user1 = _user;
            });
            auth.login(user.privateKey);
            while (!done) { }
            Assert.AreEqual(status, Authenticator.AuthStatus.Success);
            Assert.AreEqual(user.privateKey, user1.privateKey);
            Assert.AreEqual(user.username, user1.username);
        }

        [TestMethod]
        public void UserGetterTest()
        {
            LocalUser user = Login();
            var status = UserGetter.GetStatus.UnknownError;
            bool done = false;
            User user1 = null;

            var getter = new UserGetter(user, (_status, _user) => {
                done = true;
                status = _status;
                user1 = _user;
            });
            getter.get(user.username);
            while (!done) { }
            Assert.AreEqual(status, UserGetter.GetStatus.Success);
            Assert.AreEqual(user.username, user1.username);
        }
    }
}
