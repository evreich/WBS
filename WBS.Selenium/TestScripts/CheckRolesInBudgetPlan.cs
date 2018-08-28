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
   public  class CheckRolesInBudgetPlan : TestBase
    {
        public override string Id => "CheckRolesInBudgetPlan";

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
            string login = Context.TestSettings.GetValue("admin");
            string password = Context.TestSettings.GetValue("password");
            User user = new User() { Login = login, Password = password };
            Login(user);
            Thread.Sleep(1000);
        }

        [Test(Description = "3. Открыть вкладку \"Бюджетные планы\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Бюджетные планы");

            PageValidation.CheckUrl("/BudgetPlans");
        }

        [Test(Description = "4. Зарегистрироваться в системе"), Order(4)]
        public void ChangeUser()
        {
            string login = Context.TestSettings.GetValue("admin");
            string password = Context.TestSettings.GetValue("password");

            Logout();
            User user = new User() { Login = login, Password = password };
            Login(user);

            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "5. Открыть вкладку \"Бюджетные планы\""), Order(5)]
        public void OpenNavigation2()
        {
            //TODO: ожидается другой Exception
            Assert.Throws(typeof(Exception), () => { NavigationMenu.OpenPage("Бюджетные планы"); });
            
            PageValidation.CheckUrl("/Home");
        }
    }
}
