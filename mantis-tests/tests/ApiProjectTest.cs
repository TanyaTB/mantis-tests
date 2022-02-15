using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace mantis_tests
{

    [TestFixture]
    public class ApiProjectTests : AuthBase
    {
        
        [Test]

        public void TestProjectCreationAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.API.CreateNewProject(account, project);

        }

        [Test]
        public void TestProjectRemovalAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            int projectsCount = app.API.GetProjectsList(account).Length;


            if (projectsCount == 0)
            {
                app.API.CreateNewProject(account, project);
            }

            
            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Remove();

            Thread.Sleep(5000);

            List<ProjectData> newProjects = app.Project.GetProjectList();

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);
        


        }

        [Test]

        public void GetListAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            Mantis.ProjectData[] projects = app.API.GetProjectsList(account);

            foreach (Mantis.ProjectData project in projects)
                Console.Out.WriteLine(project.name);

        }

        [Test]

        public void GetList()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.Login.Logout();
            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();
            app.Project.GetProjectList();
            app.Project.GetProjectCount();


        }










    }
}
