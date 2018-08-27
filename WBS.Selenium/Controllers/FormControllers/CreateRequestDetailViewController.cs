using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CreateRequestDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
            new UIMapper("Название сита", typeof(ComboBoxController), "siteId"),
            new UIMapper("Центр результата", typeof(ComboBoxController), "resultCentreId"),
            new UIMapper("Выбор технической службы", typeof(CheckBoxController), "Выбор технической службы"),
            new UIMapper("Ariba", typeof(CheckBoxController), "Ariba",false,new Dictionary<string, string> { { "type", "span" } }),
            new UIMapper("Бюджет", typeof(TabPanelController), "Бюджет"),
            new UIMapper("Вне бюджета", typeof(TabPanelController), "Вне бюджета"),
            new UIMapper("Инвестиции", typeof(TabPanelController), "Инвестиции"),
            new UIMapper("Поставщик", typeof(TabPanelController), "Поставщик"),
            new UIMapper("Сохранить", typeof(MuiButtonController), "Сохранить"),    
        };
    }
}
