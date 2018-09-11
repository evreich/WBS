using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class CategoryGroupsForm
    {
        public (string label, string name) Title { get; private set; }
        public (string label, string name) Code { get; private set; }

        public CategoryGroupsForm()
        {
            Title = ("Название", "title");
            Code = ("Код", "code");
        }
    }
