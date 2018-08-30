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
using System.IO;
using Microsoft.Expression.Encoder.ScreenCapture;
using WBS.Selenium.Models;
using WBS.Selenium.Enums;

namespace WBS.Selenium.TestScripts
{

    [TestFixture(Description = "1.Создание и редактирование нового пользователя"), Order(1)]/*(TestName = "1.Создание нового пользователя")]*/
    public class CreateAndEditUser : TestBase
    {
        public override string Id => "CreateAndEditUser";

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

        [Test(Description = "3. Открыть вкладку \"Пользователи\""), Order(3)]
        public void OpenNavigation()
        {
            NavigationMenu.OpenPage("Пользователи");

            PageValidation.CheckUrl("/Profiles");
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

            //проверка
            PageValidation.CheckModalCaption("Создание");

            CreateUserDetailView.SetElementValue("ФИО", fio);
            CreateUserDetailView.SetElementValue("Логин", login);
            CreateUserDetailView.SetElementValue("Должность", jobPosition);
            CreateUserDetailView.SetElementValue("Подразделение", department);
            CreateUserDetailView.SetListValues("Полномочия", roles);
            CreateUserDetailView.SetElementValue("Пароль", password);

            CreateUserDetailView.ClickElement("Сохранить");

            //проверка
            ListView.CheckTableContains(fio);
        }

        [Test(Description = "5.Проверка полей"), Order(5)]
        public void OpenEditAndCekFields()
        {
            string fio = Context.TestSettings.GetValue("fio");
            string jobPosition = Context.TestSettings.GetValue("jobPosition");
            string department = Context.TestSettings.GetValue("department");
            string roles = Context.TestSettings.GetValue("roles");

            ListView.ClickRowTable(fio);

            //проверка
            PageValidation.CheckFieldValue(InformationUserDetailView, "ФИО", fio);
            PageValidation.CheckFieldValue(InformationUserDetailView, "Должность", jobPosition);
            PageValidation.CheckFieldValue(InformationUserDetailView, "Подразделение", department);
        }

        [Test(Description = "6.Редактирование полей"), Order(6)]
        public void EditFields()
        {
            string fio = Context.TestSettings.GetValue("newFio");
            string jobPosition = Context.TestSettings.GetValue("newJobPosition");
            string department = Context.TestSettings.GetValue("newDepartment");

            InformationUserDetailView.ClickElement("Редактировать");
            //проверка
            PageValidation.CheckModalCaption("Редактирование");

            CreateUserDetailView.SetElementValue("ФИО", fio);
            CreateUserDetailView.SetElementValue("Должность", jobPosition);
            CreateUserDetailView.SetElementValue("Подразделение", department);

            CreateUserDetailView.ClickElement("Сохранить");

            InformationUserDetailView.ClickElement("ОК");
            //проверка
            ListView.CheckTableContains(fio);
        }

        [Test(Description = "7.Проверка полей"), Order(7)]
        public void CheckNewFields()
        {
            string fio = Context.TestSettings.GetValue("newFio");
            string jobPosition = Context.TestSettings.GetValue("newJobPosition");
            string department = Context.TestSettings.GetValue("newDepartment");

            ListView.ClickRowTable(fio);

            //проверка
            PageValidation.CheckFieldValue(InformationUserDetailView, "ФИО", fio);
            PageValidation.CheckFieldValue(InformationUserDetailView, "Должность", jobPosition);
            PageValidation.CheckFieldValue(InformationUserDetailView, "Подразделение", department);
        }        
    }
}
