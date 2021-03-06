using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
    public  RegistrationHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistartionForm(account);
            SubmitRegistration();
          //  String url = GetConfirmationUrl(account);
           // FillPasswordForm(url, account);
          //  SubmitPasswordForm();


        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("password_confirm")).SendKeys(account.Password);

        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

      //  private string GetConfirmationUrl(AccountData account)
//{
      //      String message = manager.Mail.GetLastMail(account);
       //     Match match = Regex.Match(message, @"http://\S*");
       //     return match.Value;
      //  }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/mantisbt-2.25.2/login_page.php";
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("#login-box > div > div.toolbar.center > a")).Click(); ;
        }

        private void FillRegistartionForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("#signup-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click(); ;
        }

    }
}
