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
using WBS.Selenium.Controllers;

namespace WBS.Selenium.TestScripts
{
    [TestFixture(TestName = "1.Создание нового пользователя")]
    [Description("1.Создание нового пользователя")]
    public class CreateUser:TestBase
    {
        public override string Id => "CreateUser";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }

        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void AvtorizationOnAllUsers()
        {
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);
            Thread.Sleep(1000);
        }

        [Test(Description = "3. Открыть вкладку \"Пользователи\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Пользователи");

            PageValidation.CheckPageCaption("/Profiles");            
        }

        [Test(Description = "4. Создать пользователя"), Order(4)]
        public void CreateNewUser()
        {
            string fio = Context.TestSettings.GetValue("fio");
            string login = Context.TestSettings.GetValue("login");
            string jobPosition = Context.TestSettings.GetValue("jobPosition");
            string department = Context.TestSettings.GetValue("department");
            string password = Context.TestSettings.GetValue("password");
            string roles = Context.TestSettings.GetValue("roles");

            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            CreateUserDetailView.SetElementValue("ФИО", fio);
            CreateUserDetailView.SetElementValue("Логин", login);
            CreateUserDetailView.SetElementValue("Должность", jobPosition);
            CreateUserDetailView.SetElementValue("Подразделение", department);
            CreateUserDetailView.SetListValues("Полномочия", roles);
            CreateUserDetailView.SetElementValue("Пароль", password);

            Thread.Sleep(2000);
            CreateUserDetailView.ClickElement("Сохранить");

            //проверка
            ListView.CheckTableContains(fio);
        }
    }
}
