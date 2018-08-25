using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class ListViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("Создать", typeof(MuiButtonController), "Создать"),
             //table
             new UIMapper("Таблица",typeof(TableController),"Common"),
        };

        public void CheckTableContains(string value)
        {
            TableController table = mapping["Таблица"] as TableController;
            table?.CheckTableContains(value);
        }

        public void ClickRowTable(string value)
        {
            TableController table = mapping["Таблица"] as TableController;
            table?.Click(value);
        }
    }
}
