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

namespace WBS.Selenium
{
    class Login : TestBase
    {
        [Test, Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }
        // Авторизация под Admin
        //[Test, Order(2)]
        //public void AvtorizationOnAdmin()
        //{
        //    //User user = Context.Users.FirstOrDefault(a => a.Name == "Admin");
        //    Login(user);
        //    // Делаем logout
        //    Thread.Sleep(1000);
        //    Logout();
        //    Thread.Sleep(1000);
        //}

        // Авторизация под всеми пользователями
        [Test, Order(2)]
        public void AvtorizationOnAllUsers()
        {
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);
            Thread.Sleep(1000);
            //Context.Users.ForEach(user =>
            //{
            //    Login(user);
            //    // Делаем logout
            //    Thread.Sleep(1000);
            //    Logout();
            //    Thread.Sleep(1000);
            //});
        }

        [Test, Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Заявки на инвестиции");
            Thread.Sleep(10000);

            ListView.ClickElement("Создать");
            Thread.Sleep(10000);
        }
       
       
        }
    }

