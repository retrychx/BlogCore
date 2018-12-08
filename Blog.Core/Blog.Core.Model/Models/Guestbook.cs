using System;
namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 留言区
    /// </summary>
    public class Guestbook
    {
        /// <summary>
        /// 留言表
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }

        /// <summary>
        /// 博客id
        /// </summary>
        /// <value>The blog identifier.</value>
        public int? blogId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The createdate.</value>
        public DateTime createdate { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        /// <value>The username.</value>
        public string username { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        /// <value>The qq.</value>
        public string QQ { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        /// <value>The body.</value>
        public string body { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        /// <value>The ip.</value>
        public string ip { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value>The phone.</value>
        public string phone { get; set; }

        /// <summary>
        /// 是否显示在前台，0否1是
        /// </summary>
        /// <value><c>true</c> if isshow; otherwise, <c>false</c>.</value>
        public bool isshow { get; set; }

        /// <summary>
        /// 博客文章
        /// </summary>
        /// <value>The blog article.</value>
        public BlogArticle blogArticle { get; set; }
    }
}
