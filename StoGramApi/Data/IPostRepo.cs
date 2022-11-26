using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoGramApi.Models;

namespace StoGramApi.Data
{
    public interface IPostRepo
    {
        PostModel CreatePost(string userName, string imageBytes);
        IEnumerable<PostModel> GetLastPosts();
        IEnumerable<PostModel> GetPostsStartedFromId(int id);
        IEnumerable<PostModel> GetPostsByName(string userName);
        PostModel LikePostById(int id);
    }
}