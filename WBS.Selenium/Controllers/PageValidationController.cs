using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WBS.Selenium.Enums;
using WBS.Selenium.Interfaces;

namespace WBS.Selenium.Controllers
{
    /// <summary>
    ///  класс PageValidationController
    ///  класс для некоторых проверок
    /// </summary>
    public class PageValidationController
    {
        private Context context;

        public void Initialize(Context context)
        {
            this.context = context;
        }

        public void CheckUrl(string expectedUrl)
        {
            Assert.DoesNotThrow(() => { context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.UrlContains(expectedUrl)); },
                "Ожидалось, что url будет содержать '{0}', получено - '{1}'", expectedUrl, context.Driver.Url);
        }

        public void CheckModalCaption(string expectedCaption)
        {
            string actualCaption = context.Waitings.Get(Waitings.Normal).Until(ExpectedConditions.ElementIsVisible(
                By.XPath("//div[contains(@class,'ModalWindow')]//h2[contains(@class,'MuiTypography-title')]"))).Text;
            Assert.AreEqual(expectedCaption, actualCaption, "Ожидался заголовок страницы '{0}', получен - '{1}'", expectedCaption, actualCaption);
        }

        public void CheckFieldValue(IFormController form, string field, string value)
        {
            string actualValue = form.GetElementValue(field);
            Assert.AreEqual(value, actualValue, "В поле '{0}' ожидалось значение '{1}', получено - '{2}'", field, value, actualValue);
        }
        public void CheckError(string errorMessage)
        {
            string a = $"//div//span[contains(text(),'{errorMessage}')]";
            Assert.DoesNotThrow(
                () => { context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementIsVisible(By.XPath(a))); },
                "Ожидалось, что появится предупреждение '{0}'", errorMessage);
        }
    }
}
