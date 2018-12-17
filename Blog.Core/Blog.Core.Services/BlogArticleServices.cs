using System;
using Blog.Core.IServices;
using Blog.Core.Services.Base;
using Blog.Core.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Core.IRepository;
using Blog.Core.Common;
using Blog.Core.Model.ViewModels;
using System.Linq;
using AutoMapper;

namespace Blog.Core.Services
{
    public class BlogArticleServices : BaseServices<BlogArticle>, IBlogArticleServices
    {
        IBlogArticleRepository dal;
        IMapper IMapper;

        public BlogArticleServices(IBlogArticleRepository dal,IMapper IMapper)
        {
            this.dal = dal;
            base.baseDal = dal;
            this.IMapper = IMapper;
        }

        [Caching(AbsoluteExpiration = 10)]//增加特性
        public async Task<List<BlogArticle>> GetBlogs()
        {
            var blogList = await dal.Query(s => s.bID > 0, s => s.bID);

            return blogList;
        }

        public async Task<BlogViewModels> GetBlogDetails(int id)
        {
            var bloglist = await dal.Query(s => s.bID > 0, s => s.bID);
            var idMin = bloglist.FirstOrDefault() != null ? bloglist.FirstOrDefault().bID : 0;
            var idMax = bloglist.LastOrDefault() != null ? bloglist.LastOrDefault().bID : 1;

            var idMinShow = id;
            var idMaxShow = id;

            var blogArticle = new BlogArticle();
            blogArticle = (await dal.Query(s => s.bID == idMinShow)).FirstOrDefault();

            var preBlog = new BlogArticle();

            while (idMinShow > idMin)
            {
                idMinShow--;
                preBlog = (await dal.Query(s => s.bID == idMinShow)).FirstOrDefault();

                if (preBlog != null)
                {
                    break;
                }
            }

            var nextBlog = new BlogArticle();

            while (idMaxShow < idMax)
            {
                idMaxShow++;
                nextBlog = (await dal.Query(s => s.bID == idMaxShow)).FirstOrDefault();

                if (nextBlog != null)
                {
                    break;
                }
            }

            blogArticle.btraffic += 1;

            await dal.Update(blogArticle, new List<string> { "btraffic" });

            var models = IMapper.Map<BlogViewModels>(blogArticle);

            if (nextBlog != null)
            {
                models.next = nextBlog.btitle;
                models.nextID = nextBlog.bID;
            }

            if (preBlog != null)
            {
                models.previous = preBlog.btitle;
                models.previousID = preBlog.bID;
            }

            return models;
        }
    }
}
