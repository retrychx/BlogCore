using System;
namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 广告
    /// </summary>
    public class Advertisement
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The create date.</value>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 广告图片
        /// </summary>
        /// <value>The image URL.</value>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 广告标题
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// 广告链接
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        /// <value>The remark.</value>
        public string Remark { get; set; }
    }
}
