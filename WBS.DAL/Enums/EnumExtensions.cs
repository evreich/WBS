using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WBS.DAL.Enums
{
    public static class EnumExtensions
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            Type genericEnumType = enumType.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumType.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var attrubutes = memberInfo[0].GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if ((attrubutes != null && attrubutes.Count() > 0))
                {
                    return ((DisplayNameAttribute)attrubutes.ElementAt(0)).DisplayName;
                }
            }
            return enumType.ToString();
        }
    }
}
