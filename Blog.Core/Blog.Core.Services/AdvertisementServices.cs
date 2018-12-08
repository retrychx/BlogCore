using System;
using Blog.Core.IRepository;
using Blog.Core.Repository;
using Blog.Core.IServices;

namespace Blog.Core.Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);
        }
    }
}
