using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };


            app.Login.Login(account);

        }

    }
}