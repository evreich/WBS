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
    [TestFixture(Description = "6.Создание бюджетных строк в бюджетном блане"), Order(6)]
    public class CreateBudgetRow : TestBase
    {
        public override string Id => "CreateBudgetPlan";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
        }
        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void AvtorizationOnUser()
        {
            //открытие формы ,бюджетные планы
            User user = Context.Users.GetUserbyName(UserNames.Admin);
            Login(user);

            PageValidation.CheckUrl("/Home");

            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckUrl("/BudgetPlans");
        }
        //создать бюджетный план с годом, входящим в диапазон
        [Test(Description = "3. Создать бюджетный план, выбрать год для бюджетного плана."), Order(3)]
        public void CreateYear()
        {
            string year = Context.TestSettings.GetValue("year");

            ListView.ClickElement("Создать");

            CreateBudgetDetailView.SetElementValue("Год", year);

            CreateBudgetDetailView.ClickElement("Сохранить");

            //проверка на наличие бюджетного плана в списке бюджетных планов
            ListView.CheckTableContains(year);
        }
        [Test(Description = "4. Создать строку в бюджетном плане."), Order(4)]
        public void CreatingBudgetRows()
        {
            string sit = Context.TestSettings.GetValue("sit");
            string price = Context.TestSettings.GetValue("price");
            string result = Context.TestSettings.GetValue("result");
            string typeinvest = Context.TestSettings.GetValue("typeinvest");
            string category = Context.TestSettings.GetValue("category");
            string objectinvest = Context.TestSettings.GetValue("objectinvest");
            string quantity = Context.TestSettings.GetValue("quantity");
            string date = Context.TestSettings.GetValue("date");
            string year = Context.TestSettings.GetValue("year");

            ListView.ClickRowTable(year);
            CreateBudgetDetailView.SetElementValue("Название сита", sit);
            PageController.ScrollToElementById(Context, "DetalizationOfSite");
            CreateBudgetDetailView.ClickElement("Создать");
            CreateBudgetDetailView.SetElementValue("Центр результата", result);
            CreateBudgetDetailView.SetElementValue("Тип инвестиций", typeinvest);
            CreateBudgetDetailView.SetElementValue("Категория", category);
            CreateBudgetDetailView.SetElementValue("Предмет инвестиций", objectinvest);
            CreateBudgetDetailView.SetElementValue("Дата поставки", date);
            CreateBudgetDetailView.SetElementValue("Количество", quantity);
            CreateBudgetDetailView.SetElementValue("Цена", price);

            CreateBudgetDetailView.ClickElement("Сохранить");

            // Проверка по дате
            ListView.CheckTableContainsByName(date, "Детальный план сита");
        }

        [Test(Description = "5. Открыть окно просмотра и редактирования"), Order(5)]
        public void OpenEditStringOfPlan()
        {
            string sit = Context.TestSettings.GetValue("sit");
            string price = Context.TestSettings.GetValue("price");
            string result = Context.TestSettings.GetValue("result");
            string typeinvest = Context.TestSettings.GetValue("typeinvest");
            string category = Context.TestSettings.GetValue("category");
            string objectinvest = Context.TestSettings.GetValue("objectinvest");
            string quantity = Context.TestSettings.GetValue("quantity");
            string date = Context.TestSettings.GetValue("date");
            int newSum = Convert.ToInt32(quantity) * Convert.ToInt32(price);

            ListView.ClickRowTable(date);

            //проверка
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Центр результата", result);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Тип инвестиций", typeinvest);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Категория", category);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Предмет инвестиций", objectinvest);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Дата поставки", date);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Количество", quantity);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Цена", price);
            PageValidation.CheckFieldValue(InformationBudgetStringDetailView, "Сумма", newSum.ToString());

            InformationBudgetStringDetailView.ClickElement("Редактировать");
        }

        [Test(Description = "6. Редактирование полей"), Order(6)]
        public void EditFields()
        {
            string objectinvest = Context.TestSettings.GetValue("newObjectinvest");
            string quantity = Context.TestSettings.GetValue("newQuantity");
            string date = Context.TestSettings.GetValue("newDate");
            string price = Context.TestSettings.GetValue("price");
            int newSum = Convert.ToInt32(quantity) * Convert.ToInt32(price);

            CreateBudgetDetailView.SetElementValue("Предмет инвестиций", objectinvest);
            CreateBudgetDetailView.SetElementValue("Дата поставки", date);
            CreateBudgetDetailView.SetElementValue("Количество", quantity);
            CreateBudgetDetailView.ClickElement("Сохранить");
            InformationBudgetStringDetailView.ClickElement("ОК");
            //проверки
            ListView.CheckTableContains(objectinvest);
            ListView.CheckTableContains(quantity);
            ListView.CheckTableContains(date);
            ListView.CheckTableContains(newSum.ToString());
        }

        [Test(Description = "7.Удаление"), Order(7)]
        public void Delete()
        {
            string date = Context.TestSettings.GetValue("newDate");

            ListView.ClickRowTable(date);

            InformationBudgetStringDetailView.ClickElement("Удалить");

            //проверка
            ListView.CheckTablenNotContains(date);
        }
    }
}


