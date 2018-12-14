using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Core.IRepository;
using Blog.Core.Model.Models;
using Blog.Core.Repository.sugar;
using SqlSugar;
using Blog.Core.Repository.Base;

namespace Blog.Core.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>,IAdvertisementRepository
    {

    }
}
