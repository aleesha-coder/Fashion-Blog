using System.ComponentModel.DataAnnotations;

namespace Fashion_Blog.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        public string? Slug { get; set;}

        public virtual ICollection<Post>? Posts { get; set; }
    }
}