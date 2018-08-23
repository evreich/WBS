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
using WBS.Selenium.Controllers.FormControllers;
using WBS.Selenium.Interfaces;

namespace WBS.Selenium
{
    [TestFixture]
    public abstract class TestBase
    {
        public Context Context;
        public abstract string Id { get; }

        private Lazy<NavigationMenuController> navigationMenu = new Lazy<NavigationMenuController>(() => new NavigationMenuController());
        private Lazy<ListViewController> listView = new Lazy<ListViewController>(() => new ListViewController());
        private Lazy<CreateUserDetailViewController> createUserDetailView = new Lazy<CreateUserDetailViewController>(() => new CreateUserDetailViewController());
        private Lazy<CreateRequestDetailViewController> createRequestDetailView = new Lazy<CreateRequestDetailViewController>(() => new CreateRequestDetailViewController());

        public CreateUserDetailViewController CreateUserDetailView => InitializeController(createUserDetailView);
        public ListViewController ListView => InitializeController(listView);
        public NavigationMenuController NavigationMenu => InitializeController(navigationMenu);

        public CreateRequestDetailViewController CreateRequestDetailView => InitializeController(createRequestDetailView);


        public PageValidationController PageValidation { get; private set; }

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void Start()
        {
            Context = new Context(Id);
            PageValidation = new PageValidationController();
        }
        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void Stop()
        {
            Context.Driver.Quit();
            //driver = null;
        }

        // Вход в приложение под пользователем
        public void Login(User user)
        {
            IWebElement login = Context.Driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'login')]"));
            login.SendKeys(user.Login);
            Thread.Sleep(1000);
            IWebElement parol = Context.Driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'password')]"));
            parol.SendKeys(user.Password);
            Thread.Sleep(1000);
            IWebElement button = Context.Driver.FindElement(By.XPath("//button[contains(@class,'ButtonPrimary-button')]"));
            button.Click();
            Thread.Sleep(5000);
            // Вынести в константы главную страницу после логина
            string MainPage = "http://localhost:55443/Home";
            // Проверка, на то, что после логина перешли на главную страницу сайта
            Assert.IsTrue(Context.Driver.Url.Equals(MainPage), String.Format("Переход после логина не был осуществлен на главную страницу сайта. Под пользователем - {0}", user.Login));
        }

        // Выход из приложения
        public void Logout()
        {
            IWebElement sideBarButton = Context.Driver.FindElement(By.CssSelector(".SideMenuComponent-menuButton-6"));
            sideBarButton.Click();
            Thread.Sleep(1000);
            IWebElement logoutButton = Context.Driver.FindElement(By.CssSelector(".SideMenuComponent-drawerHeader-9 > button"));
            logoutButton.Click();
        }

        private T InitializeController<T>(Lazy<T> controller) where T : IFormController
        {
            T value;
            if (controller.IsValueCreated)
            {
                value = controller.Value;
            }
            else
            {
                value = controller.Value;
                value.Initialize(Context);
            }
            return value;
        }
    }
}


