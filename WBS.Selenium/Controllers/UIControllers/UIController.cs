using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WBS.Selenium.Controllers.UIControllers
{
    public abstract class UIController
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
        public bool IsVisible()
        {
            try
            {
                IWebElement e = context.Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return e.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
