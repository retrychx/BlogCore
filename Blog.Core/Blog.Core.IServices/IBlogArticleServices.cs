using System;
using System.Threading.Tasks;
using Blog.Core.IServices.Base;
using Blog.Core.Model.Models;
using Blog.Core.Model.ViewModels;
using System.Collections.Generic;

namespace Blog.Core.IServices
{
    public interface IBlogArticleServices : IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();

        Task<BlogViewModels> GetBlogDetails(int id);
    }
}
