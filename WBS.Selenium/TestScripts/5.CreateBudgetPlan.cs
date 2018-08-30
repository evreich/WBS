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
    [TestFixture(Description = "5.Создание бюджетных плана"), Order(5)]/*(TestName = "1.Создание бюджетной строки")]*/
    public class CreateBudgetPlan : TestBase
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
            //открытие формы бюджетные планы
            User user = Context.Users.GetUserbyName(UserNames.Admin);
            Login(user);

            PageValidation.CheckUrl("/Home");

            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckUrl("/BudgetPlans");
        }

        [Test(Description = "3. Создать бюджетный план с некорректным годом"), Order(3)]
        public void CreateYear1()
        {
            string year1 = Context.TestSettings.GetValue("invalidyear");
            ListView.ClickElement("Создать");

            CreateBudgetDetailView.SetElementValue("Год", year1);

            PageValidation.CheckError("Год должен быть в диапазоне от 2008 до 2040");

            CreateBudgetDetailView.ClickElement("Отмена");
        }
        //создать бюджетный план с годом, входящим в диапазон
        [Test(Description = "4. Создать бюджетный план"), Order(4)]
        public void CreateYear()
        {
            string year = Context.TestSettings.GetValue("year");

            ListView.ClickElement("Создать");

            CreateBudgetDetailView.SetElementValue("Год", year);
            CreateBudgetDetailView.ClickElement("Сохранить");

            //проверка на наличие бюджетного плана в списке бюджетных планов
            ListView.CheckTableContains(year);
        }

        
    }
}



