using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CreateSitFormatDetailViewController:FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
            new UIMapper("Название", typeof(TextBoxController), "title",false,new Dictionary<string, string> { { "type", "textarea" } }),
            new UIMapper("Профиль", typeof(TextBoxController), "profile",false,new Dictionary<string, string> { { "type", "textarea" } }),
            new UIMapper("Директор формата", typeof(ComplexComboBoxController), "directorOfFormatId"),
            new UIMapper("Директор КУ формата", typeof(ComplexComboBoxController), "directorOfKYFormatId"),
            new UIMapper("Ку Формат", typeof(ComplexComboBoxController), "kyFormatId"),
            new UIMapper("Тип формата", typeof(TextBoxController), "typeOfFormat",false,new Dictionary<string, string> { { "type", "textarea" } }),
            new UIMapper("Е1",typeof(TextBoxController), "e1Limit",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Е2",typeof(TextBoxController), "e2Limit",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Е3",typeof(TextBoxController), "e3Limit",false,new Dictionary<string, string> { { "type", "input" } }),
           //кнопка сохранить и отмена
            new UIMapper("Сохранить",typeof(MuiButtonController),"Сохранить"),
            new UIMapper("Отмена",typeof(MuiButtonController),"Отмена"),
        };
    }
}
