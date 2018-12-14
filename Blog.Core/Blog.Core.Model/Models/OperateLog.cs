using System;
namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class OperateLog
    {
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置是否禁用
        /// </summary>
        /// <value>The is deleted.</value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 区域名
        /// </summary>
        /// <value>The area.</value>
        public string Area { get; set; }

        /// <summary>
        /// 区域控制器
        /// </summary>
        /// <value>The controller.</value>
        public string Controller { get; set; }

        /// <summary>
        /// Action名称
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }

        /// <summary>
        /// Ip地址
        /// </summary>
        /// <value>The ip address.</value>
        public string IPAddress { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// 登陆时间
        /// </summary>
        /// <value>The log time.</value>
        public DateTime? LogTime { get; set; }

        /// <summary>
        /// 登陆名称
        /// </summary>
        /// <value>The name of the login.</value>
        public string LoginName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { get; set; }

        public virtual sysUserInfo User { get; set; }
    }
}
