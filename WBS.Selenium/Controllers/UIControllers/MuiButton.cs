using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class MuiButton:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//button//span[contains(@class,'MuiButton') and contains(text(),'{id}')]");
        }

        public override void Click()
        {
            base.Click();
            //if (waitPageChanged)
            //    // PageController.WaitPageChanged(context);
            //    PageController.WaitJsLoaded(context);
            //else if (waitPostback)
            //    PageController.WaitPageLoaded(context);
        }
    }
}
