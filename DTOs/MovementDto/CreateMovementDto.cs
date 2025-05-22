namespace pruebaMobiles.DTOs.MovementDto;
    using System.ComponentModel.DataAnnotations;

public class CreateMovementDto
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int QuantityChanged { get; set; }

        public string Notes { get; set; }
    }

