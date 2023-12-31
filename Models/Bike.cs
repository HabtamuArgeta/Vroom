using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Vroom.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        [Required( ErrorMessage = "Select Make")]
        public int MakeId { get; set; }

        public Model Model { get; set; }

        [Required(ErrorMessage = "Select Model")]
        public int ModelId { get; set; }

        
        [Required(ErrorMessage = "Provide a Date")]
        public DateTime Year { get; set; }

        [Required(ErrorMessage = "Enter Mileage")]
        [Range(1, int.MaxValue, ErrorMessage = "Not with in the valid mileage range")]
        public int Mileage { get; set; }


        public string Features { get; set; }

        [Required(ErrorMessage = "Provide Seller Name")]
        [StringLength(50)]
        public string SellerName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string SellerEmail { get; set; }

        [Required(ErrorMessage = "Provide Phone No.")]
        [Phone]
        [StringLength(15)]
        public string SellerPhone { get; set; }

        [Required(ErrorMessage = "Provide Price")]
        [Range(1, 999999999, ErrorMessage = "Not with in the valid price range")]
        public int Price { get; set; }

        public Currency Currency {  get; set; } 

        [Required (ErrorMessage = "Select Currency")]
        public int CurrencyId { get; set; }

        [Display(Name = "Image File")]

        // this is used to store the image of the motercyle to the server

        [NotMapped]
        [Required]
        public IFormFile Image { get; set; }

        // this is used  to store the path of the MoterCycle to databases 
        public string  ImagePath { get; set; }
    }
}
