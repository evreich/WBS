using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Interfaces;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    /// <summary>
    ///  Абстрактный класс FormController
    ///  базовый класс для всех DetailView
    /// </summary>
    public abstract class FormController : IFormController, IFormValidationController
    {
        protected Context Context;
        protected Dictionary<string, IUIController> mapping;

        //список элементов, находящихся на форме
        public abstract List<UIMapper> Map { get; }

        public void Initialize(Context context)
        {
            Context = context;
            //инициализация объектов по List<UIMapper> Map
            List<UIMapper> map = Map;
            mapping = new Dictionary<string, IUIController>();
            foreach (UIMapper item in map)
            {
                IUIController controller = (IUIController)Activator.CreateInstance(item.ControllerType);
                controller.Initialize(context, item.ControllerId, item.WaitPostback, item.Parameters);
                mapping.Add(item.Field, controller);
            }
        }
        public void ClickElement(string element)
        {
            GetElement(element)?.Click();
        }

        public string GetElementValue(string element)
        {
            return GetElement(element)?.GetValue();
        }

        public void MoveToElement(string element)
        {
            GetElement(element)?.Focus();
        }

        public void SetElementValue(string element, string value)
        {
            GetElement(element)?.SetValue(value);
        }

        private IUIController GetElement(string element)
        {
            return mapping[element];
        }

        #region Validation
        public bool CheckElementIsEnabled(string element)
        {
            return ((IUIValidationController)mapping[element]).IsEnabled();
        }

        public bool CheckElementIsVisible(string element)
        {
            return ((IUIValidationController)mapping[element]).IsVisible();
        }

        public void WaitElementIsEnabled(string element)
        {
            ((IUIValidationController)mapping[element]).IsEnabled();
        }

        public void WaitElementIsVisible(string element)
        {
           ((IUIValidationController)mapping[element]).IsVisible();
        }
        #endregion

        #region Tables
        public void ClickRowTable(string tableName,string value)
        {
            TableController table = mapping[tableName] as TableController;
            table?.Click(value);
        }

        public void ClickFirstRowTable(string tableName)
        {
            TableController table = mapping[tableName] as TableController;
            table?.ClickFirstRow();
        }

        public void CheckTableContains(string tableName,string value)
        {
            TableController table = mapping[tableName] as TableController;
            table?.CheckTableContains(value);
        }

        public void CheckTableContains(string tableName,string column, string value)
        {
            TableController table = mapping[tableName] as TableController;
            table?.CheckTableContainsByColumn(column,value);
        }

        public void ClickAddInTable(string tableName)
        {
            TableController table = mapping[tableName] as TableController;
            table?.ClickAdd();
        }

        public void CheckTablenNotContains(string tableName,string value)
        {
            TableController table = mapping[tableName] as TableController;
            table?.CheckTablenNotContains(value);
        }
        public bool NextPage(string tableName)
        {
            TableController table = mapping[tableName] as TableController;
            return table.NextPage(tableName);
        }
        public bool PrevPage(string tableName)
        {
            TableController table = mapping[tableName] as TableController;
            return table.PrevPage(tableName);
        }
        #endregion
    }
}
