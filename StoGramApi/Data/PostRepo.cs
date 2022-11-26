using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoGramApi.Contexts;
using StoGramApi.Models;

namespace StoGramApi.Data
{
    public class PostRepo : IPostRepo
    {
        private UserDbContext postContext;

        public PostRepo(UserDbContext context)
        {
            postContext = context;
        }

        public PostModel CreatePost(string userName, string imageBytes)
        {
            var newPost = new PostModel()
            {
                UserName = userName,
                ImageBytes = imageBytes
            };

            postContext.Posts.Add(newPost);
            postContext.SaveChanges();

            return newPost;
        }

        public IEnumerable<PostModel> GetLastPosts()
        {
            if (postContext.Posts.Count() <= 25)
            {
                return postContext.Posts;
            }
            else
            {
                return GetPostsStartedFromId(postContext.Posts.Count() - 25);
            }
        }

        public IEnumerable<PostModel> GetPostsStartedFromId(int id)
        {
            var postsFrom = from post in postContext.Posts
                where post.Id >= id
                select post;

            return postsFrom;
        }

        public IEnumerable<PostModel> GetPostsByName(string userName)
        {
            var postsByName = from post in postContext.Posts
                where post.UserName.Equals(userName)
                select post;

            return postsByName;
        }

        public PostModel LikePostById(int id)
        {
            var postLike = from post in postContext.Posts
                where post.Id == id
                select post;

            var likedpost = postLike.First();
            likedpost.Likes++;

            postContext.Posts.Update(likedpost);
            postContext.SaveChanges();

            return likedpost;
        }
    }
}
