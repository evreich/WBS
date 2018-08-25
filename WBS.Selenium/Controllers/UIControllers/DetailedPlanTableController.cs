using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Interfaces;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class DetailedPlanTableController:UIController
    {
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            locator = By.XPath($"//div[@id='{id}']");
        }
    }
}
