using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WBS.Selenium.Controllers
{
    public static class PageController
    {
        public static void ScrollBottom(Context context)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            //js.ExecuteScript($"$('#{id}').scrollTop($('#{id}').prop('scrollHeight'));");
            js.ExecuteScript("document.querySelector(\"[type=\'submit\']\").scrollIntoView();");
        }
        public static void ScrollToElementById(Context context, string id)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            js.ExecuteScript(string.Format("document.querySelector(\"div[id=\'{0}\'] button\").scrollIntoView()", id));
        }
        //не работает, найти ид 
        public static void ScrollTop(Context context, string id)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            js.ExecuteScript($"$('#{id}').scrollTop(0);");
        }
        public static void WaitJsLoaded(Context context)
        {
            //IJavaScriptExecutor jsExecutor = context.Driver as IJavaScriptExecutor;
            //jsExecutor.ExecuteScript(@"
            //    window.pageisready = false; 
            //    window.pagewaitfunc = function() {
            //        $(document).unbind('callbackResultAfter', window.pagewaitfunc);
            //        setTimeout(function() {
            //            window.pageisready = true;
            //        }, 100);
            //    };   
            //    $(window).bind('callbackResultAfter', window.pagewaitfunc);"
            //);
            //context.Wait.Until(wd => (bool)((IJavaScriptExecutor)wd).ExecuteScript("return window.pageisready;"));
            WaitAjaxLoaded(context);
            Thread.Sleep(3000);
        }

        private static void WaitAjaxLoaded(Context context)
        {
            context.Wait.Until(wd => (bool)((IJavaScriptExecutor)wd).ExecuteScript("return (typeof jQuery!='undefined')? $.active == 0 : true;"));
        }
    }
}
