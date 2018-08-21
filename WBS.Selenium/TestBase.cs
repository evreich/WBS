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


namespace WBS.Selenium
{
    [TestFixture]
    public class TestBase
    {
        public IWebDriver _driver;
        public WebDriverWait wait;
        public Context Context;

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void Start()
        {
            _driver = new ChromeDriver();
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Context = new Context();
        }
        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void Stop()
        {
            _driver.Quit();
            //driver = null;
        }

        // Вход в приложение под пользователем
        public void Login(User user)
        {
            IWebElement login = _driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'login')]"));
            login.SendKeys(user.Login);
            Thread.Sleep(1000);
            IWebElement parol = _driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'password')]"));
            parol.SendKeys(user.Password);
            Thread.Sleep(1000);
            IWebElement button = _driver.FindElement(By.XPath("//button[contains(@class,'ButtonPrimary-button')]"));
            button.Click();
            Thread.Sleep(5000);
            // Вынести в константы главную страницу после логина
            string MainPage = "http://localhost:55443/Home";
            // Проверка, на то, что после логина перешли на главную страницу сайта
            Assert.IsTrue(_driver.Url.Equals(MainPage), String.Format("Переход после логина не был осуществлен на главную страницу сайта. Под пользователем - {0}", user.Login));
        }

        // Выход из приложения
        public void Logout()
        {
            IWebElement sideBarButton = _driver.FindElement(By.CssSelector(".SideMenuComponent-menuButton-6"));
            sideBarButton.Click();
            Thread.Sleep(1000);
            IWebElement logoutButton = _driver.FindElement(By.CssSelector(".SideMenuComponent-drawerHeader-9 > button"));
            logoutButton.Click();
        }

    }
}


