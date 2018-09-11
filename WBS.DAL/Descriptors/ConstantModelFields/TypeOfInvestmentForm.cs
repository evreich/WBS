using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    class TypeOfInvestmentForm
    {
        public (string label, string name) Title { get; private set; }
        public (string label, string name) Code { get; private set; }
        public (string label, string name) ExternalCode { get; private set; }

        public TypeOfInvestmentForm()
        {
            Title = ("Название", "title");
            Code = ("Код", "code");
            ExternalCode = ("Внешний код", "externalCode");
        }
    }


}
