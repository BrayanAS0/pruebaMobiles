using System.ComponentModel.DataAnnotations;

public class Material
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public int Quantity { get; set; }



    public ICollection<Movement> Movements { get; set; }
}
