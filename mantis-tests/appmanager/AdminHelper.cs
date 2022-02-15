using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SimpleBrowser.WebDriver;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }


        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
           // IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";

           IList<IWebElement> rows = driver.FindElements(By.CssSelector("table_tr.row-1,table_tr.row-2 "));
            foreach(IWebElement row in rows)
            {
               IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href,@"\d=$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
            return accounts;
        }
        public void DeleteAccount(AccountData account)
        {
            //IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id="+account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

      //  public IWebDriver OpenAppAndLogin()
     //   {
        //    driver.Url = baseURL + "/manage_user_page.php"; 
            //IWebDriver driver = simpleBrowserDriver;
        //    driver.Url = baseUrl + "/login_page.php";
        //    driver.FindElement(By.Name("username")).SendKeys("administarator");
         //  driver.FindElement(By.Name("password")).SendKeys("root");
        //    driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
         //   return driver;
        }
    }

