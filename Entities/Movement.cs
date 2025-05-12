using pruebaMobiles.Migrations;
using System.ComponentModel.DataAnnotations;

namespace pruebaMobiles.Entities
{
    public class Movement
    {
        public int id { get; set; }

        [Required]
        public int user_id { get; set; }
        public User user { get; set; }

        [Required]
        public int material_id { get; set; }
        public Material material { get; set; }

        [Required]
        public DateTime date { get; set; } = DateTime.Now;

        [Required]
        public int quantity_changed { get; set; } 

        public string notes { get; set; }
    }
}
