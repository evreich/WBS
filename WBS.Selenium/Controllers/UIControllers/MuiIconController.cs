using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class MuiIconController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            string prefix = string.Empty;
            base.Initialize(context, id, waitPostback, parameters);
            if(parameters!=null && parameters.ContainsKey("form"))
            {
                prefix = $"//div[contains(@class,'{parameters["form"]}')]";
            }
            locator = By.XPath($"{prefix}//button[contains(@class,'MuiIcon') and contains(@class,'{id}')]");
        }

        public override void Click()
        {
            base.Click();
            PageController.WaitJsLoaded(context);
        }
    }
}
