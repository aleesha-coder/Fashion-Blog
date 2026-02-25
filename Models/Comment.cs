using System.ComponentModel.DataAnnotations;

namespace Fashion_Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Your Name")]
        public string? AuthorName { get; set; }

        [EmailAddress]
        [Display(Name = "Your Email")] 
        public string? AuthorEmail { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsApproved { get; set; }

        public int PostId { get; set;}

        public virtual Post? Post { get; set; }
    }
}