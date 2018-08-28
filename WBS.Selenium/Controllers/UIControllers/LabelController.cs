using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class LabelController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//tr[contains(@class,'Information')]//td[text()='{id}']/parent::tr//div");
        }

        public override string GetValue()
        {
            IWebElement label= context.Waitings.Get(Waitings.Normal).Until(ExpectedConditions.ElementIsVisible(locator));
            return label.Text;
        }
    }
}
