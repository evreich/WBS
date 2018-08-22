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
using WBS.Selenium.Controllers.UIControllers;

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
            //Context.Driver.Navigate().GoToUrl("http://localhost:55443/DAIRequests");
            NavigationMenu.OpenPage("Заявки на инвестиции");
            Thread.Sleep(2000);
            //IWebElement create = Context.Driver.FindElement(By.CssSelector(".MuiButton-sizeSmall-185"));
            //create.Click();
            ListView.ClickElement("Создать");
            Thread.Sleep(2000);
            //IWebElement siteId = Context.Driver.FindElement(By.XPath("//input[@name='siteId']/..//div"));
            //siteId.Click();
            ComboBoxController controller1 = new ComboBoxController();
            controller1.Initialize(Context, "resultCentre", false, new Dictionary<string, string>());
            controller1.SetValue("siteID");
            Thread.Sleep(2000);

            ComboBoxController controller = new ComboBoxController();
            controller.Initialize(Context, "siteId",false,new Dictionary<string, string>());
            controller.SetValue("sit1");
            Thread.Sleep(2000);
            // Селектор для выбора элемента в выпадающем списке любо, открытом на форме
            //IWebElement ddlItem = Context.Driver.FindElement(By.XPath("//ul[@role='listbox']//li"));
            //ddlItem.Click();
            //Thread.Sleep(2000);
            ComboBoxController controller11 = new ComboBoxController();
            controller11.Initialize(Context, "resultCentre", false, new Dictionary<string, string>());
            controller11.SetValue("resultCentreId");
            //IWebElement resultCentre = Context.Driver.FindElement(By.XPath("//input[@name='resultCentreId']/..//div"));
            //resultCentre.Click();
            //Thread.Sleep(2000);
            ComboBoxController controller2 = new ComboBoxController();
            controller2.Initialize(Context, "siteId", false, new Dictionary<string, string>());
            controller2.SetValue("ggnbvs");
            Thread.Sleep(2000);
            //IWebElement ddlItemResult = Context.Driver.FindElement(By.XPath("//ul[@role='listbox']//li"));
            //ddlItemResult.Click();
            //Thread.Sleep(2000);
            //PageController.ScrollBottom("document.querySelector(\"[type=\'submit\']\")
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Context.Driver);
            js.ExecuteScript("document.querySelector(\"[type=\'submit\']\").scrollIntoView();");
            Thread.Sleep(2000);
            MuiButtonController controller3 = new MuiButtonController();
            controller3.Initialize(Context, "", false, new Dictionary<string, string>());
            controller3.Click();

            //IWebElement buttonSave = Context.Driver.FindElement(By.XPath("//button[@type='submit']"));
            //buttonSave.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Context.Driver.Url.Equals("http://localhost:55443/DAIRequests"), ("Переход на страницу со списком заявок не был осуществлен"));
        }
    }
}
