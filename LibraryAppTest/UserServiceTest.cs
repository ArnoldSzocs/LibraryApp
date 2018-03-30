using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp;
using System.Collections.Generic;

namespace LibraryAppTest
{
    [TestClass]
    public class UserServiceTest
    {
        IUserService service;

        [TestInitialize]
        public void Setup()
        {
           service = new UserService();
           List<UserDto> users = new List<UserDto>
            {
                new UserDto("Name", "Pwd"),
                new UserDto("Name", "Pwd"),
                new UserDto("Name", "Pwd")
            };
            //service.Save(users, new List<UserDto>(), new List<UserDto>());
        }



        [TestMethod]
        public void TestLoad()
        {
            List<UserDto> users = service.Load();
            Assert.AreEqual(7, users.Count);
        }
    }
}
