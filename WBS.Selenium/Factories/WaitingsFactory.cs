using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Factories
{
    /// <summary>
    ///  Класс WaitingsFactory
    ///  класс для создания словаря ожиданий
    ///  время ожиданий редактируется в App.config
    /// </summary>
    public class WaitingsFactory
    {
        private Dictionary<string, WebDriverWait> waitings { get; }
        public Dictionary<string, string> Waitings { get; }

        public WaitingsFactory(IWebDriver driver)
        {
            NameValueCollection waits = ConfigurationManager.GetSection("waitings") as NameValueCollection;
            Waitings = new Dictionary<string, string>();
            foreach (string key in waits)
            {
                Waitings.Add(key, waits[key]);
            }
            waitings = new Dictionary<string, WebDriverWait>();
            foreach (KeyValuePair<string, string> pair in Waitings)
            {
                waitings.Add(pair.Key, GetWait(driver, pair.Value));
            }
        }
        public WebDriverWait Get(Waitings key)
        {
            return waitings[key.ToString()];
        }
        private WebDriverWait GetWait(IWebDriver driver, string timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToInt32(timeout)));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);
            return wait;
        }
    }
}
