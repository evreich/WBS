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
using WBS.Selenium.Enums;

namespace WBS.Selenium.TestScripts
{
    [TestFixture(Description = "3.Создание и редактирование Сита"), Order(3)]/*(TestName = "1.Создание нового пользователя")]*/
    class CreateAndEditSite : TestBase
    {
        //Id ссылается на Config\\Tests\\CreateAndEditSite.xml файл (имя файла=имя класса)
        //необходимо, чтобы получать данные из CreateAndEditSite.xml через TestSettings 
        public override string Id => "CreateAndEditSite";

        [Test(Description = "1. Открыть браузер"), Order(1)]
        public void OpenaBrowser()
        {
            //перейти по url
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            //развернуть браузер 
            Context.Driver.Manage().Window.Maximize();
        }

        [Test(Description = "2. Зарегистрироваться в системе"), Order(2)]
        public void AvtorizationOnAllUsers()
        {
            //получить пользователя по имени из контекста
            User user = Context.Users.GetUserbyName(UserNames.Admin);
            //залогиниться под пользователем user
            Login(user);
            //проверить часть url
            PageValidation.CheckUrl("/Home");
        }

        [Test(Description = "3. Открыть вкладку \"Ситы\""), Order(3)]
        public void OpenNavigation()
        {
            //открыть вкладку Ситы
            NavigationMenu.OpenPage("Ситы");
            //проверить часть url
            PageValidation.CheckUrl("/Sits");
        }

        [Test(Description = "4. Создать пользователя"), Order(4)]
        public void CreateNewUser()
        {
            //получить данные из CreateAndEditSite.xml
            string title = Context.TestSettings.GetValue("title");
            string format = Context.TestSettings.GetValue("format");
            string kusit = Context.TestSettings.GetValue("kusit");
            string technicalExpert = Context.TestSettings.GetValue("technicalExpert");
            string directorOfSit = Context.TestSettings.GetValue("directorOfSit");
            string createrOfBudget = Context.TestSettings.GetValue("createrOfBudget");
            string kyRegion = Context.TestSettings.GetValue("kyRegion");
            string operationDirector = Context.TestSettings.GetValue("operationDirector");
            string userName = Context.TestSettings.GetValue("userName");

            //нажимает на объект из Maps, у которого Field равен Создать
            ListView.ClickElement("Создать");

            //проверка заголовка модального окна
            PageValidation.CheckModalCaption("Создание");

            //заполнение полей 
            CreateSiteDetailView.SetElementValue("Название", title);
            CreateSiteDetailView.SetElementValue("Формат", format);
            CreateSiteDetailView.SetElementValue("КУ Сита", kusit);
            CreateSiteDetailView.SetElementValue("Технический эксперт", technicalExpert);
            CreateSiteDetailView.SetElementValue("Директор Сита", directorOfSit);
            CreateSiteDetailView.SetElementValue("Создатель", createrOfBudget);
            CreateSiteDetailView.SetElementValue("КУ региональный", kyRegion);
            CreateSiteDetailView.SetElementValue("Операционный директор", operationDirector);

            //нажимает на объект из Maps, у которого Field равен Сохранить
            CreateSiteDetailView.ClickElement("Сохранить");

            //проверка
            ListView.CheckTableContains(title);
            ListView.CheckTableContains(format);
            ListView.CheckTableContains(userName);
        }

        [Test(Description = "5.Проверка полей"), Order(5)]
        public void OpenEditAndCekFields()
        {
            string title = Context.TestSettings.GetValue("title");
            string format = Context.TestSettings.GetValue("format");
            string kusit = Context.TestSettings.GetValue("kusit");
            string technicalExpert = Context.TestSettings.GetValue("technicalExpert");
            string directorOfSit = Context.TestSettings.GetValue("directorOfSit");
            string createrOfBudget = Context.TestSettings.GetValue("createrOfBudget");
            string kyRegion = Context.TestSettings.GetValue("kyRegion");
            string operationDirector = Context.TestSettings.GetValue("operationDirector");
            string userName = Context.TestSettings.GetValue("userName");

            ListView.ClickRowTable(title);
            //проверка
            PageValidation.CheckModalCaption("Информационное окно");

            //проверка
            PageValidation.CheckFieldValue(InformationSiteDetailView, "Название", title);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "Формат", format);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "КУ Сита", userName);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "Технический эксперт", userName);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "Директор Сита", userName);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "Создатель", userName);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "КУ региональный", userName);
            PageValidation.CheckFieldValue(InformationSiteDetailView, "Операционный директор", userName);
        }

        [Test(Description = "6.Редактирование полей"), Order(6)]
        public void EditFields()
        {
            string kusit = Context.TestSettings.GetValue("kusit");
            string newTitle = Context.TestSettings.GetValue("newTitle");
            string userName = Context.TestSettings.GetValue("userName");

            InformationSiteDetailView.ClickElement("Редактировать");

            //проверка
            //PageValidation.CheckModalCaption("Редактирование");
            PageValidation.CheckFieldValue(CreateSiteDetailView, "КУ Сита", userName);


            CreateSiteDetailView.SetElementValue("Название", newTitle);
            //CreateSiteDetailView.SetElementValue("Должность", jobPosition);
            //CreateSiteDetailView.SetElementValue("Подразделение", department);

            CreateSiteDetailView.ClickElement("Сохранить");

            InformationSiteDetailView.ClickElement("ОК");
            //проверка
            ListView.CheckTableContains(newTitle);
        }

        [Test(Description = "7.Удаление"), Order(7)]
        public void Delete()
        {
            string newTitle = Context.TestSettings.GetValue("newTitle");

            ListView.ClickRowTable(newTitle);
            //проверка
            PageValidation.CheckModalCaption("Информационное окно");

            InformationBudgetStringDetailView.ClickElement("Удалить");

            //проверка
            ListView.CheckTablenNotContains(newTitle);

        }
    }
}
