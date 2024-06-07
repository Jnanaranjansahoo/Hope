using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Hope.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
