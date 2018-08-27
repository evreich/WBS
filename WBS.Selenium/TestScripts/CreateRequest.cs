﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;
using WBS.Selenium.Controllers;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;

namespace WBS.Selenium
{
    [TestFixture(Description = "1.Создание заявки на инвестиции"), Order(2)]/*(TestName = "1.Создание заявки")]*/
    class CreateRequest : TestBase
    {

        public override string Id => "CreateRequest";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }
        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void AvtorizationOnUser()
        {
            //открытие формы редактирования заявки
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);

            NavigationMenu.OpenPage("Заявки на инвестиции");

            PageValidation.CheckPageCaption("/DAIRequests");
        }
        [Test(Description = "3. Заполнить поля на форме создания заявки"), Order(3)]
        public void CreateOnOrder()
        {
            string sit = Context.TestSettings.GetValue("sit");
            string result = Context.TestSettings.GetValue("result");
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            CreateRequestDetailView.SetElementValue("Название сита", sit);
            Thread.Sleep(2000);
            CreateRequestDetailView.SetElementValue("Центр результата", result);
            CreateRequestDetailView.ClickElement("Выбор технической службы");
            CreateRequestDetailView.ClickElement("Поставщик");
            PageController.ScrollBottom(Context);
            Thread.Sleep(2000);
            CreateRequestDetailView.ClickElement("Сохранить");

            //проверка
            ListView.CheckTableContains("sit1");
        }
    }
}
