using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers.FormControllers
{
    /// <summary>
    ///  Класс ListViewController
    ///  основной DetailView (таблица Common и кнопка Создать), описывающий работу с таблицей
    /// </summary>
    public class ListViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("Создать", typeof(MuiButtonController), "Создать"),
             
             //table
             new UIMapper("Таблица",typeof(TableController),"Common"),
             new UIMapper("Детальный план сита",typeof(DetailedPlanTableController),"DetalizationOfSite"),
        };

        public void CheckTableContains(string value)
        {
            TableController table = mapping["Таблица"] as TableController;
            table?.CheckTableContains(value);
        }

        public void CheckTablenNotContains(string value)
        {
            TableController table = mapping["Таблица"] as TableController;
            table?.CheckTablenNotContains(value);
        }

        public void ClickRowTable(string value)
        {
            TableController table = mapping["Таблица"] as TableController;
            table?.Click(value);
        }

        public List<string> GetListFieldValues(string field, int maxPageNum=0)
        {
            TableController table = mapping["Таблица"] as TableController;
            return table?.GetListFieldValues(field, maxPageNum);
        }

        public void SortColumn(string column, bool setUp=true)
        {
            TableController table = mapping["Таблица"] as TableController;
            table?.SortColumn(column, setUp);
        }

        public void CheckTableContainsByName(string value, string tableName)
        {
            TableController table = mapping[tableName] as TableController;
            table?.CheckTableContains(value);
        }
    }
}
