using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBS.Selenium.Interfaces
{
    interface IUIValidationController
    {
        bool IsVisible();
        bool IsEnabled();
        void WaitVisible();
        void WaitEnabled();
    }
}
