using System;
using Blog.Core.IServices;
using Blog.Core.Services.Base;
using Blog.Core.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.IRepository;
using Blog.Core.Common;

namespace Blog.Core.Services
{
    public class BlogArticleServices : BaseServices<BlogArticle>, IBlogArticleServices
    {
        IBlogArticleRepository dal;

        public BlogArticleServices(IBlogArticleRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        [Caching(AbsoluteExpiration = 10)]//增加特性
        public async Task<List<BlogArticle>> GetBlogs()
        {
            var blogList = await dal.Query(s => s.bID > 0, s => s.bID);

            return blogList;
        }
    }
}
