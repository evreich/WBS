using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class InformationSiteDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("Название", typeof(LabelController), "Название"),
             new UIMapper("Формат", typeof(LabelController), "Формат"),
             new UIMapper("КУ Сита", typeof(LabelController), "КУ Сита"),
             new UIMapper("Технический эксперт", typeof(LabelController), "Технический эксперт"),
             new UIMapper("Директор Сита", typeof(LabelController), "Директор Сита"),
             new UIMapper("Создатель",typeof(LabelController),"Создатель"),
             new UIMapper("КУ региональный", typeof(LabelController), "КУ региональный"),
             new UIMapper("Операционный директор",typeof(LabelController),"Операционный директор"),
            //buttons
             new UIMapper("Редактировать",typeof(MuiIconController),"IconLabelButtons",false, new Dictionary<string, string>(){{"form", "InformationModalWindow" } }),
             new UIMapper("ОК",typeof(MuiButtonController),"ОК"),

        };
    }
}
