using System.ComponentModel.DataAnnotations;

namespace Fashion_Blog.Models

{
    public class Author
{
    public string? Id { get; set; }

    [Required]
    [Display(Name = "Display Name")]
    public string? DisplayName { get; set;}
     
    [EmailAddress]
    public string? Email { get; set; }

    public string? Bio { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Post>? Posts { get; set;} 
}

}