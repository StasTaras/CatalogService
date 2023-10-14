namespace CatalogService.Application.Items.Commands.CreateItem.Models
{
    public class CreateItemModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}
