using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class TableController:UIController
    {
        string tableClass;
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            base.Initialize(context, id, waitPostback, parameters);
            tableClass = $"{id}Table";
            locator = By.XPath($"//div[contains(@class,'{tableClass}') and contains(@class,'MuiPaper')]");
        }

        #region TableActions
        public void Click(string value)
        {
            string xpath = $"//table[contains(@class,'{tableClass}')]//td[contains(text(),'{value}')]";
            IWebElement td = context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            td.Click();
        }
        #endregion

        #region Validation
        public void CheckTableContains(string value)
        {
            string xpath = $"//table[contains(@class,'{tableClass}')]//td[contains(text(),'{value}')]";
            Assert.DoesNotThrow(()=>
            {
                context.Waitings.Get(Waitings.Normal).Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }, "В таблице {0} ожидалось значение '{1}'", id, value);
        }
        #endregion
    }
}
