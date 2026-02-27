using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fashion_Blog.Models;
using Fashion_Blog.ViewModels;

namespace Fashion_Blog.Controllers;

public class HomeController : Controller
{
    //simulating data retrieval

    private List<Post> GetPosts()
    {
        return new List<Post>
        {
            new Post
            {
                Id = 1,
                Title = "Winter Fashion Trends 2026",
                Excerpt = "Discover the latest winter trends that will ensure to keep you stylish...",
                Content = "Full content here...",
                FeaturedImageUrl = "/images/winter1.jpg",
                PublishedDate = DateTime.Now.AddDays(-5),
                Slug = "winter-fashion-trends-2026",
                Category = new Category { Id = 1, Name = "Trends", Slug = "trends"},
                Author = new Author { DisplayName = "Raven Lockewood", AvatarUrl = "/images/avatar-default.png"}
            },

            new Post
            {
                Id = 2,
                Title = "Vintage Fashion Revival",
                Excerpt = "Vintage fashion is making a comeback in 2026! Explore how to style these pieces, giving them a modern edge.",
                Content = " Full content here...",
                FeaturedImageUrl = "/images/vintage1.jpg",
                PublishedDate = DateTime.Now.AddDays(-10),
                Slug = "vintage-fashion-revival",
                Category = new Category {Id = 2, Name = "Style Guides", Slug = "style-guides"},
                Author = new Author {DisplayName = "Cleo Pillay", AvatarUrl = "/images/avatar-default.png"}
            },

            new Post
            {
                Id = 3,
                Title = "Summer Trends: Flannel never goes out of style",
                Excerpt = "The forever stylish flannel makes a comeback this summer! Discover numerous ways to style this piece for fun and comfort.",
                Content = "Full content here...",
                FeaturedImageUrl = "/images/summer1.jpg",
                PublishedDate = DateTime.Now.AddDays(-15),
                Slug = "summer-trends-flannel",
                Category = new Category {Id = 3, Name = "Seasonal trends", Slug = "seasonal-trends"},
                Author = new Author {DisplayName = "Dean Winchester", AvatarUrl = "/images/avatar-default.png"}
            }
        };
    }
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
