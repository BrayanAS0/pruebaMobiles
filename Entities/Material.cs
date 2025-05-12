using System.ComponentModel.DataAnnotations;

namespace pruebaMobiles.Entities
{
    public class Material
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string description { get; set; }

        [Required]
        public int quantity { get; set; } 

        [Required]
        public int ideal_quantity { get; set; } 

        public ICollection<Movement> movements { get; set; }
    }
}
