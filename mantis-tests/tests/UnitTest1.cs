using NUnit.Framework;
using System;

namespace mantis_tests.tests
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
       
        public void TestMethod1()
        {
            AccountData account = new AccountData()
            {
                Name = "xxxx",
                Password = "yyy"
            };
           Assert.IsFalse(app.James.Verify(account));
            app.James.Add(account);
            Assert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            Assert.IsFalse(app.James.Verify(account));
        }
    }
}
