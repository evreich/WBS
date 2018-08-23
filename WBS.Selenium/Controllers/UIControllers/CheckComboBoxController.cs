using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class CheckComboBoxController : UIController
    {

        public override void Initialize(Context context, string id, bool waitPostback, Dictionary<string, string> parameters)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//input[@name='{id}']/..//div");
        }

        public void SetListValues(params string[] values)
        {
            IWebElement resultCentre = context.Driver.FindElement(locator);
            resultCentre.Click();
            foreach (var item in values)
            {
                IWebElement li = context.Driver.FindElement(By.XPath($"//ul[@role='listbox']//span[contains(text(),'{item}')]"));
                li.Click();
            }
            //IWebElement form = context.Driver.FindElement(By.XPath("//div[contains(@class,'MuiBackdrop')]"));
            //form.
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            js.ExecuteScript("document.querySelector(\"div[class*='MuiBackdrop-invisible'\").style.display = 'none'");
            js.ExecuteScript("document.querySelector(\"div[class*='MuiMenu-paper'\").style.display = 'none'");
            js.ExecuteScript("document.querySelector(\"div[id*='menu-roles'\").style.display = 'none'");
        }
    }
}
