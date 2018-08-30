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
using WBS.Selenium.Models;
using WBS.Selenium.Enums;

namespace WBS.Selenium.TestScripts
{
    [TestFixture(Description = "4.Создание заявки на инвестиции"), Order(4)]/*(TestName = "1.Создание заявки")]*/
    public class CreateRequest : TestBase
    {

        public override string Id => "CreateRequest";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();

        }
        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void AvtorizationOnUser()
        {
            //открытие формы редактирования заявки
            User user = Context.Users.GetUserbyName(UserNames.Admin);
            Login(user);

            PageValidation.CheckUrl("/Home");

            NavigationMenu.OpenPage("Заявки на инвестиции");

            PageValidation.CheckUrl("/DAIRequests");

            //ListView.ShowCountsOfElements("Таблица", 10);
        }
        [Test(Description = "3. Заполнить поля на форме создания заявки"), Order(3)]
        public void CreateOnOrder()
        {
            string sit = Context.TestSettings.GetValue("sit");
            string result = Context.TestSettings.GetValue("result");
            string typeInvest = Context.TestSettings.GetValue("typeInvest");
            string provider = Context.TestSettings.GetValue("provider");
            string attachment = Context.TestSettings.GetValue("attachment");

            ListView.ClickElement("Создать");
            CreateRequestDetailView.SetElementValue("Название сита", sit);
            CreateRequestDetailView.SetElementValue("Центр результата", result);
            CreateRequestDetailView.ClickElement("Выбор технической службы");
            CreateRequestDetailView.ClickElement("Поставщик");
            CreateRequestDetailView.ClickAddInTable("Таблица поставщиков");
            SelectProviderDetailView.ClickPlus("Поставщик1");
            CreateRequestDetailView.SetElementValue("Обоснование необходимости инвестиций", typeInvest);
            PageController.ScrollBottom(Context);
            CreateRequestDetailView.SetElementValue("Загрузить файл", attachment);
            CreateRequestDetailView.ClickElement("Сохранить");


            //проверка
            ListView.CheckTableContains("sit1");
        }
    }
}
