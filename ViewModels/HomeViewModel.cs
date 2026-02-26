using Fashion_Blog.Models;

namespace Fashion_Blog.ViewModels
{
    public class HomeViewModel
    {
        public List<Post>? FeaturedPosts { get; set; }
        public List<Post>? RecentPosts { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? PopularTags { get; set; }
    }
}