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

    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager)
           : base(manager)
        {

        }
        public void Create(ProjectData project)
        {
            manager.MenuManager.OpenMenuProject();

            StartProjectCreation();
            FillProjectData(project);
            SubmitProjectCreation();
        }

        public void StartProjectCreation()
        {
            driver.FindElement(By.CssSelector("form[action=\"manage_proj_create_page.php\"]")).Click();
           

        }


        public void FillProjectData(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);


        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value = 'Add Project']")).Click();

            projectCache = null;
        }



        public void Remove()
        {
            manager.MenuManager.OpenMenuProject();
            OpenProject();
            StartProjectRemoval();
            SubmitProjectRemoval();
        }

        public void OpenProject()
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a")).Click();

        }

        public void StartProjectRemoval()
        {
            driver.FindElement(By.CssSelector("form[action=\"manage_proj_delete.php\"]")).Click();

        }

        public void SubmitProjectRemoval()
        {
            driver.FindElement(By.XPath("//input[@value = 'Delete Project']")).Click();
            projectCache = null;
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
                foreach (IWebElement element in elements)
                {


                    projectCache.Add(new ProjectData()
                    {
                        Name = element.Text

                    });

                }


                //                  string name = projectCache[0].Name;
            }


            return new List<ProjectData>(projectCache);

        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a")).Count;


        }


    }
}