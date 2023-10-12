using System.ComponentModel.DataAnnotations;

namespace CatalogService.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //URL
        public string Image { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }
    }
}
