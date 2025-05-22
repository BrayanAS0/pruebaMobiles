using System.ComponentModel.DataAnnotations;

public class Movement
{
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public int MaterialId { get; set; }
    public Material Material { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Now;

    [Required]
    public int QuantityChanged { get; set; }

}
