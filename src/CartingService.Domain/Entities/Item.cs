using System.ComponentModel.DataAnnotations;

namespace CatalogService.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
