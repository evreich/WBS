using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Interfaces
{
    public interface IFormValidationController
    {
        bool CheckElementIsEnabled(string element);
        bool CheckElementIsVisible(string element);
        void WaitElementIsEnabled(string element);
        void WaitElementIsVisible(string element);
    }
}
