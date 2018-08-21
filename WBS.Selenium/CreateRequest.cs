using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;

namespace WBS.Selenium
{
    class CreateRequest : TestBase
    {
        [Test, Order(1)]
        public void OpenaBrowser()
        {
            _driver.Navigate().GoToUrl("http://localhost:55443");
            _driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }
        [Test, Order(2)]
        public void CreateApplication()
        {
            //открытие формы редактирования заявки
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);
            _driver.Navigate().GoToUrl("http://localhost:55443/DAIRequests");
            Thread.Sleep(2000);
            IWebElement create = _driver.FindElement(By.CssSelector(".MuiButton-sizeSmall-185"));
            create.Click();
            Thread.Sleep(2000);
            IWebElement siteId = _driver.FindElement(By.XPath("//input[@name='siteId']/..//div"));
            siteId.Click();
            Thread.Sleep(2000);
            // Селектор для выбора элемента в выпадающем списке любо, открытом на форме
            IWebElement ddlItem = _driver.FindElement(By.XPath("//ul[@role='listbox']//li"));
            ddlItem.Click();
            Thread.Sleep(2000);
            IWebElement resultCentre = _driver.FindElement(By.XPath("//input[@name='resultCentreId']/..//div"));
            resultCentre.Click();
            Thread.Sleep(2000);
            IWebElement ddlItemRezalt = _driver.FindElement(By.XPath("//ul[@role='listbox']//li"));
            ddlItemRezalt.Click();
            IWebElement buttonSave = _driver.FindElement(By.XPath("//button[@type='submit']"));
            //buttonSave.Click();
            //Thread.Sleep(2000);



        }
    }
}
