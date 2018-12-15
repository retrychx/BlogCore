using System;
using System.Threading.Tasks;
using Blog.Core.IServices.Base;
using Blog.Core.Model.Models;
using System.Collections.Generic;

namespace Blog.Core.IServices
{
    public interface IBlogArticleServices : IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
    }
}
