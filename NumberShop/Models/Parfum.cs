using System.ComponentModel.DataAnnotations;

namespace NumberShop.Models
{
    public class Parfum
    {
        [Key]
        public int ParfumId { get; set; }
        public string nom { get; set; }
        public float prix { get; set; }
        public string description { get; set; }

         public string Categorie { get; set; }

        
    }
}
