using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using WBS.Selenium.Factories;

namespace WBS.Selenium
{
    /// <summary>
    ///  Класс Context
    ///  имеет поля для работы с драйвером, ожиданиями, которые создаются с помощью драйвера, список пользователей
    ///  для каждого теста необходим свой IWebDriver
    /// </summary>
    public class Context
    {
        //драйвер=браузер
        public IWebDriver Driver { get; set; }      
        //фабрика для раюоты с данными тестов в Configs\\Tests\\*.xml
        public TestSettingsFactory TestSettings { get; protected set; }
        //фабрика ожиданий
        public WaitingsFactory Waitings { get; }
        //фабрика пользователей
        public UsersFactory Users { get; }

        public Context(string testId)
        {
            Driver = new ChromeDriver();
            TestSettings = new TestSettingsFactory(testId);
            Waitings = new WaitingsFactory(Driver);
            Users = new UsersFactory();
        }
    }
}
