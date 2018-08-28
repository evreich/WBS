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
using System.IO;
using Microsoft.Expression.Encoder.ScreenCapture;
using WBS.Selenium.Models;


namespace WBS.Selenium.TestScripts
{
    [TestFixture(Description = "1.Создание и редактирование нового пользователя"), Order(2)]/*(TestName = "1.Создание нового пользователя")]*/
    class CreateAndEditSite : TestBase
    {
        public override string Id => "CreateAndEditSite";

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

        [Test(Description = "3. Открыть вкладку \"Ситы\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Ситы");

            PageValidation.CheckPageCaption("/Sits");
        }

        [Test(Description = "4. Создать пользователя"), Order(4)]
        public void CreateNewUser()
        {
            string title = Context.TestSettings.GetValue("title");
            string format = Context.TestSettings.GetValue("format");
            string kusit = Context.TestSettings.GetValue("kusit");
            string technicalExpert = Context.TestSettings.GetValue("technicalExpert");
            string directorOfSit = Context.TestSettings.GetValue("directorOfSit");
            string createrOfBudget = Context.TestSettings.GetValue("createrOfBudget");
            string kyRegion = Context.TestSettings.GetValue("kyRegion");
            string operationDirector = Context.TestSettings.GetValue("operationDirector");

            ListView.ClickElement("Создать");
            CreateSiteDetailView.SetElementValue("Название",title);
            //CreateSiteDetailView.SetElementValue("Формат", format);
            CreateSiteDetailView.SetElementValue("КУ Сита", kusit);
            CreateSiteDetailView.SetElementValue("Технический эксперт", technicalExpert);
            CreateSiteDetailView.SetElementValue("Директор Сита", directorOfSit);
            CreateSiteDetailView.SetElementValue("Создатель", createrOfBudget);
            CreateSiteDetailView.SetElementValue("КУ региональный", kyRegion);
            CreateSiteDetailView.SetElementValue("Операционный директор", operationDirector);

        }
    }
}
