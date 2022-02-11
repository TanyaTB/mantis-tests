using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class LoginTests : TestBase
    {



        [Test]
        public void TestLogin()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            app.Login.Logout();

            app.Login.Login(account);

        }

    }
}