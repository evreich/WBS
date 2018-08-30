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
    [TestFixture(Description = "2.Создание формата сита"), Order(2)]/*(TestName = "1.Создание формата сита")]*/
    class CreatAndEditFormatSite : TestBase
    {
        public override string Id => "CreateAndEditeFormatSite";

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

        [Test(Description = "3. Открыть вкладку \"Формат ситов\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Формат ситов");

            PageValidation.CheckUrl("/Formats");
        }
        [Test(Description = "4. Создать формат ситов"), Order(4)]
        public void CreateFormatSit()
        {
            string title = Context.TestSettings.GetValue("title");
            string profile = Context.TestSettings.GetValue("profile");
            string directorOfFormat = Context.TestSettings.GetValue("directorOfFormat");
            string directorofKYformat = Context.TestSettings.GetValue("directorofKYformat");
            string kyFormatId = Context.TestSettings.GetValue("kyFormatId");
            string typeOfFormat = Context.TestSettings.GetValue("typeOfFormat");
            string e1 = Context.TestSettings.GetValue("e1");
            string e2 = Context.TestSettings.GetValue("e2");
            string e3 = Context.TestSettings.GetValue("e3");

            ListView.ClickElement("Создать");
            CreateSitFormDetailView.SetElementValue("Название", title);
            CreateSitFormDetailView.SetElementValue("Профиль", profile);
            CreateSitFormDetailView.SetElementValue("Директор формата", directorOfFormat);
            CreateSitFormDetailView.SetElementValue("Директор КУ формата", directorofKYformat);
            CreateSitFormDetailView.SetElementValue("Ку Формат", kyFormatId);
            CreateSitFormDetailView.SetElementValue("Тип формата", typeOfFormat);
            CreateSitFormDetailView.SetElementValue("Е1", e1);
            CreateSitFormDetailView.SetElementValue("Е2", e2);
            CreateSitFormDetailView.SetElementValue("Е3", e3);

            CreateSitFormDetailView.ClickElement("Сохранить");
            //проверка
            ListView.CheckTableContains(title);

        }
        [Test(Description = "5.Открыть строку, проверить данные на форме"), Order(5)]
        public void OpenAndCheckFormatSit()
        {
            string title = Context.TestSettings.GetValue("title");
            string profile = Context.TestSettings.GetValue("profile");
            string directorOfFormat = Context.TestSettings.GetValue("directorOfFormat");
            string directorofKYformat = Context.TestSettings.GetValue("directorofKYformat");
            string kyFormatId = Context.TestSettings.GetValue("kyFormatId");
            string typeOfFormat = Context.TestSettings.GetValue("typeOfFormat");
            string e1 = Context.TestSettings.GetValue("e1");
            string e2 = Context.TestSettings.GetValue("e2");
            string e3 = Context.TestSettings.GetValue("e3");
            string userName = Context.TestSettings.GetValue("userName");
            //открытие строки с только что созданным форматом сита
            ListView.ClickRowTable(title);
            //проверяем, что все данные совпадают
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "Название", title);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "Профиль", profile);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "Директор Формата", userName);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "Директор КУ Формата", userName);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "КУ Формат", userName);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "Тип Формата", typeOfFormat);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "E1", e1);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "E2", e2);
            PageValidation.CheckFieldValue(InformationSitFormDetailView, "E3", e3);
        }
        [Test(Description = "6.Редактирование полей"), Order(6)]
        public void EditFieldsSitForm()
        {
            string newtitle = Context.TestSettings.GetValue("newTitle");
            string newprofile = Context.TestSettings.GetValue("newprofile");

            InformationSitFormDetailView.ClickElement("Редактировать");

            //заполняем значениями формы Формат сита
            CreateSitFormDetailView.SetElementValue("Название", newtitle);
            CreateSitFormDetailView.SetElementValue("Профиль", newprofile);
            //сохранить форму
            CreateSitFormDetailView.ClickElement("Сохранить");

            //нажать кнопку ок
            InformationSitFormDetailView.ClickElement("ОК");
        }
        [Test(Description = "7.Удаление строки Формат сита"), Order(7)]
        public void Delete()
        {
            string newTitle = Context.TestSettings.GetValue("newTitle");

            ListView.ClickRowTable(newTitle);
            //проверка
            PageValidation.CheckModalCaption("Информационное окно");

            InformationSitFormDetailView.ClickElement("Удалить");

            //проверка
            ListView.CheckTablenNotContains(newTitle);

        }

    }
    }

