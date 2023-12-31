using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vroom.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Home phone ")]
        public string PhoneNumber2 { get; set; }

        [NotMapped]
        public bool IsAdmin { get; set; }


    }
}



