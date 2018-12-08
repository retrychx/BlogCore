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
        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        /// <value>The secret key.</value>
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

            //var claims = new Claim[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            //    new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
            //    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
            //    new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(100)).ToUnixTimeSeconds()}"),
            //    new Claim(JwtRegisteredClaimNames.Iss,"Blog.Core"),
            //    new Claim(JwtRegisteredClaimNames.Aud,"wr"),
            //    new Claim(ClaimTypes.Role,tokenModel.Role)
            //}

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

        /// <summary>
        /// Serializes the jwt.
        /// </summary>
        /// <returns>The jwt.</returns>
        /// <param name="jwtStr">Jwt string.</param>
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
