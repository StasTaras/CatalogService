
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Items.Queries.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        
        public Category Category { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
