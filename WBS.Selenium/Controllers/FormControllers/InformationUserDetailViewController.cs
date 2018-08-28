using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Interfaces;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class InformationUserDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("ФИО", typeof(LabelController), "ФИО"),
             new UIMapper("Должность", typeof(LabelController), "Должность"),
             new UIMapper("Подразделение", typeof(LabelController), "Подразделение"),
             new UIMapper("Помечено на удаление",typeof(CheckComboBoxController),"Помечено на удаление"),
             //buttons
             new UIMapper("Редактировать",typeof(MuiIconController),"IconLabelButtons",false, new Dictionary<string, string>(){{"form", "InformationForm" } }),
             new UIMapper("ОК",typeof(MuiButtonController),"ОК"),
        };
    }
}
