using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WBS.Selenium.Controllers
{
    public class PageController
    {
        public static void ScrollBottom(Context context, string id)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            js.ExecuteScript($"$('#{id}').scrollTop($('#{id}').prop('scrollHeight'));");
        }

        public static void ScrollTop(Context context, string id)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            js.ExecuteScript($"$('#{id}').scrollTop(0);");
        }
    }
}
