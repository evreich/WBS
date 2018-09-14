namespace WBS.DAL.Data.Models.ViewModels
{
   
    public class CategoriesOfEquipmentViewModel : IViewModel<CategoryOfEquipment>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public double DepreciationPeriod { get; set; }

        public int? CategoryGroupId { get; set; }
        public string CategoryGroupTitle { get; set; }


        public CategoriesOfEquipmentViewModel(CategoryOfEquipment categ)
        {
            Id = categ.Id;
            Title = categ.Title;
            Code = categ.Code;
            DepreciationPeriod = categ.DepreciationPeriod;
            if (categ.CategoryGroup != null) CategoryGroupId = categ.CategoryGroup.Id;
            if (categ.CategoryGroup != null) CategoryGroupTitle = categ.CategoryGroup.Title;
        }

        public CategoriesOfEquipmentViewModel()
        {
        }

        public CategoryOfEquipment CreateModel()
        {
            return new CategoryOfEquipment
            {
                Id = Id,
                Title = Title,
                Code = Code,
                DepreciationPeriod = DepreciationPeriod,
                CategoryGroupId = CategoryGroupId
            };
        }
    }
}
