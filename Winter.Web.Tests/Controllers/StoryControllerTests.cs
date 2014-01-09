using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Winter.Web.Controllers;
using Winter.Web.Models;
using Winter.Web.Tests.Fakes;

namespace Winter.Web.Tests.Controllers
{
    [TestClass]
    public class StoryControllerTests
    {
        FakeWinterDb db;

        [TestInitialize]
        public void Init()
        {
            db = new FakeWinterDb();
        }

        [TestMethod]
        public void Index__ShouldReturn100StoriesOrderedByIDAscending()
        {
            db.AddSet(TestData.Stories);
            var controller = new StoryController(db);

            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Story>;

            Assert.AreEqual(100, model.Count());

            var expected = TestData.Stories.OrderBy(s => s.StoryID).ToList();

            int i = 0;
            foreach (var item in expected)
            {
                Assert.AreEqual(item.StoryID, model.ToList()[i].StoryID);
                i++;
            }
        }

        [TestMethod]
        public void Create_GivenAValidStory_ShouldSave()
        {
            var controller = new StoryController(db);

            // Story isn't checked in the model that it is valid..hmmm
            var story = new Story();
            controller.Create(story);

            Assert.AreEqual(1, db.Added.Count);
            Assert.IsTrue(db.Saved);
        }

        [TestMethod]
        public void Create_GivenAnInValidStory_ShouldNotSave()
        {
            // Need to add in some fake StoryTypes so when create fails, it 'returns' to view the drop down list again
            db.AddSet(TestData.StoryTypes);

            var controller = new StoryController(db);
            controller.ModelState.AddModelError("", "Invalid");

            var story = new Story();
            controller.Create(story);

            Assert.AreEqual(0, db.Added.Count);
            Assert.IsFalse(db.Saved);
        }
    }
}

