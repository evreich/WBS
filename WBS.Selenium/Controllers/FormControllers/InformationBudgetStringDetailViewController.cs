using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class InformationBudgetStringDetailViewController:FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("Центр результата", typeof(LabelController), "Центр результата"),
             new UIMapper("Тип инвестиций", typeof(LabelController), "Тип инвестиций"),
             new UIMapper("Категория", typeof(LabelController), "Категория"),
             new UIMapper("Предмет инвестиций", typeof(LabelController), "Предмет инвестиций"),
             new UIMapper("Дата поставки", typeof(LabelController), "Дата поставки"),
             new UIMapper("Количество", typeof(LabelController), "Количество"),
             new UIMapper("Цена", typeof(LabelController), "Цена, руб."),
             new UIMapper("Сумма", typeof(LabelController), "Сумма, руб."),
             
             //buttons
             new UIMapper("Редактировать",typeof(MuiIconController),"IconLabelButtons",false, new Dictionary<string, string>(){{"form", "InformationModalWindow" } }),
             new UIMapper("ОК",typeof(MuiButtonController),"ОК"),
        };
    }
}
