using System;
namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 菜单与按钮关系表
    /// </summary>
    public class ModulePermission
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// 获取或这只是否禁用
        /// </summary>
        /// <value>The is deleted.</value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        /// <value>The module identifier.</value>
        public int ModuleId { get; set; }

        /// <summary>
        /// 按钮ID
        /// </summary>
        /// <value>The permission identifier.</value>
        public int PermissionId { get; set; }

        /// <summary>
        /// 创建ID
        /// </summary>
        /// <value>The create identifier.</value>
        public int? CreateId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        /// <value>The create by.</value>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>The create time.</value>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改ID
        /// </summary>
        /// <value>The modify identifier.</value>
        public int? ModifyId { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        /// <value>The modify by.</value>
        public string ModifyBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        /// <value>The modify time.</value>
        public DateTime? ModifyTime { get; set; }

        public virtual Module Module { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
