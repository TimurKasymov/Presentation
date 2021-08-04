using Community2._0.BLL.Abstract;
using Community2._0.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Community20.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private IService<PostEntity> _postService;
        private IWebHostEnvironment _environment;
        private IService<AccountEntity> _account;
        public PostController(IService<PostEntity> service, IWebHostEnvironment appEnvironment,
         IService<AccountEntity> account)
        {
            _postService = service;
            _environment = appEnvironment;
            _account = account;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] PostFetchEntity postEntity)
        {
            try
            {
                var path = "/img/" + postEntity.Picture.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await postEntity.Picture.CopyToAsync(fileStream);
                }
                var post = new PostEntity()
                {
                    Title = postEntity.Title,
                    Text = postEntity.Text,
                    Likes = postEntity.Likes,
                    Picture = path
                };
                var account = _account.Get(postEntity.Email, postEntity.Password, true);
                account.Posts.Add(post);
                await _postService.Create(post);
                await _account.Update(account);
                return new JsonResult(new { message = "Успешно" });
            }
            catch
            {
                return new JsonResult(new { message = "Ошибка" });
            }
        }
        [HttpGet("fetchAll")]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllNOTracking();
            return new JsonResult(new { posts = posts });
        }
        [HttpPost("like")]
        public async Task<IActionResult> GetAllPosts(Like likeEntity)
        {
            try
            {
                var post = _postService.Get(likeEntity.Id);
			    post.Likes = likeEntity.Likes;
                await _postService.Update(post);
                return new JsonResult(new { message = "Успешно" });
            }
            catch
            {
                return new JsonResult(new { message = "Ошибка" });
            }
        }
    }
}
