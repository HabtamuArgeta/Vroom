using System.ComponentModel.DataAnnotations;

namespace Vroom.Models
{
    public class Model
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name of the model is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        public Make Make { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Make")]
        public int  MakeId { get; set; }
        public ICollection<Bike> Bike { get; set; }


    }
}
