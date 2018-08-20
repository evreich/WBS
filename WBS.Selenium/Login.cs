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
            _driver.Navigate().GoToUrl("http://localhost:55443");
            _driver.Manage().Window.Maximize();
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
            Context.Users.ForEach(user =>
            {
                Login(user);
                // Делаем logout
                Thread.Sleep(1000);
                Logout();
                Thread.Sleep(1000);
            });
        }
    }
}
