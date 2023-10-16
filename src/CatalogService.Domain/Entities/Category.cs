namespace CatalogService.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; } = null!;

        public List<Item> Items { get; set; } = null!;
    }
}
