﻿using System.Data.Entity;
using System.Web.Mvc;
using Winter.Web.Models;
using Winter.Web.Repository;

namespace Winter.Web.Controllers
{
    public class HomeController : Controller
    {
        IWinterDb db;

        public HomeController()
            : this(new WinterDb())
        { }

        public HomeController(IWinterDb db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var stories = db.Query<Story>().Include(s => s.StoryType); ;

            return View(stories);
        }

      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}