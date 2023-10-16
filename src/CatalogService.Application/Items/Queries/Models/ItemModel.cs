
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Items.Queries.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public Category Category { get; set; } = null!;

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
