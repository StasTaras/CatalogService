namespace CatalogService.Application.Items.Commands.CreateItem.Models
{
    public class CreateItemModel
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
