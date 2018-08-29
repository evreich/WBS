using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WBS.Selenium.Controllers;
using WBS.Selenium.Controllers.FormControllers;
using WBS.Selenium.Interfaces;
using WBS.Selenium.Models;
using AventStack.ExtentReports;
using System.Configuration;
using WBS.Selenium.Factories;
using System.IO;

namespace WBS.Selenium.Models
{
    /// <summary>
    /// Абстракный класс TestBase
    ///  является базовым для всех тестов
    ///  осуществляется "ленивая" инициализация контролеров, формируется отчёт и видеозапись, имеет методы для входа и выхода пользователя
    /// </summary>
    public abstract class TestBase
    {
        public Context Context;
        public abstract string Id { get; }
        private VideoRecorder _recording;
        //хранить видео только падений
        private bool _saveFailedOnly = true;

        //инициализация контроллеров
        #region  FormControllers
        private Lazy<NavigationMenuController> navigationMenu = new Lazy<NavigationMenuController>(() => new NavigationMenuController());
        private Lazy<ListViewController> listView = new Lazy<ListViewController>(() => new ListViewController());
        private Lazy<CreateUserDetailViewController> createUserDetailView = new Lazy<CreateUserDetailViewController>(() => new CreateUserDetailViewController());
        private Lazy<CreateRequestDetailViewController> createRequestDetailView = new Lazy<CreateRequestDetailViewController>(() => new CreateRequestDetailViewController());
        private Lazy<CreateBudgetDetailViewController> createBudgetDetailView = new Lazy<CreateBudgetDetailViewController>(() => new CreateBudgetDetailViewController());
        private Lazy<InformationUserDetailViewController> informationUserDetailView = new Lazy<InformationUserDetailViewController>(() => new InformationUserDetailViewController());
        private Lazy<InformationBudgetStringDetailViewController> informationBudgetStringDetailView = new Lazy<InformationBudgetStringDetailViewController>(() => new InformationBudgetStringDetailViewController());
        private Lazy<CreateSiteDetailViewController> createSiteDetailView = new Lazy<CreateSiteDetailViewController>(() => new CreateSiteDetailViewController());
        private Lazy<SelectProviderDetailViewController> selectProviderDetailView = new Lazy<SelectProviderDetailViewController>(() => new SelectProviderDetailViewController());
        private Lazy<CreateSitFormatDetailViewController> createSitFormDetailView = new Lazy<CreateSitFormatDetailViewController>(() => new CreateSitFormatDetailViewController());
        private Lazy<InformationSiteDetailViewController> informationSiteDetailView = new Lazy<InformationSiteDetailViewController>(() => new InformationSiteDetailViewController());

        public InformationSiteDetailViewController InformationSiteDetailView => InitializeController(informationSiteDetailView);
        public CreateSiteDetailViewController CreateSiteDetailView => InitializeController(createSiteDetailView);
        public InformationBudgetStringDetailViewController InformationBudgetStringDetailView => InitializeController(informationBudgetStringDetailView);
        public InformationUserDetailViewController InformationUserDetailView => InitializeController(informationUserDetailView);
        public CreateUserDetailViewController CreateUserDetailView => InitializeController(createUserDetailView);
        public ListViewController ListView => InitializeController(listView);
        public NavigationMenuController NavigationMenu => InitializeController(navigationMenu);

        public CreateRequestDetailViewController CreateRequestDetailView => InitializeController(createRequestDetailView);
        public CreateBudgetDetailViewController CreateBudgetDetailView => InitializeController(createBudgetDetailView);
        public SelectProviderDetailViewController SelectProviderDetailView => InitializeController(selectProviderDetailView);
        public CreateSitFormatDetailViewController CreateSitFormDetailView => InitializeController(createSitFormDetailView);

        #endregion
        public PageValidationController PageValidation { get; private set; }

