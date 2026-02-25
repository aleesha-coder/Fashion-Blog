using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Fashion_Blog.Models
{
public class Post
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string? Title { get; set; }

    [Required]
    public string? Content { get; set; }

    [StringLength(500)]
    public string? Excerpt { get; set; }

    [Display(Name = "Featured Image")]
    public string? FeaturedImageUrl { get; set; }

    [Display(Name = "Published Date")]
    public DateTime PublishedDate { get; set; }

    [Display(Name = "Last Modified")]
    public DateTime? LastModified { get; set; }

    public bool IsPublished { get; set; }

    public string? Slug { get; set; }

    // foreign keys
    public int AuthorId { get; set; }
    public int? CategoryId { get; set; }

    // navigation properties
    public virtual Category? Category { get; set; }
    public virtual Author? Author { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Tag>? Tags { get; set; }
}

}

