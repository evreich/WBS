using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using WBS.Selenium.Enums;

namespace WBS.Selenium.Controllers.UIControllers
{
    public class TableController:UIController
    {
        MuiButtonController buttonAdd;
        string div = string.Empty;
        string tableClass;
        public override void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
           
            base.Initialize(context, id, waitPostback, parameters);
            if(parameters!=null && parameters.ContainsKey("div"))
            {
                div = $"//div[contains(@id,'{parameters["div"]}')]";
            }
            tableClass = $"{id}Table";
            locator = By.XPath($"{div}//table[contains(@class,'{tableClass}')]");
        }

        #region TableActions
        public void Click(string value)
        {
            string xpath = $"//table[contains(@class,'{tableClass}')]//td[contains(text(),'{value}')]";
            IWebElement td = context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            td.Click();
        }  
        
        public void ClickFirstRow()
        {
            string xpath = $"{div}//table[contains(@class,'{tableClass}')]//td";
            IWebElement td = context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            td.Click();
        }

        public List<string> GetListFieldValues(string column, int maxPageNum)
        {
            List<string> values = new List<string>();
            List<IWebElement> columns = context.Driver.FindElements(By.XPath($"//table[contains(@class,'{tableClass}')]//th//span")).ToList();
            int numColumn = columns.FindIndex(a => a.Text.Contains(column));
            List<IWebElement> rows= context.Driver.FindElements(By.XPath($"//table[contains(@class,'{tableClass}')]//tbody//tr[contains(@class,'{tableClass}')]")).ToList();
            for(int i=0;i<rows.Count;i++)
            {
                List<IWebElement> tds = rows[i].FindElements(By.TagName("td")).ToList();
                values.Add(tds[numColumn].Text);
            }
            //добавить переход на след страницы
            return values;
        }

        public void SortColumn(string column,bool sortUp)
        {
            string headerXpath = $"//thead//*[contains(text(),'{column}')]";
            string sortUpClass = "DirectionAsc";
            string sortDownClass = "DirectionDesc";
            IWebElement columnHead = context.Driver.FindElement(By.XPath(headerXpath));
            if(!columnHead.GetAttribute("class").Contains("MuiTableSortLabel-active"))
            {
                columnHead.Click();
            }
            while(sortUp&& context.Driver.FindElements(By.XPath($"//thead//*[contains(@class,'{sortUpClass}')]")).Count == 0 ||
                !sortUp && context.Driver.FindElements(By.XPath($"//thead//*[contains(@class,'{sortDownClass}')]")).Count==0)
            {
                columnHead.Click();
            }
        }

        public void ClickAdd()
        {
            buttonAdd = new MuiButtonController();
            buttonAdd.Initialize(context, "Добавить");
            buttonAdd.Click();
        }
        public void ClickPlus(string id)
        {
            string xpath = $"//button[@name='{id}']";
            IWebElement zt = context.Waitings.Get(Waitings.Short).Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            zt.Click();
        }
        #endregion

        #region Pagination
        public void ShowCountsOfElements(int count)
        {
            IWebElement div = context.Driver.FindElement(By.XPath($"//table[contains(@class,'{tableClass}')]//div[contains(@class,'MuiTablePagination') and contains(@class,'selectMenu')]"));
            div.Click();
            IWebElement li = context.Driver.FindElement(By.XPath($"//ul[contains(@class,'MuiList-padding')]//li[text()='{count}']"));
            li.Click();
        }
        #endregion

        #region Validation
        public void CheckTableContains(string value)
        {
            string xpath = $"//table[contains(@class,'{tableClass}')]//td[contains(text(),'{value}')]";
            Assert.DoesNotThrow(()=>
            {
                context.Waitings.Get(Waitings.Normal).Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }, "В таблице {0} ожидалось значение '{1}'", id, value);
        }

        public void CheckTableContainsByColumn(string column, string value)
        {
            List<IWebElement> columns = context.Driver.FindElements(By.XPath($"{div}//table[contains(@class,'{tableClass}')]//th//span")).ToList();
            int numColumn = columns.FindIndex(a => a.Text.Contains(column));
            IWebElement row = context.Driver.FindElement(By.XPath($"{div}//table[contains(@class,'{tableClass}')]//tbody//*[contains(text(),'{value}')]/parent::tr"));
            List<IWebElement> tds = row.FindElements(By.TagName("td")).ToList();
            int num= tds.FindIndex(td => td.Text == value);
            Assert.True(numColumn==num, "Ожидалось, что в таблице в столбце {0} будет значение {1}",column,value);
        }

        public void CheckTablenNotContains(string value)
        {
            string xpath = $"//table[contains(@class,'{tableClass}')]//td[contains(text(),'{value}')]";
            Assert.True(context.Driver.FindElements(By.XPath(xpath)).Count==0,
             "В таблице {0} не ожидалось значение '{1}'", id, value);
        }
        #endregion
    }
}
