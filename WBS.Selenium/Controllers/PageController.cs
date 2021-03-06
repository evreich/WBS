﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Controllers
{
    /// <summary>
    ///  Статический класс PageController
    ///  класс для работы со страницей
    /// </summary>
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
        public static void ScrollTop(Context context)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)context.Driver);
            //js.ExecuteScript($"$('#{id}').scrollTop(0);");
            js.ExecuteScript("document.querySelector(\"[type=\'submit\']\").scrollIntoView(false);");
        }
        public static void WaitJsLoaded(Context context)
        {
            Thread.Sleep(3000);
        }

        public static string GetScreenshot(Context context)
        {
            return ((ITakesScreenshot)context.Driver).GetScreenshot().AsBase64EncodedString;
        }

        private static void WaitAjaxLoaded(Context context)
        {
            context.Waitings.Get(Waitings.Normal).Until(wd => (bool)((IJavaScriptExecutor)wd).
            ExecuteScript("return (typeof jQuery!='undefined')? $.active == 0 : true;"));
        }

        public static void WaitUntilJSReady(Context context)
        {            
            context.Waitings.Get(Waitings.Normal).Until(wd => (bool)((IJavaScriptExecutor)wd).
            ExecuteScript("return document.readyState").ToString().Equals("complete"));

        }
    }
}
