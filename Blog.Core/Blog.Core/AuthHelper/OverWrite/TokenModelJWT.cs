using System;
namespace Blog.Core.AuthHelper.OverWrite
{
    /// <summary>
    /// Token model jwt.
    /// </summary>
    public class TokenModelJWT
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <value>The uid.</value>
        public long Uid { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        /// <summary>
        /// 职能
        /// </summary>
        /// <value>The work.</value>
        public string Work { get; set; }
    }
}
