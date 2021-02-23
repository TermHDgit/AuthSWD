using Auth.Data;
using Auth.Models.Domain;
using Auth.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Services.Repositories
{
    public class PostsRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        public PostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddPost(Post p)
        {
            _context.Posts.Add(p);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            _context.Posts.Remove(GetPost(id));
        }

        public Post GetPost(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.PostId == id);
        }

        public IQueryable<Post> GetPosts()
        {
            return _context.Posts;
        }

        public IQueryable<Post> GetPosts(int blogId)
        {
            return GetPosts().Where(x => x.BlogId == blogId);
        }

        public void UpdatePost(Post p)
        {
            var originalPost = GetPost(p.PostId);
            originalPost.Content = p.Content;
            originalPost.Title = p.Title;
            originalPost.BlogId = p.BlogId;
            _context.SaveChanges();
        }
    }
}
