using MinskNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MinskNews.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        NewsDb context;
        public NewsRepository()
        {
            context = new NewsDb();
        }

        public void Create(News t)
        {
            context.News.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = context.News.Find(id);
            if (item != null)
            {
                context.News.Remove(item);
            }
            context.SaveChanges();
        }

        public IEnumerable<News> Find(Func<News, bool> predicate)
        {
            return context.News.Where(predicate).ToList();
        }

        public News Get(int id)
        {
            return context.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return context.News;
        }

        public void Updete(News t)
        {
            context.Entry<News>(t).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Task<News> GetAsync(int id)
        {
            return context.News.FindAsync(id);
        }

    }
}