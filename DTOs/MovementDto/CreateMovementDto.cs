namespace pruebaMobiles.DTOs.MovementDto;
    using System.ComponentModel.DataAnnotations;

public class CreateMovementDto
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        public int MaterialId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int QuantityChanged { get; set; }
    public int RealQuantity { get; set; }

    }

