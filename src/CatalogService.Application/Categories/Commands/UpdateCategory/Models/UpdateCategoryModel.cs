namespace CatalogService.Application.Categories.Commands.UpdateCategory.Models
{
    public class UpdateCategoryModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
