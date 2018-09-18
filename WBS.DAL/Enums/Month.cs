using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WBS.DAL.Enums
{
    public enum Month
    {
        [DisplayName("Январь")]
        Janiary = 1,
        [DisplayName("Февраль")]
        Febriary = 2,
        [DisplayName("Март")]
        March = 3,
        [DisplayName("Апрель")]
        April = 4,
        [DisplayName("Май")]
        May = 5,
        [DisplayName("Июнь")]
        June = 6,
        [DisplayName("Июль")]
        July = 7,
        [DisplayName("Август")]
        August = 8,
        [DisplayName("Сентябрь")]
        September = 9,
        [DisplayName("Октябрь")]
        October = 10,
        [DisplayName("Ноябрь")]
        November = 11,
        [DisplayName("Декабрь")]
        December = 12
    }
}
