using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CreateSitFormDetailViewController:FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
            new UIMapper("Название", typeof(ComboBoxController), "selectedSite"),
            new UIMapper("Формат", typeof(MuiButtonController), "Создать",false,new Dictionary<string, string> { { "div", "DetalizationOfSite" } }),
            new UIMapper("КУ Сита", typeof(TextBoxController), "year",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Сохранить", typeof(MuiButtonController), "Сохранить"),
            new UIMapper("Технический эксперт", typeof(MuiButtonController), "Отмена"),
            new UIMapper("Директор сита", typeof(ComboBoxController), "resultCenterId"),
            new UIMapper("Создатель",typeof(ComboBoxController), "typeOfInvestmentId"),
            new UIMapper("Операционный директор",typeof(ComboBoxController), "categoryOfEquipmentId"),
           //кнопка сохранить и отмена
        };
    }
}
