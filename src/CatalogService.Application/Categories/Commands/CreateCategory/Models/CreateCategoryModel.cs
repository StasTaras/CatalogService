namespace CatalogService.Application.Categories.Commands.CreateCategory.Models
{
    public class CreateCategoryModel
    {
        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int? ParentCategoryId { get; set; }
    }
}
