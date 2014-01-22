using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Winter.Web.Models;
using Winter.Web.Repository;

namespace Winter.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class StoryController : Controller
    {
        readonly IWinterDb db;

        public StoryController(IWinterDb db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var stories = db.Query<Story>()
                            .Include(s => s.StoryType)
                            .OrderBy(s => s.StoryID);

            return View(stories.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.StoryTypeID = new SelectList(db.Query<StoryType>(), "StoryTypeID", "Name");

            // Passing a new Story so get default rating set as 1
            return View(new Story {Rating = 1});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoryID,StoryTypeID,Title,Content,VideoURL,ImageURL,Rating")] Story story)
        {
            story.AddedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Add(story);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoryTypeID = new SelectList(db.Query<StoryType>(), "StoryTypeID", "Name", story.StoryTypeID);
            return View(story);
        }

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

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var story = db.Query<Story>().FirstOrDefault(s => s.StoryID == id);
            
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

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
