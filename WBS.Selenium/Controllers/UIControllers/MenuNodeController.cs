using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class MenuNodeController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            this.context = context;
            locator = By.XPath($"//h3[contains(@class,'MuiListItemText') and text()='{id}']");
        }

        public void Click()
        {
            IWebElement node = context.Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            node.Click();
        }
    }
}
