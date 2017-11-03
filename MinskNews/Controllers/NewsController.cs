using MinskNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MinskNews.Controllers
{
    public class NewsController : Controller
    {
        IRepository<News> _repoNews;

        public NewsController(IRepository<News> repoNews)
        {
            _repoNews = repoNews;
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public async Task<FileResult> GetImage(int newsId)
        {
            var newsImage = await _repoNews.GetAsync(newsId);

            if (newsImage != null)
                return File(newsImage.Image, newsImage.MineType);
            else return null;
        }
    }
}