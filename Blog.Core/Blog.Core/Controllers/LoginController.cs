using System;
using Blog.Core.AuthHelper.OverWrite;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// Login controller.
    /// </summary>
    public class LoginController : Controller
    {  
        /// <summary>
        /// Gets the jwt string.
        /// </summary>
        /// <returns>The jwt string.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="sub">Sub.</param>
        [HttpGet]
        [Route("Token2")]
        public JsonResult GetJwtStr(long id = 1, string sub = "Admin")
        {
            TokenModelJWT tm = new TokenModelJWT
            {
                Uid = id,
                Role = sub
            };

            var jwtStr = JwtHelper.IssueJWT(tm);

            var result = Json(jwtStr);
            return result;
        }
    }
}
