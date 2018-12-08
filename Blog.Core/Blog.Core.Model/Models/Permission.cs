using System;
using System.Collections.Generic;

namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 按钮表
    /// </summary>
    public class Permission
    {
        public Permission()
        {
            ModulePermissions = new List<ModulePermission>();
            RoleModulePermissions = new List<RoleModulePermission>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 获取或设置是否删除
        /// </summary>
        /// <value>The is deleted.</value>
        public bool? IsDeleted { get; set; }

        //菜单执行Action名
        public string Code { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value>The order sort.</value>
        public int OrderSort { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        /// <value>The icon.</value>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单描述
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }

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

        public virtual ICollection<ModulePermission> ModulePermissions { get; set; }

        public virtual ICollection<RoleModulePermission> RoleModulePermissions { get; set; }
    }
}
