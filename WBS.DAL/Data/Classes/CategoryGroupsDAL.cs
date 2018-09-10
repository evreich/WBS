using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;
using System;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL
{
    public class CategoryGroupsDAL : ICRUD<CategoryGroup>
    {
        ICRUD<CategoryGroup> _categories_groups_crud;

        public CategoryGroupsDAL(GetCRUD getcrud)
        {
            _categories_groups_crud = getcrud(typeof(CategoryGroupsDAL), typeof(CategoryGroup)) as ICRUD<CategoryGroup>;
        }

        public CategoryGroup Create(CategoryGroup item)
        {
            return _categories_groups_crud.Create(item);
        }

        public CategoryGroup Delete(object id)
        {
            return _categories_groups_crud.Delete(id);
        }

        public IEnumerable<CategoryGroup> Get()
        {
            return _categories_groups_crud.Get();
        }

        public CategoryGroup Get(object id)
        {
            return _categories_groups_crud.Get(id); ;
        }

        public CategoryGroup Update(CategoryGroup item)
        {
            return _categories_groups_crud.Update(item);
        }
    }
}
