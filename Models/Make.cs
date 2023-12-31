using System.ComponentModel.DataAnnotations;

namespace Vroom.Models
{
    public class Make
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The name of Make is Required.")]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<Model> Model { get; set; }
        public ICollection<Bike> Bike { get; set; }
    }
}
