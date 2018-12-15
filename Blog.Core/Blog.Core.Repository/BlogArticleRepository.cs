using System;
using Blog.Core.IRepository;
using Blog.Core.Repository.Base;
using Blog.Core.Model.Models;

namespace Blog.Core.Repository
{
    public class BlogArticleRepository : BaseRepository<BlogArticle>, IBlogArticleRepository
    {

    }
}
