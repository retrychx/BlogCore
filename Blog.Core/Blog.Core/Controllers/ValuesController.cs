using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// 控制器文字说明
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns>The get.</returns>
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取一个Id的数据
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 向服务器post数据
        /// </summary>
        /// <param name="value">Value.</param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// 向服务器put数据
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="value">Value.</param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 向服务器delete数据
        /// </summary>
        /// <param name="id">Identifier.</param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
