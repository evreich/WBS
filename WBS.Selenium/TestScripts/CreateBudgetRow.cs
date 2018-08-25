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

namespace WBS.Selenium.TestScripts
{
    public class CreateBudgetRow : TestBase
    {
        public override string Id => "CreateBudgetPlan";

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
            //открытие формы ,бюджетные планы
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);

            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckPageCaption("/BudgetPlans");
        }
        //создать бюджетный план с годом, входящим в диапазон
        [Test, Order(3)]
        public void CreateYear()
        {
            string year = Context.TestSettings.GetValue("year");
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            CreateBudgetDetailView.SetElementValue("Год", year);
            Thread.Sleep(5000);
            CreateBudgetDetailView.ClickElement("Сохранить");
            Thread.Sleep(5000);
            //проверка на наличие бюджетного плана в списке бюджетных планов
            ListView.CheckTableContains(year);
        }
        [Test, Order(4)]
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


            CreateBudgetDetailView.ClickElement("Ссылка год");
            Thread.Sleep(1000);
            CreateBudgetDetailView.SetElementValue("Название сита", sit);
            Thread.Sleep(1000);
            PageController.ScrollToElementById(Context, "DetalizationOfSite");
            Thread.Sleep(1000);
            CreateBudgetDetailView.ClickElement("Создать");
            Thread.Sleep(1000);
            CreateBudgetDetailView.SetElementValue("Центр результата", result);
            Thread.Sleep(500);
            CreateBudgetDetailView.SetElementValue("Тип инвестиций", typeinvest);
            Thread.Sleep(500);
            CreateBudgetDetailView.SetElementValue("Категория", category);
            Thread.Sleep(500);
            CreateBudgetDetailView.SetElementValue("Предмет инвестиций", objectinvest);
            Thread.Sleep(500);
            // Не работает проставление значения через js
            CreateBudgetDetailView.SetDate(Context, "Дата поставки", date);
            Thread.Sleep(500);
            CreateBudgetDetailView.SetElementValue("Количество", quantity);
            Thread.Sleep(500);
            CreateBudgetDetailView.SetElementValue("Цена", price);
            Thread.Sleep(500);
            CreateBudgetDetailView.ClickElement("Сохранить");
            Thread.Sleep(3000);

            // Проверка по дате
            ListView.CheckTableContainsByName(date, "Детальный план сита");
        }
    }
}


