using System;
using System.Collections.Generic;

namespace Blog.Core.Model.Models
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Module
    {
        public Module()
        {
            ChildModules = new List<Module>();
            ModulePermissions = new List<ModulePermission>();
            RoleModulePermissions = new List<RoleModulePermission>();
        }

        /// <summary>
        /// Id
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置是否禁用，逻辑上的删除
        /// </summary>
        /// <value>The is deleted.</value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// 菜单链接地址
        /// </summary>
        /// <value>The link URL.</value>
        public string LinkUrl { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        /// <value>The area.</value>
        public string Area { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        /// <value>The controller.</value>
        public string Controller { get; set; }

        /// <summary>
        /// Action名称
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        /// <value>The icon.</value>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value>The order sort.</value>
        public int OrderSort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// 是否为右侧菜单
        /// </summary>
        /// <value><c>true</c> if is menu; otherwise, <c>false</c>.</value>
        public bool IsMenu { get; set; }

        /// <summary>
        /// 是否激活
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
        public string CreateTime { get; set; }

        /// <summary>
        /// 修改Id
        /// </summary>
        /// <value>The modify identifier.</value>
        public int? ModifyId { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        /// <value>The modifiy by.</value>
        public string ModifiyBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        /// <value>The modify time.</value>
        public DateTime? ModifyTime { get; set; }

        public virtual Module ParentModule { get; set; }

        public virtual ICollection<Module> ChildModules { get; set; }

        public virtual ICollection<ModulePermission> ModulePermissions { get; set; }

        public virtual ICollection<RoleModulePermission> RoleModulePermissions { get; set; }
    }
}
