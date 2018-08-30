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
    [TestFixture(Description = "7.Проверка полей для бюджетных планов"), Order(7)]
    public  class CheckRolesInBudgetPlan : TestBase
    {
        public override string Id => "CheckRolesInBudgetPlan";

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

        [Test(Description = "3. Открыть вкладку \"Бюджетные планы\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckUrl("/BudgetPlans");
        }

        [Test(Description = "4. Зарегистрироваться в системе"), Order(4)]
        public void AvtorizationAsAccountant()
        {
            string login = Context.TestSettings.GetValue("accountant");
            string password =Context.TestSettings.GetValue("password");
            Thread.Sleep(2000);
            Logout();

            Login(login, password);

            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "5. Открыть вкладку \"Бюджетные планы\""), Order(5)]
        public void OpenNavigation2()
        {
            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckUrl("/BudgetPlans");
        }

        [Test(Description = "6. Зарегистрироваться в системе"), Order(6)]
        public void AvtorizationAsUser()
        {
            string login = Context.TestSettings.GetValue("user");
            string password = Context.TestSettings.GetValue("password");
            Thread.Sleep(2000);
            Logout();

            Login(login,password);

            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "7. Открыть вкладку \"Бюджетные планы\""), Order(7)]
        public void OpenNavigation3()
        {
            //TODO: ожидается другой Exception
            Assert.Throws(typeof(Exception), () => { NavigationMenu.OpenPage("Бюджетные планы"); },
                "Ожидалось, что пользователю будет не доступна вкладка \"Бюджетные планы\"");
            
            PageValidation.CheckUrl("/Home");
        }
    }
}
