using System.ComponentModel.DataAnnotations;

namespace pruebaMobiles.Entities
{
    public class User
    {
        public int id { get; set; }
        [Required]
        [MinLength(1)]
        public string name {set;get;}
        [Required]
        [MinLength(1)]

        public string password { set; get; }
        public ICollection<Movement> movements { get; set; }

    }


}
