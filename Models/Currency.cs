using System.ComponentModel.DataAnnotations;

namespace Vroom.Models
{
    public class Currency
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name of the Currency is required.")]
        public string Name { get; set; }
        public ICollection<Bike> Bike { get; set; }
    }
}
