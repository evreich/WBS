using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Models
{
    public class UIMapper
    {
        public string Field { get; }
        public Type ControllerType { get; }
        public string ControllerId { get; }
        public bool WaitPostback { get; }
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
