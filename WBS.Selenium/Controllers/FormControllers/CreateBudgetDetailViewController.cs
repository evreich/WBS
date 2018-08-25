using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBS.Selenium.Controllers.UIControllers;
using WBS.Selenium.Models;

namespace WBS.Selenium.Controllers.FormControllers
{
    public class CreateBudgetDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
            new UIMapper("Название сита", typeof(ComboBoxController), "selectedSite"),
            new UIMapper("Ссылка год", typeof(ButtonLinkYearController), "2018"),
            new UIMapper("Создать", typeof(ButtonCreateRowController), "Создать"),
            new UIMapper("Год", typeof(TextBoxController), "year",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Сохранить", typeof(MuiButtonController), "Сохранить"),
            new UIMapper("Отмена", typeof(MuiButtonController), "Отмена"),
            new UIMapper("Центр результата", typeof(ComboBoxController), "resultCenterId"),
            new UIMapper("Тип инвестиций",typeof(ComboBoxController), "typeOfInvestmentId"),
            new UIMapper("Категория",typeof(ComboBoxController), "categoryOfEquipmentId"),
            new UIMapper("Предмет инвестиций",typeof(TextBoxController), "subjectOfInvestment",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Дата поставки", typeof(DatePickerController), "dateOfDelivery"), // TODO: Реализовать через DatePickerController
            new UIMapper("Количество",typeof(TextBoxController), "count",false,new Dictionary<string, string> { { "type", "input" } }),
            new UIMapper("Цена",typeof(TextBoxController), "price",false,new Dictionary<string, string> { { "type", "input" } }),
        };

        public void SetDate(Context context,string element, string value)
        {
            DatePickerController dp = mapping[element] as DatePickerController;
            dp.SetValueByJs(context, value);
        }
    }
}
