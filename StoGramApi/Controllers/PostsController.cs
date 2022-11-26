using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StoGramApi.Data;
using StoGramApi.Models;

namespace StoGramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private IPostRepo postRepository;
        public PostsController(IPostRepo repo)
        {
            postRepository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostModel>> GetLastPosts()
        {
            return Ok(postRepository.GetLastPosts());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PostModel>> GetLastPostsFromId(int id)
        {
            return Ok(postRepository.GetPostsStartedFromId(id));
        }

        [HttpGet("my/{userName}")]
        public ActionResult<IEnumerable<PostModel>> GetPostsByName(string userName)
        {
            return Ok(postRepository.GetPostsByName(userName));
        }

        [HttpPost]
        public ActionResult<PostModel> CreatePost(PostModel createPost)
        {
            return Ok(postRepository.CreatePost(createPost.UserName, createPost.ImageBytes));
        }

        [HttpGet("like/{id}")]
        public ActionResult<PostModel> LikePost(int id)
        {
            return Ok(postRepository.LikePostById(id));
        }
    }
}
