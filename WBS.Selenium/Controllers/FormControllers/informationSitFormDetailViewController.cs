using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class InformationSitFormDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
            new UIMapper("Название", typeof(LabelController), "Название"),
            new UIMapper("Профиль", typeof(LabelController), "Профиль"),
            new UIMapper("Директор формата", typeof(LabelController),"Директор формата"),
            new UIMapper("Директор КУ формата", typeof(LabelController),"Директор КУ формата" ),
            new UIMapper("Ку Формат", typeof(LabelController), "Ку Формат"),
            new UIMapper("Тип формата", typeof(LabelController), "Тип формата"),
            new UIMapper("Е1",typeof(LabelController), "Е1"),
            new UIMapper("Е2",typeof(LabelController),"Е2" ),
            new UIMapper("Е3",typeof(LabelController),"Е3" ),

        new UIMapper("Редактировать",typeof(MuiIconController),"IconLabelButtons",false, new Dictionary<string, string>(){{"form", "InformationForm" } }),
        new UIMapper("ОК",typeof(MuiButtonController),"ОК"),
    };
    }
}
