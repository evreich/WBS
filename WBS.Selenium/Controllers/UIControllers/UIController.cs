using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WBS.Selenium.Interfaces;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Controllers.UIControllers
{
    public abstract class UIController: IUIController
    {
        protected By locator;
        protected Context context;
        protected string id;
        protected bool waitPostback;
        protected bool waitPageChanged;

        public virtual void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            this.context = context;
            this.id = id;
            this.waitPostback = waitPostback;
            if (parameters == null || !parameters.ContainsKey("waitPageChanged") || parameters["waitPageChanged"] == "false")
                waitPageChanged = false;
            else
                waitPageChanged = true;
        }

        public virtual void Click()
        {
            try
            {
                IWebElement e = context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementToBeClickable(locator));
                e.Click();
            }
            catch
            {
                Thread.Sleep(3000);
                IWebElement e = context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementToBeClickable(locator));
                e.Click();
            }
        }

        public void Focus()
        {
            throw new NotImplementedException();
        }

        public string GetValue()
        {
            throw new NotImplementedException();
        }

        
        public bool IsVisible()
        {
            try
            {
                IWebElement e = context.Waitings.Get(Waitings.Normal).Until(ExpectedConditions.ElementIsVisible(locator));
                return e.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public virtual void SetValue(string value)
        {
            //throw new NotImplementedException();
        }

        public void WaitVisible()
        {
            context.Waitings.Get(Waitings.Normal).Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
