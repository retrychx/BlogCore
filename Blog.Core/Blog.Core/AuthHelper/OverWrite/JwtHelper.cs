using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Core.AuthHelper.OverWrite
{
    /// <summary>
    /// Jwt helper.
    /// </summary>
    public class JwtHelper
    {
        public static string SecretKey { get; set; } = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";

        /// <summary>
        /// 颁发JWT字符串
        /// </summary>
        /// <returns>The jwt.</returns>
        /// <param name="tokenModel">Token model.</param>
        public static string IssueJWT(TokenModelJWT tokenModel)
        {
            var dateTime = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
                new Claim("Role",tokenModel.Role),
                new Claim(JwtRegisteredClaimNames.Iat,dateTime.ToString(),ClaimValueTypes.Integer64)
            };

            //密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "Blog.Core",
                claims: claims,
                expires: dateTime.AddHours(2),
                signingCredentials: creds
            );

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodeJwt = jwtHandler.WriteToken(jwt);

            return encodeJwt;
        }

        public static TokenModelJWT SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(jwtStr);

            var role = new object();

            try
            {
                jwtToken.Payload.TryGetValue("Role", out role);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var tm = new TokenModelJWT
            {
                Uid = Convert.ToInt32(jwtToken.Id),
                Role = role != null ? role.ToString() : ""
            };

            return tm;
        }
    }
}
