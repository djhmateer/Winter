using System.Data.Entity;
using System.Web.Mvc;
using Winter.Web.Models;
using Winter.Web.Repository;
using System.Linq;

namespace Winter.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IWinterDb db;

        // Unity knows that if IWinterDb interface is asked for, it will inject in a new WinterDb()
        public HomeController(IWinterDb db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var stories = db.Query<Story>()
                            .OrderByDescending(s => s.Rating)
                            .Include(s => s.StoryType);

            return View(stories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}