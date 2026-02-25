using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Fashion_Blog.Models
{

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(200)]
    public string? Description { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<Post>? Posts { get; set; }


}

}