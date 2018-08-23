using NUnit.Framework;
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

namespace WBS.Selenium
{
    class CreateRequest : TestBase
    {
        [Test, Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }
        [Test, Order(2)]
        public void AvtorizationOnUser()
        {
            //открытие формы редактирования заявки
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);

            NavigationMenu.OpenPage("Заявки на инвестиции");

            PageValidation.CheckPageCaption("/DAIRequests");
        }
        [Test, Order(3)]
        public void CreateOnOrder()
        {
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            CreateRequestDetailView.SetElementValue("Название сита", "sit1");
            Thread.Sleep(2000);
            CreateRequestDetailView.SetElementValue("Центр результата", "ggnbvc");
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
