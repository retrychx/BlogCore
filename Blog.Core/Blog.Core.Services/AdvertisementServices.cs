using System;
using Blog.Core.IRepository;
using Blog.Core.Repository;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Core.Services.Base;

namespace Blog.Core.Services
{
    public class AdvertisementServices : BaseServices<Advertisement>,IAdvertisementServices
    {
        //IAdvertisementRepository dal = new AdvertisementRepository();

        //public int Add(Advertisement model)
        //{
        //    return dal.Add(model);
        //}

        //public bool Delete(Advertisement model)
        //{
        //    return dal.Delete(model);
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    var t = dal.Query(whereExpression);
        //    return dal.Query(whereExpression);
        //}

        //public int Sum(int i, int j)
        //{
        //    return dal.Sum(i, j);
        //}

        //public bool Update(Advertisement model)
        //{
        //    return dal.Update(model);
        //}
    }
}
