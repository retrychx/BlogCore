using System;
using Blog.Core.IRepository;

namespace Blog.Core.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public AdvertisementRepository()
        {
        }

        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
