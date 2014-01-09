using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winter.Web.Models;
using Winter.Web.Repository;

namespace Winter.Web.Tests.Controllers
{
    //[TestClass]
    //public class StoryControllerTests
    //{
    //    [TestMethod]
    //    public void StoriesDb_GivenGetAllStories_ShouldReturnAllStoriesFromDb()
    //    {
    //        using (var db = new WinterDb())
    //        {
    //            var result = db.Stories;

    //            Assert.AreEqual(3, result.Count());
    //        }
    //    }

    //    [TestMethod]
    //    public void StoriesDb_GivenANewStory_ShouldSaveToDb_AndThenRevertBackDB()
    //    {
    //        using (var db = new WinterDb())
    //        {
    //            var story = new Story { Title = "test", Content = "testcontent" };

    //            db.Stories.Add(story);
    //            db.SaveChanges();

    //            var result = db.Stories;

    //            Assert.AreEqual(4, result.Count());

    //            db.Stories.Remove(story);
    //            db.SaveChanges();
    //            Assert.AreEqual(3, result.Count());
    //        }
    //    }
    //}

    //[TestClass]
    //public class StoryRepositoryTestsWithTransaction : BaseTransactionalTestClass
    //{
    //    [TestMethod]
    //    public void StoriesDb_GivenANewStory_ShouldSaveToDb_AndThenRevertBackDB()
    //    {
    //        using (var db = new WinterDb())
    //        {
    //            var story = new Story { Title = "test", Content = "testcontent" };

    //            db.Stories.Add(story);
    //            db.SaveChanges();

    //            var result = db.Stories;

    //            Assert.AreEqual(4, result.Count());
    //        }
    //    }
    //}

}

