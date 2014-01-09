using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Winter.Web.Models;
using Winter.Web.Repository;

namespace Winter.Web.Tests.Repository
{
    public class StoryRepositoryTests
    {
        [TestClass]
        public class StoryRepositoryTestsWithTransaction : BaseTransactionalTestClass
        {
            // This is just testing EF really
            [TestMethod]
            public void StoriesDb_GivenGetAllStories_ShouldReturnAllStoriesFromDb()
            {
                using (var db = new WinterDb())
                {
                    var result = db.Stories;

                    Assert.AreEqual(3, result.Count());
                }
            }

            // Again testing EF, but also transactional rollbacks
            [TestMethod]
            public void StoriesDb_GivenANewStory_ShouldSaveToDb_AndThenRevertBackDB()
            {
                using (var db = new WinterDb())
                {
                    var story = new Story { StoryTypeID=1, Title = "test", Content = "testcontent", AddedDate = DateTime.Now };

                    db.Stories.Add(story);
                    db.SaveChanges();

                    var result = db.Stories;

                    Assert.AreEqual(4, result.Count());
                }
            }
        }
    }
}
