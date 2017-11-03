using MinskNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinskNews.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<News> _repoNews;
        public AdminController(IRepository<News> repoNews)
        {
            _repoNews = repoNews;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(_repoNews.GetAll());
        }

       

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(News news, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    news.Image = new byte[count];
                    imageUpload.InputStream.Read(news.Image, 0, (int)count);
                    news.MineType = imageUpload.ContentType;
                }
                try
                {
                    _repoNews.Create(news);
                    return RedirectToAction("Index");
                }
                catch 
                {
                    return View(news);
                }
            }
            else
                return View(news);
            
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repoNews.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(News news, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    news.Image = new byte[count];
                    imageUpload.InputStream.Read(news.Image, 0, (int)count);
                    news.MineType = imageUpload.ContentType;
                }
                try
                {
                    _repoNews.Updete(news);
                    return RedirectToAction("Index");
                }
                catch 
                {
                    return View(news);
                }
            }
            else
                return View(news);
        }

        // GET: Admin/Delete/5
        public RedirectToRouteResult Delete(int id)
        {
            _repoNews.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
