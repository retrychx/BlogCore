using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.Core.AuthHelper.OverWrite
{
    /// <summary>
    /// Jwt token auth.
    /// </summary>
    public class JwtTokenAuth
    {
        /// <summary>
        /// The next.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Blog.Core.AuthHelper.OverWrite.JwtTokenAuth"/> class.
        /// </summary>
        public JwtTokenAuth(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if(!httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                return next(httpContext);
            }

            var tokenHeader = httpContext.Request.Headers["Authorization"].ToString();
            var tm = JwtHelper.SerializeJWT(tokenHeader);

            var claimList = new List<Claim>();
            var claim = new Claim(ClaimTypes.Role, tm.Role);
            claimList.Add(claim);

            var identity = new ClaimsIdentity(claimList);
            var principal = new ClaimsPrincipal(identity);

            httpContext.User = principal;

            return next(httpContext);
        }
    }
}
