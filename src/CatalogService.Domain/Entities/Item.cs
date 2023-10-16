
namespace CatalogService.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
