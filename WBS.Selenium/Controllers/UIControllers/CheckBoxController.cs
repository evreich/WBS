using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CheckBoxController : UIController
    {


        public override void Initialize(Context context, string id, bool waitPostback, Dictionary<string, string> parameters)
        {

            base.Initialize(context, id, waitPostback, parameters);
            if (parameters != null && parameters.ContainsValue("span"))
            {
                locator = By.XPath($"//span[contains(@class,'MuiFormControlLabel')]//span[contains(text(),'{id}')]");
            }
            else
            {
                locator = By.XPath($"//span[contains(@class,'MuiFormControlLabel') and contains(text(),'{id}')]");
            }

        }
        public override void Click()
        {
            IWebElement cb = context.Driver.FindElement(locator);
            Thread.Sleep(2000);
            cb.Click();
        }
    }
}
