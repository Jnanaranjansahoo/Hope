using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hope.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
