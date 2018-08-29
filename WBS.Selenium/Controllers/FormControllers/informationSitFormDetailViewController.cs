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
            new UIMapper("Директор Формата", typeof(LabelController),"Директор Формата"),
            new UIMapper("Директор КУ Формата", typeof(LabelController),"Директор КУ Формата" ),
            new UIMapper("КУ Формат", typeof(LabelController), "КУ Формат"),
            new UIMapper("Тип Формата", typeof(LabelController), "Тип Формата"),
            new UIMapper("E1",typeof(LabelController), "E1"),
            new UIMapper("E2",typeof(LabelController),"E2" ),
            new UIMapper("E3",typeof(LabelController),"E3" ),

        new UIMapper("Редактировать",typeof(MuiIconController),"IconLabelButtons",false, new Dictionary<string, string>(){{"form", "InformationModalWindow" } }),
        new UIMapper("ОК",typeof(MuiButtonController),"ОК"),
        new UIMapper("Удалить",typeof(MuiIconController),"ButtonDelete",false, new Dictionary<string, string>(){{"form", "InformationModalWindow" } }),
    };
    }
}
