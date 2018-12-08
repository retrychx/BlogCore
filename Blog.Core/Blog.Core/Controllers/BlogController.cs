using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Core.IServices;
using Blog.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog")]
    [Authorize(Policy = "Admin")]
    public class BlogController : Controller
    {
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
            IAdvertisementServices advertisementServices = new AdvertisementServices();
            return advertisementServices.Sum(i, j);
        }

        // GET api/Blog/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Blog
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
