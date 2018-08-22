using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;
using WBS.Selenium.Controllers;

namespace WBS.Selenium
{
    class CreateRequest : TestBase
    {
        [Test, Order(1)]
        public void OpenaBrowser()
        {
            Context.Driver.Navigate().GoToUrl("http://localhost:55443");
            Context.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

        }
        [Test, Order(2)]
        public void CreateApplication()
        {
            //открытие формы редактирования заявки
            User user = Context.Users.FirstOrDefault(u => u.Name == "Admin");
            Login(user);
            Context.Driver.Navigate().GoToUrl("http://localhost:55443/DAIRequests");
            Thread.Sleep(2000);
            //IWebElement create = Context.Driver.FindElement(By.CssSelector(".MuiButton-sizeSmall-185"));
            //create.Click();
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            IWebElement siteId = Context.Driver.FindElement(By.XPath("//input[@name='siteId']/..//div"));
            siteId.Click();
            ComboBoxController controller = new ComboBoxController();
            controller.Initialize(Context, "siteId",false,new Dictionary<string, string>());
            controller.SetValue("sit1");
            Thread.Sleep(2000);
            // Селектор для выбора элемента в выпадающем списке любо, открытом на форме
            //IWebElement ddlItem = Context.Driver.FindElement(By.XPath("//ul[@role='listbox']//li"));
            //ddlItem.Click();
            //Thread.Sleep(2000);
            IWebElement resultCentre = Context.Driver.FindElement(By.XPath("//input[@name='resultCentreId']/..//div"));
            resultCentre.Click();
            Thread.Sleep(2000);
            IWebElement ddlItemResult = Context.Driver.FindElement(By.XPath("//ul[@role='listbox']//li"));
            ddlItemResult.Click();
            Thread.Sleep(2000);
            //PageController.ScrollBottom("document.querySelector(\"[type=\'submit\']\")
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Context.Driver);
            js.ExecuteScript("document.querySelector(\"[type=\'submit\']\").scrollIntoView();");
            Thread.Sleep(2000);
            IWebElement buttonSave = Context.Driver.FindElement(By.XPath("//button[@type='submit']"));
            buttonSave.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Context.Driver.Url.Equals("http://localhost:55443/DAIRequests"), ("Переход на страницу со списком заявок не был осуществлен"));
        }
    }
}
