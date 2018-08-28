using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class ComplexComboBoxController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//div[contains(@class,'MuiInput')]//input[@name='{id}']");
        }

        public override void SetValue(string value)
        {
            //try
            //{
            //    IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            //    js.ExecuteScript("document.querySelector(\"div[class*='MuiBackdrop-root'\").style.display = 'none'");
            //}
            //catch { }
            IWebElement cb = context.Driver.FindElement(locator);
            cb.Click();            
            cb.SendKeys(value);
            Thread.Sleep(2000);
            try
            {
                IWebElement cbItem = context.Driver.FindElement(By.XPath($"//ul[@role='listbox']//li//*[text()='{value}']"));
                cbItem.Click();
            }
            catch
            {
                IWebElement cbItem = context.Driver.FindElement(By.XPath($"//ul[@role='listbox']//li//*[text()='{value}']"));
                Thread.Sleep(500);
                cbItem.Click();
            }
        }
    }
}
