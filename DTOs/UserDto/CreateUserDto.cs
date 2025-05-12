using System.ComponentModel.DataAnnotations;

namespace pruebaMobiles.DTOs.UserDto
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(1)]
        
        public  required string name { get; set; }
        [Required]
        [MinLength(1)]

        public required string password { get; set; }
    }
}
