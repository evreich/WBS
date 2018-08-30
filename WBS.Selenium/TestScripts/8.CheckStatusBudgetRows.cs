using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WBS.Selenium.Controllers;
using WBS.Selenium.Enums;
using WBS.Selenium.Models;

namespace WBS.Selenium.TestScripts
{
    [TestFixture(Description = "8.Проверка полей для бюджетных планов"), Order(8)]
    public class CheckStatusBudgetRows : TestBase
    {
        public override string Id => "CheckStatusBudgetRows";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
        }

        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void AvtorizationOnAllUsers()
        {
            User user = Context.Users.GetUserbyName(UserNames.Admin);
            Login(user);

            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "3. Открыть вкладку \"Бюджетные планы\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckUrl("/BudgetPlans");
        }

        [Test(Description = "4. Создать строку в бюджетном плане"), Order(4)]
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
            string[] parseDate = date.Split('-');
            string newDateFormat = parseDate[2] + "-" + parseDate[0] + "-" + parseDate[1];

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
            Thread.Sleep(2000);
            // Проверка по дате
            ListView.CheckTableContains("Детальный план сита", "Дата поставки", newDateFormat);
            //проверить статус
            //ListView.CheckTableContains("Детальный план сита", "Статус", status);
        }

        [Test(Description = "5. Проверка редактирования полей"), Order(5)]
        public void OpenRow()
        {
            string status = Context.TestSettings.GetValue("status");
            string sit = Context.TestSettings.GetValue("sit");
            string year = Context.TestSettings.GetValue("year");

            ListView.ClickRowTable(year);

            CreateBudgetDetailView.SetElementValue("Название сита", sit);

            ListView.ClickFirstRowTable("Детальный план сита");

            InformationBudgetStringDetailView.ClickElement("Редактировать");
        }
    }
}
