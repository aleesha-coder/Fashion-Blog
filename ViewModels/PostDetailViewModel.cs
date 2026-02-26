using Fashion_Blog.Models;

namespace Fashion_Blog.ViewModels
{
    public class PostDetailViewModel
    {
        public Post? Post { get; set; }
        public List<Comment>? Comments { get; set;}
        public Comment? NewComment { get; set;}
        public List<Post>? RelatedPosts { get; set; }
    }
}