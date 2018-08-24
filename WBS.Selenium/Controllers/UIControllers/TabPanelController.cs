using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WBS.Selenium.Controllers.UIControllers
{
   public class TabPanelController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback, Dictionary<string, string> parameters)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//div//button//span[contains(text(),'{id}')]");
        }
        public override void Click()
        {
            IWebElement tb = context.Driver.FindElement(locator);
            Thread.Sleep(2000);
            tb.Click();
        }
    }
}
