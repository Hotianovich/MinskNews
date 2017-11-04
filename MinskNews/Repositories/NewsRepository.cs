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

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public NewsRepository()
        {
            context = new NewsDb();
        }

        /// <summary>
        /// Сохранение объекта News в базе данных
        /// </summary>
        /// <param name="t">Объект News</param>
        public void Create(News t)
        {
            context.News.Add(t);
            context.SaveChanges();
        }

        /// <summary>
        /// Удаление объекта News из базы данных
        /// </summary>
        /// <param name="id">Идентификатор объекта News</param>
        public void Delete(int id)
        {
            var item = context.News.Find(id);
            if (item != null)
            {
                context.News.Remove(item);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Поиск объектов News в базе данных
        /// </summary>
        /// <param name="predicate">Условие для выборки объектов News</param>
        /// <returns>Возвращает коллекцию объектов News</returns>
        public IEnumerable<News> Find(Func<News, bool> predicate)
        {
            return context.News.Where(predicate).ToList();
        }

        /// <summary>
        /// Поиск объекта News в бд
        /// </summary>
        /// <param name="id">Значение первичного ключа для поиска объека News</param>       
        /// <returns>Обьект News</returns>
        public News Get(int id)
        {
            return context.News.Find(id);
        }

        /// <summary>
        /// Возвращает все объекты News, которые есть в бд
        /// </summary>
        /// <returns>Коллекцию объектов News</returns>
        public IEnumerable<News> GetAll()
        {
            return context.News;
        }

        /// <summary>
        /// Обнавление объекта News, который есть в бд
        /// </summary>
        /// <param name="t">Объект News</param>

        public void Updete(News t)
        {
            context.Entry<News>(t).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает объект News асинхронно
        /// </summary>
        /// <param name="id">Значение первичного ключа для поиска объека News</param>       
        /// <returns>Объект News</returns>
        public Task<News> GetAsync(int id)
        {
            return context.News.FindAsync(id);
        }

    }
}