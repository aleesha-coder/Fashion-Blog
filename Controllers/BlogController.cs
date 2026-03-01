using Microsoft.AspNetCore.Mvc;
using Fashion_Blog.Models;
using Fashion_Blog.ViewModels;
using System.Runtime.CompilerServices;

namespace Fashion_Blog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index(int? page, string category, string tag, string search)
        {
            int pageSize = 6; // number of posts per page
            int pageNumber = page ?? 1; // default to page 1

            var posts = GetPosts(); // retrieve all posts

            // applying filters
            if (!string.IsNullOrEmpty(category))
            {
                posts = posts.Where(page => page.Category?.Slug == category).ToList();
                ViewBag.CurrentCategory = category;
            }

            if (!string.IsNullOrEmpty(tag))
            {
                ViewBag.CurrentTag = tag; // filter by tag
            }

            if (!string.IsNullOrEmpty(search))
            {
                posts = posts.Where(p => (p.Title?.Contains(search) ?? false) || (p.Content?.Contains(search) ?? false)).ToList();
                ViewBag.CurrentSearch = search; // filter by search terms
            }

            // pagination
            var totalPosts = posts.Count();
            var totalPages = (int)Math.Ceiling((double)totalPosts / pageSize);
            var paginatedPosts = posts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = pageNumber > 1;
            ViewBag.HasNextPage = pageNumber < totalPages;

            return View(paginatedPosts);

            
        }

        public IActionResult Post(string slug)
        {
            var post = GetPosts().FirstOrDefault(post => post.Slug == slug);

            if (post == null)
            {
                return NotFound();
            }

            var ViewModel = new PostDetailViewModel
            {
                Post = post,
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        AuthorName = "Victoria Addams",
                        Content = "Wonderful post! Loved the insights on these trends",
                        CreatedAt = DateTime.Now.AddDays(-2),
                        IsApproved = true
                    }
                },

                NewComment = new Comment(),
                RelatedPosts = GetPosts().Take(3).ToList()
            }; 

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int postId, Comment comment)
        {
            if(ModelState.IsValid)
            {
                comment.PostId = postId;
                comment.CreatedAt = DateTime.Now;
                comment.IsApproved = false; // new comments need admin approval

                var postSlug = GetPostSlug(postId);
                if (postSlug == null)
                {
                    TempData["Error"] = "Post not found.";
                    return RedirectToAction("Index");
                }

                // logic for comments to be saved (at a later stage into a database)

                TempData["Success"] = "Your comment has been submitted and is awaiting approval.";
                return RedirectToAction("Post", new {slug = postSlug});
            }

            // handling of invalid model state
            TempData["Error"] = "Please fill in all the required fields correctly.";
            return RedirectToAction("Post", new {id = postId});


        }

        private string? GetPostSlug(int postId)
        {
            return GetPosts().FirstOrDefault(p => p.Id == postId)?.Slug;
        }

        private List<Post> GetPosts()
        {
            return new List<Post>

            // same posts as in HomeController (expanded for demonstration purposes)
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
    }
}

