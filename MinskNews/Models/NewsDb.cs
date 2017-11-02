namespace MinskNews
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsDb : DbContext
    {
        static NewsDb()
        {
            Database.SetInitializer<NewsDb>(new NewsDbInitializer());
        }
        public NewsDb()
            : base("name=NewsDb")
        {
        }

        public DbSet<News> News { get; set; }

    }

    
}