using System.ComponentModel.DataAnnotations;

namespace CatalogService.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public List<Item> Items { get; set; }
    }
}
