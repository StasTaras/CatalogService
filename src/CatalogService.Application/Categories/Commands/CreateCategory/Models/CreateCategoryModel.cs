namespace CatalogService.Application.Categories.Commands.CreateCategory.Models
{
    public class CreateCategoryModel
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
