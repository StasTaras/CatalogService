namespace CatalogService.Application.Categories.Commands.UpdateCategory.Models
{
    public class UpdateCategoryModel
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }
}
