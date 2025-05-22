namespace pruebaMobiles.DTOs.MaterialDto;

    using System.ComponentModel.DataAnnotations;

    public class CreateMaterialDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int IdealQuantity { get; set; }
    }

