using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using Blog.Core.Common.Helper;
using Blog.Core.Common.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Core.Controllers
{
    /// <summary>
    /// Blog controller.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Blog")]
    //[Authorize(Policy = "Admin")]
    public class BlogController : Controller
    {
        IAdvertisementServices advertisementServices;
        IBlogArticleServices blogArticleServices;
        IRedisCacheManager redisCacheManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Blog.Core.Controllers.BlogController"/> class.
        /// </summary>
        /// <param name="advertisementServices">Advertisement services.</param>
        /// <param name="blogArticleServices">BlogArticle services.</param>
        public BlogController(IAdvertisementServices advertisementServices,
            IBlogArticleServices blogArticleServices,
            IRedisCacheManager redisCacheManager)
        {
            this.advertisementServices = advertisementServices;
            this.blogArticleServices = blogArticleServices;
            this.redisCacheManager = redisCacheManager;
        }

        // GET: api/Blog
        /// <summary>
        /// Sum接口
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="i">The index.</param>
        /// <param name="j">J.</param>
        [HttpGet]
        public int Get(int i,int j)
        {
            return i + j;
        }

        /// <summary>
        /// Get the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        // GET api/Blog/5
        //[HttpGet("{id}",Name = "Get")]
        //public async Task<List<Advertisement>> Get(int id)
        //{
        //    return await advertisementServices.Query(d => d.Id == id);
        //}

        [HttpGet("{id}",Name = "Get")]
        public async Task<object> Get(int id)
        {
            var model = await blogArticleServices.GetBlogDetails(id);
            var data = new { success = true, data = model };

            return data;
        }

        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns>The blogs.</returns>
        [HttpGet]
        [Route("GetBlogs")]
        public async Task<List<BlogArticle>> GetBlogs()
        {
            var connect = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });

            var blogArticleList = new List<BlogArticle>();

            if (redisCacheManager.Get<object>("Redis.Blog") != null)
            {
                blogArticleList = redisCacheManager.Get<List<BlogArticle>>("Redis.Blog");
            }
            else
            {
                blogArticleList = await blogArticleServices.Query(s => s.bID > 5);
                redisCacheManager.Set("Redis.Blog", blogArticleList, TimeSpan.FromHours(2));
            }

            return blogArticleList;
        }

        /// <summary>
        /// Post the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        // POST api/Blog
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Put the specified id and value.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="value">Value.</param>
        // PUT api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete the specified id.
        /// </summary>
        /// <param name="id">Identifier.</param>
        // DELETE api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
