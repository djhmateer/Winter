using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Winter.Web.Models;
using Winter.Web.Repository;

namespace Winter.Web.Controllers
{
    public class StoryController : Controller
    {
        IWinterDb db;

        public StoryController()
            : this(new WinterDb())
        { }

        public StoryController(IWinterDb db)
        {
            this.db = db;
        }

        // GET: /Story2/
        public ActionResult Index()
        {
            var stories = db.Query<Story>().Include(s => s.StoryType);
            return View(stories.ToList());
        }

        // GET: /Story2/Create
        public ActionResult Create()
        {
            ViewBag.StoryTypeID = new SelectList(db.Query<StoryType>(), "StoryTypeID", "Name");

            return View();
        }

        // POST: /Story2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoryID,StoryTypeID,Title,Content,VideoURL,ImageURL,AddedDate,Rating")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Add(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoryTypeID = new SelectList(db.Query<StoryType>(), "StoryTypeID", "Name", story.StoryTypeID);
            return View(story);
        }

        // GET: /Story2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Story story = db.Query<Story>().FirstOrDefault(s => s.StoryID == id);
            
            if (story == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoryTypeID = new SelectList(db.Query<StoryType>(), "StoryTypeID", "Name", story.StoryTypeID);
            return View(story);
        }

        // POST: /Story2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoryID,StoryTypeID,Title,Content,VideoURL,ImageURL,AddedDate,Rating")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Update(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoryTypeID = new SelectList(db.Query<StoryType>(), "StoryTypeID", "Name", story.StoryTypeID);
            return View(story);
        }

        // GET: /Story2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Query<Story>().FirstOrDefault(s => s.StoryID == id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: /Story2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var story = db.Query<Story>().FirstOrDefault(s => s.StoryID == id);
            db.Remove(story);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
