using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WBS.Selenium.Controllers
{
    public class PageValidationController
    {
        private Context context;

        public void Initialize(Context context)
        {
            this.context = context;
        }

        public void CheckUrl(string expectedUrl)
        {
            Assert.DoesNotThrow(() => { context.Wait.Until(ExpectedConditions.UrlContains(expectedUrl)); },
                "Ожидалось, что url будет содержать '{0}', получено - '{1}'", expectedUrl, context.Driver.Url);
        }

        public void CheckPageCaption(string expectedCaption)
        {
            //string actualCaption = WaitingHelper.WaitElementIsVisible(context, By.CssSelector(".MainMenuTruncateCaption")).Text;
            //Assert.AreEqual(expectedCaption, actualCaption, "Ожидался заголовок страницы '{0}', получен - '{1}'", expectedCaption, actualCaption);
        }
        public void CheckError(string errorMessage)
        {
            string a = $"//div//span[contains(text(),'{errorMessage}')]";
            Assert.DoesNotThrow(
                () => { context.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(a))); },
                "Ожидалось, что появится предупреждение '{0}'", errorMessage);
        }
    }
}
