using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WBS.Selenium.Controllers;

namespace WBS.Selenium.TestScripts
{
    class CreateUser:TestBase
    {
        [Test, Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }

        [Test, Order(2)]
        public void AvtorizationOnAllUsers()
        {
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);
            Thread.Sleep(1000);
        }

        [Test, Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Пользователи");

            PageValidation.CheckPageCaption("/Profiles");            
        }

        [Test, Order(4)]
        public void CreateNewUser()
        {
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);

            Thread.Sleep(10000);
        }
    }
}
