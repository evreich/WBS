using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Interfaces
{
    public interface IFormController
    {
        void Initialize(Context context);
        void ClickElement(string element);
        void MoveToElement(string element);
        void SetElementValue(string element, string value);
        string GetElementValue(string element);
    }
}
