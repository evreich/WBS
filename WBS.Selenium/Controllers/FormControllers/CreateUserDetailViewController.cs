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
    public class CreateUserDetailViewController : FormController
    {
        public override List<UIMapper> Map => new List<UIMapper>
        {
             new UIMapper("ФИО", typeof(TextBoxController), "fio",false,new Dictionary<string, string> { { "type", "textarea" } }),
             new UIMapper("Логин", typeof(TextBoxController), "login",false,new Dictionary<string, string> { { "type", "input" } }),
             new UIMapper("Должность", typeof(TextBoxController), "jobPosition",false,new Dictionary<string, string> { { "type", "textarea" } }),
             new UIMapper("Подразделение", typeof(TextBoxController), "department",false,new Dictionary<string, string> { { "type", "textarea" } }),
             new UIMapper("Пароль", typeof(TextBoxController), "password",false,new Dictionary<string, string> { { "type", "input" } }),
             new UIMapper("Полномочия",typeof(CheckComboBoxController),"roles"),
             //buttons
             new UIMapper("Сохранить",typeof(MuiButtonController),"Сохранить"),
             new UIMapper("Отмена",typeof(MuiButtonController),"Отмена"),
             
        };

        public void SetListValues(string element,params string[] values)
        {
            CheckComboBoxController comboBox = mapping[element] as CheckComboBoxController;
            comboBox?.SetListValues(values);
        }
    }
}
