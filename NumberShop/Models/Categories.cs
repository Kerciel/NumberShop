using System.ComponentModel.DataAnnotations;

namespace NumberShop.Models
{
    public class Categories
    {
        [Key]
        public int IdCategorie { get; set; }

        public string CategorieName { get; set; }

        
    }
}
