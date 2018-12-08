using System;
namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 博客文章
    /// </summary>
    public class BlogArticle
    {
        /// <summary>
        /// Gets or sets the b identifier.
        /// </summary>
        /// <value>The b identifier.</value>
        public int bID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        /// <value>The bsubmitter.</value>
        public string bsubmitter { get; set; }

        /// <summary>
        /// 博客标题
        /// </summary>
        /// <value>The btitle.</value>
        public string btitle { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        /// <value>The bcategory.</value>
        public string bcategory { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        /// <value>The bcontent.</value>
        public string bcontent { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        /// <value>The btraffic.</value>
        public int btraffic { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        /// <value>The bcomment number.</value>
        public string bcommentNum { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        /// <value>The b update time.</value>
        public DateTime bUpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The b create time.</value>
        public DateTime bCreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The b remark.</value>
        public string bRemark { get; set; }
    }
}
