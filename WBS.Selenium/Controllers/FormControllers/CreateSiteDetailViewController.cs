using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CreateSiteDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("Название", typeof(TextBoxController), "title",false,new Dictionary<string, string> { { "type", "textarea" } }),
             new UIMapper("Формат", typeof(ComboBoxController), "formatId"),
             new UIMapper("КУ Сита", typeof(ComplexComboBoxController), "kySitId"),
             new UIMapper("Технический эксперт", typeof(ComplexComboBoxController), "technicalExpertId"),
             new UIMapper("Директор Сита", typeof(ComplexComboBoxController), "directorOfSitId"),
             new UIMapper("Создатель",typeof(ComplexComboBoxController),"createrOfBudgetId"),
             new UIMapper("КУ региональный", typeof(ComplexComboBoxController), "kyRegionId"),
             new UIMapper("Операционный директор",typeof(ComplexComboBoxController),"operationDirectorId"),
             //buttons
             new UIMapper("Сохранить",typeof(MuiButtonController),"Сохранить"),
             new UIMapper("Отмена",typeof(MuiButtonController),"Отмена"),

        };
    }
}
