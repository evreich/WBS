using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Interfaces;

namespace WBS.Selenium.Controllers
{
    public class ComboBoxController :UIController
    {

        public override void Initialize(Context context, string id, bool waitPostback, Dictionary<string, string> parameters)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//input[@name='{id}']/..//div");
        }

        public override void SetValue(string value)
        {
            IWebElement cb = context.Driver.FindElement(locator);
            cb.Click();
            Thread.Sleep(2000);
            IWebElement cbItem = context.Driver.FindElement(By.XPath($"//ul[@role='listbox']//li[contains(text(),'{value}')]"));
            cbItem.Click();
            if (waitPostback)            
                PageController.WaitJsLoaded(context);
        }
    }
}

