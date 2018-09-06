using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Models;

namespace WBS.DAL.Descriptors
{
    public class CategoryGroupsDescriptor : Descriptor
    {
        const string titleName = "title";
        [FieldName(Name = titleName)]
        private readonly FieldInfo _title;

        const string codeName = "code";
        [FieldName(Name = codeName)]
        private readonly FieldInfo _code;

        public CategoryGroupsDescriptor(
            //BudgetPlanDAL dal, 
            object typeID,
            List<string> roles
            ) : base(
                //dal, 
                typeID,
                roles
                )
        {
            if (!CanAccessToObject())
                throw new TypeAccessException();

            _title = new FieldInfo("Название", titleName, true, CanEditField(titleName));
            _code = new FieldInfo("Код", codeName, true, CanEditField(codeName));
        }
    }
}