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

namespace WBS.Selenium.TestScripts
{
    public class CreateBudgetPlan : TestBase
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
        [Test, Order(4)]
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
        [Test, Order(3)]
        public void CreateYear1()
        {
            string year1 = Context.TestSettings.GetValue("invalidyear");
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            CreateBudgetDetailView.SetElementValue("Год", year1);
            Thread.Sleep(2000);
            PageValidation.CheckError("Год должен быть в диапазоне от 2008 до 2040");
            Thread.Sleep(2000);
            CreateBudgetDetailView.ClickElement("Отмена");
            Thread.Sleep(2000);

        }
    }
}



