﻿using System;
using Blog.Core.IRepository.Base;
using Blog.Core.Model.Models;

namespace Blog.Core.IRepository
{
    public interface IBlogArticleRepository : IBaseRepository<BlogArticle>
    {
    }
}
