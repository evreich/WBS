﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Interfaces;
using WBS.Selenium.Models;

namespace WBS.Selenium.Controllers.FormControllers
{
    public abstract class FormController : IFormController, IFormValidationController
    {
        protected Context Context;
        protected Dictionary<string, IUIController> mapping;
        public abstract List<UIMapper> Map { get; }

        public void Initialize(Context context)
        {
            Context = context;
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
            throw new NotImplementedException();
        }

        public bool CheckElementIsVisible(string element)
        {
            throw new NotImplementedException();
        }

        public void WaitElementIsEnabled(string element)
        {
            throw new NotImplementedException();
        }

        public void WaitElementIsVisible(string element)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}