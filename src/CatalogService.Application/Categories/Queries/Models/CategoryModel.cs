namespace CatalogService.Application.Categories.Queries.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }
}
