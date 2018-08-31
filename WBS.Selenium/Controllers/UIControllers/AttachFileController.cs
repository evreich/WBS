using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Controllers.UIControllers
{
    class AttachFileController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath("//input[contains(@class,'uploader')]");
        }

        public override void SetValue(string value)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "Attachments"));            
            IWebElement tb =context.Driver.FindElement(By.CssSelector("input[type='file']"));
            tb.SendKeys(Path.Combine(path, value));
            Thread.Sleep(2000);
        }
    }
}
