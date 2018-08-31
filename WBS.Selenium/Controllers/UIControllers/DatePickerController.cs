using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class DatePickerController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback, Dictionary<string, string> parameters)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//input[@name='{id}']");
        }
        public override void SetValue(string value)
        {
            IWebElement datePicker = context.Driver.FindElement(locator);
            datePicker.SendKeys(value);
            Thread.Sleep(2000);
        }

        //public void SetValueByJs(Context context, string value)
        //{
        //    IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
        //    js.ExecuteScript(string.Format("document.querySelector(\"input[name=\'dateOfDelivery\']\").value=\"{0}\"", value));
        //}
    }
}
