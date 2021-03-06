﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CreateBudgetDetailViewController : FormController
    {
        //перечисляются элементы формы, задействованные в тестах
        public override List<UIMapper> Map => new List<UIMapper>
        {
            new UIMapper("Название сита", typeof(ComboBoxController), "selectedSite",true),
            new UIMapper("Создать", typeof(MuiButtonController), "Создать",false,new Dictionary<string, string> { { "div", "DetalizationOfSite" } }),
            new UIMapper("Год", typeof(TextBoxController), "year",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Сохранить", typeof(MuiButtonController), "Сохранить"),
            new UIMapper("Отмена", typeof(MuiButtonController), "Отмена"),
            new UIMapper("Центр результата", typeof(ComboBoxController), "resultCenterId",true),
            new UIMapper("Тип инвестиций",typeof(ComboBoxController), "typeOfInvestmentId",true),
            new UIMapper("Категория",typeof(ComboBoxController), "categoryOfEquipmentId",true),
            new UIMapper("Предмет инвестиций",typeof(TextBoxController), "subjectOfInvestment",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Дата поставки", typeof(DatePickerController), "dateOfDelivery"), // TODO: Реализовать через DatePickerController
            new UIMapper("Количество",typeof(TextBoxController), "count",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Цена",typeof(TextBoxController), "price",false,new Dictionary<string, string> { { "type", "input" } }),
            
        };

        //public void SetDate(Context context,string element, string value)
        //{
        //    DatePickerController dp = mapping[element] as DatePickerController;
        //    dp.SetValueByJs(context, value);
        //}
    }
}
