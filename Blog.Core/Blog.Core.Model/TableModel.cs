using System;
using System.Collections.Generic;

namespace Blog.Core.Model
{
    /// <summary>
    /// 表格数据，支持分页
    /// </summary>
    public class TableModel<T>
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        /// <value>The code.</value>
        public int Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <value>The message.</value>
        public string Msg { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }

        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <value>The data.</value>
        public List<T> Data { get; set; }
    }
}