        public TestBase()
        {
            //формирование отчёта
            string reportTitle;
            if (TestContext.CurrentContext.Test.Properties.ContainsKey("Description") &&
                TestContext.CurrentContext.Test.Properties["Description"].Count() != 0)
                reportTitle = TestContext.CurrentContext.Test.Properties["Description"].ToList()[0].ToString();
            else
                reportTitle = TestContext.CurrentContext.Test.Name;


            Reporter.FileName = ConfigurationManager.AppSettings.Get("reportFileName");
            Reporter.TitleName = ConfigurationManager.AppSettings.Get("titleFileName");
            Reporter.Instance.CreateTest(reportTitle);
        }

        //выполняется перед запуском каждого теста в текущем тест сьюте
        [SetUp]
        public void InitReport()
        {
            string testTitle;
            if (NUnit.Framework.TestContext.CurrentContext.Test.Properties.ContainsKey("Description"))
                testTitle = (NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get("Description")).ToString();
            else
                testTitle = NUnit.Framework.TestContext.CurrentContext.Test.MethodName;
            Reporter.Instance.CreateNode(testTitle);

        }

        //выполняется после каждого теста
        [TearDown]
        public void LogTestResult()
        {
            //записать результаты выполнения шага теста в отчёт
            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(NUnit.Framework.TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", NUnit.Framework.TestContext.CurrentContext.Result.StackTrace).Replace("<", "&lt;").Replace(">", "&gt;");
            Status logstatus;
            var result = NUnit.Framework.TestContext.CurrentContext.Result.Message;
            string screenHtml = string.Empty;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            Reporter.Instance.CurrentNode.Log(logstatus, "Тест завершен со статусом \"" + logstatus + "\"");
            if (!string.IsNullOrEmpty(result))
                Reporter.Instance.CurrentNode.Info($"<textarea style=\"height: 100%\" rows=\"15\" readonly >{result}{stacktrace}</textarea>{screenHtml}");
            Reporter.Instance.Report.Flush();
        }

        protected string GetExtendError()
        {
            return PageController.GetScreenshot(Context);
        }

        //вызывается перед началом запуска всех тестов
        [OneTimeSetUp]
        public void Start()
        {
            string testTitle;
            if (NUnit.Framework.TestContext.CurrentContext.Test.Properties.ContainsKey("Description"))
                testTitle = (NUnit.Framework.TestContext.CurrentContext.Test.Properties.Get("Description")).ToString();
            else
                testTitle = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            //Reporter.Instance.CreateTest()
            Context = new Context(Id);
            PageValidation = new PageValidationController();
            _recording = RecorderFactory.Instance.Create(testTitle);
            _recording.Start();
            PageValidation.Initialize(Context);
        }

        //вызывается после завершения всех тестов
        [OneTimeTearDown]
        public void Stop()
        {
            //остановка записи
            _recording?.Stop();

            if (_saveFailedOnly && Equals(TestContext.CurrentContext.Result.Outcome, ResultState.Success))
            {
                DeleteRelatedVideo();
            }

            //закрытие браузера
            Context.Driver.Quit();
        }

        // Вход в приложение под пользователем
        public void Login(User user)
        {
            IWebElement login = Context.Driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'login')]"));
            login.SendKeys(user.Login);
            IWebElement parol = Context.Driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'password')]"));
            parol.SendKeys(user.Password);
            IWebElement button = Context.Driver.FindElement(By.XPath("//button[contains(@class,'ButtonPrimary-button')]"));
            button.Click();
            PageController.WaitUntilJSReady(Context);
        }

        public void Login(string login, string password)
        {
            IWebElement loginElement = Context.Driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'login')]"));
            loginElement.SendKeys(login);
            IWebElement passordElement = Context.Driver.FindElement(By.XPath("//input[contains(@class,'MuiInput') and contains(@name,'password')]"));
            passordElement.SendKeys(password);
            IWebElement button = Context.Driver.FindElement(By.XPath("//button[contains(@class,'ButtonPrimary-button')]"));
            button.Click();
            PageController.WaitUntilJSReady(Context);
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

        //инициализация контролера
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

        //удаление видео
        private void DeleteRelatedVideo()
        {
            try
            {
                File.Delete(_recording.OutputFilePath);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
    }
}


