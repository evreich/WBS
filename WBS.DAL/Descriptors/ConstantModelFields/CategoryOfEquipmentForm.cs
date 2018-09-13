using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class CategoryOfEquipmentForm
    {
        public (string label, string name) Title { get; private set; }
        public (string label, string name) Code { get; private set; }
        public (string label, string name) DepreciationPeriod { get; private set; }
        public (string label, string name) CategoryGroup { get; private set; }

        public CategoryOfEquipmentForm()
        {
            Title = ("Название", "title");
            Code = ("Код", "code");
            DepreciationPeriod = ("Амортизация, лет.", "depreciationPeriod");
            CategoryGroup = ("Группа категорий", "categoryGroup");
        }
    }
}
