using Auth.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Services.Interfaces
{
    public interface IPostRepository
    {
        void AddPost(Post p);
        Post GetPost(int id);

        void DeletePost(int id);

        IQueryable<Post> GetPosts();
        IQueryable<Post> GetPosts(int blogId);

        void UpdatePost(Post p);
    }
}
