using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using WBS.Selenium.Enums;


namespace WBS.Selenium.Controllers.FormControllers
{
    public class SelectProviderDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
            
        };
       
        public void ClickPlus(string value)
        {

            IWebElement cbItem = Context.Driver.FindElement(By.XPath($"//div//table//tr[.//td[text()='{value}']]//td//button[@name='addProviderBtn']"));
            cbItem.Click();
        }
    }
}
