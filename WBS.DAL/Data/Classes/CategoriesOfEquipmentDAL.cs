using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL
{
    public class ExtensionDALIQueryableCategoryOfEquipment : IExtensionDALIQueryable<CategoryOfEquipment>
    {
        public IQueryable<CategoryOfEquipment> GetItems(IQueryable<CategoryOfEquipment> query)
        {
            return query.Include(b => b.CategoryGroup);
        }
    }

    public class CategoriesOfEquipmentDAL : ICRUD<CategoryOfEquipment>
    {
        ICRUD<CategoryOfEquipment> _categories_of_equipment_crud;

        public CategoriesOfEquipmentDAL(GetCRUD getcrud)
        {
            _categories_of_equipment_crud = getcrud(typeof(CategoriesOfEquipmentDAL), typeof(CategoryOfEquipment)) as ICRUD<CategoryOfEquipment>;
        }

        public CategoryOfEquipment Create(CategoryOfEquipment item)
        {
            return _categories_of_equipment_crud.Create(item);
        }

        public CategoryOfEquipment Delete(object id)
        {
            return _categories_of_equipment_crud.Delete(id);
        }

        public IEnumerable<CategoryOfEquipment> Get()
        {
            return _categories_of_equipment_crud.Get();
        }

        public CategoryOfEquipment Get(object id)
        {
            return _categories_of_equipment_crud.Get(id);
        }

        public CategoryOfEquipment Update(CategoryOfEquipment item)
        {
            return _categories_of_equipment_crud.Update(item);
        }
    }
}
