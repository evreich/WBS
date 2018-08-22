using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace WBS.Selenium.Controllers.UIControllers
{
    public class TextBoxController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            string type = String.Empty;
            if(parameters!=null && parameters.ContainsKey("type"))
            {
                type = parameters["type"];
            }
            if(string.IsNullOrEmpty(type))
            {
                locator = By.XPath($"//div[contains(@class,'MuiInput')]//{type}[@name='{id}']");
            }
            else
            {
                //....
            }
        }

        public override void SetValue(string value)
        {
            IWebElement tb = context.Driver.FindElement(locator);
            tb.Click();
            Thread.Sleep(1000);
            tb.SendKeys(Keys.Control + "a");
            tb.SendKeys(Keys.Delete);
            tb.SendKeys(value);
        }
    }
}
