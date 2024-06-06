using System.ComponentModel.DataAnnotations;

namespace Hope.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
