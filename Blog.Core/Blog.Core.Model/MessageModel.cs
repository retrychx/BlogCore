using System;
using System.Collections.Generic;

namespace Blog.Core.Model
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <value>The message.</value>
        public string Msg { get; set; }

        /// <summary>
        /// 返回数据集合
        /// </summary>
        /// <value>The data.</value>
        public List<T> Data { get; set; }
    }
}
