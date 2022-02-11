using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{

    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager)
           : base(manager)
        {

        }

        public void OpenMenuProject()
        {
            driver.FindElement(By.XPath("//a[@href= '/mantisbt-2.25.2/mantisbt-2.25.2/manage_overview_page.php']")).Click();
            driver.FindElement(By.XPath("//a[@href= '/mantisbt-2.25.2/mantisbt-2.25.2/manage_proj_page.php']")).Click();


        }


    }
}