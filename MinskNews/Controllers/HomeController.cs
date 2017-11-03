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

       
    }
}