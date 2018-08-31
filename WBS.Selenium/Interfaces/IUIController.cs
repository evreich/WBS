using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Interfaces
{
    public interface IUIController
    {
        void Initialize(Context context, string id, bool waitPostback = false, Dictionary<string, string> parameters = null);
        void Click();
        void Focus();
        string GetValue();
        void SetValue(string value);
        void WaitVisible();
        
    }
}
