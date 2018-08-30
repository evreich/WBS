using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using NUnit.Framework;
using System.Threading;

namespace WBS.Selenium.TestScripts
{
    [TestFixture(Description = "7.Проверка полей для сита"), Order(7)]
    public class CheckRolesInSit : TestBase
    {
        public override string Id => "CheckRolesInSit";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
        }

        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void Avtorization()
        {
            string login = Context.TestSettings.GetValue("admin");
            string password = Context.TestSettings.GetValue("password");

            Login(login, password);

            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "3. Открыть вкладку Ситы"), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Ситы");

            PageValidation.CheckUrl("/Sits");


            ListView.ClickFirstRowTable();
            

            //InformationSitFormDetailView.GetElementValue("Редактировать");
            //Assert.Throws(typeof(Exception), () => { InformationSitFormDetailView.ClickElement("Редактировать"); },
            //    "Ожидалось, что пользователю будет доступна кнопка \"Редактировать\"");
            //Assert.True(InformationSitFormDetailView.CheckElementIsVisible("Редактировать"), "Ожидалось, что на форме {0} отображается кнопка {1}");
        }

        //Проверка кнопки редактирования под инициатором.
        [Test(Description = "4. Открыть браузер"), Order(4)]
        public void OpenaBrowserUnderIntiator()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
        }

        [Test(Description = "5. Зарегистрироваться в системе"), Order(5)]
        public void AvtorizationUnderIntiator()
        {
            string login = Context.TestSettings.GetValue("user");
            string password = Context.TestSettings.GetValue("passwordFrromUser");
            Logout();

            Login(login, password);

            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "6. Открыть вкладку Ситы"), Order(6)]
        public void OpenNavigationUnderIntiator()
        {
            NavigationMenu.OpenPage("Ситы");

            PageValidation.CheckUrl("/Sits");


            ListView.ClickFirstRowTable();

            InformationSitFormDetailView.GetElementValue("Редактировать");
            Assert.Throws(typeof(Exception), () => { InformationSitFormDetailView.ClickElement("Редактировать"); },
                "Ожидалось, что пользователю будет недоступна кнопка редактировать \"Редактировать\"");
        }
    }
}