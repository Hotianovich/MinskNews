using MinskNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinskNews.Controllers
{
    public class HomeController : Controller
    {
        IRepository<News> _repoNews;
        int pageSize = 5;
        public HomeController(IRepository<News> repoNews)
        {
            _repoNews = repoNews;
        }
        public ActionResult Index(int page = 1)
        {
            var news = _repoNews.GetAll();
            var model = PageListViewModel<News>.CreatePage(news, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListPartial", model);
            }
            return View(model);
        }

        public PartialViewResult ThreeNews()
        {
            var randnews = RandThree();
            return PartialView(randnews);
        }
        public IEnumerable<News> RandThree()
        {
            var count = _repoNews.GetAll();
            Random rand = new Random();
            List<News> listRand = new List<News>();
            for (int i = 0; i < 3; i++)
            {
                var id = rand.Next(1, count.Count()-1);
                News news = _repoNews.Get(id);
                listRand.Add(news);
            }
            return listRand;
        }

       
    }
}