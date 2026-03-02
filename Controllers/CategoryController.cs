using Fashion_Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_Blog.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Category>
            {
                new Category {Id = 1, Name = "Trends", Slug = "trends"},
                new Category {Id = 2, Name = "Style Guides", Slug = "style-guides"},
                new Category {Id = 3, Name = "Seasonal trends", Slug = "seasonal-trends"}
            };

            return View(categories);
        }

        public IActionResult Details(string slug, int? page)
        {
            var category = new Category {Id = 1, Name = "Trends", Slug = slug};
            var posts = GetPostsByCategory(slug);

            ViewBag.Category = category;
            return View(posts);
        }

        private List<Post> GetPostsByCategory(string slug)
        {
            // simulate fetching posts by category

            return new List<Post>();
        }
    }
}