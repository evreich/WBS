using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Models
{
    /// <summary>
    ///  Класс UIMapper
    ///  является уникальным описанием для каждого элемента на форме
    /// </summary>
    public class UIMapper
    {
        //название поля, по нему обращаются к элементу
        public string Field { get; }
        //тип контролера
        public Type ControllerType { get; }
        //ид контроллера, именно по нему отличаются контролеры на форме между собой
        public string ControllerId { get; }
        //дополнительное ожидание 
        public bool WaitPostback { get; }
        //дополнительные параметры для построения локатора
        public Dictionary<string, string> Parameters { get; }

        public UIMapper(string field, Type controllerType, string controllerId, bool waitPostback = false, Dictionary<string, string> parameters = null)
        {
            Field = field;
            ControllerId = controllerId;
            ControllerType = controllerType;
            Parameters = parameters;
            WaitPostback = waitPostback;
        }
    }
}
